using AleRoe.HomematicIpApi.Json;
using AleRoe.HomematicIpApi.Model.Devices;
using AleRoe.HomematicIpApi.Model.Groups;
using AleRoe.HomematicIpApi.Rpc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.WebSockets;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Websocket.Client;

[assembly: InternalsVisibleTo("AleRoe.HomematicIpApi.Tests")]

namespace AleRoe.HomematicIpApi
{
    /// <summary>
    /// A C# programming interface for HomematicIP cloud services.
    /// </summary>
    /// <seealso cref="System.IDisposable" />

    public class HomematicIpClient : IDisposable, IHomematicRpcService
    {
        private bool disposedValue;
        private readonly bool disposeHttpClient;
        
        private const string GetHostUri = @"https://lookup.homematic.com:48335/getHost";
        private const string CLIENTAUTH = "CLIENTAUTH";
        private const string AUTHTOKEN = "AUTHTOKEN";

        protected readonly HomematicIpConfiguration homematicIpConfiguration;
        protected Hosts hosts;

        internal readonly HttpClient httpClient;
        internal WebsocketClient socketClient;

        private readonly Subject<PushEventArgs> messageReceivedSubject = new();
        private IDisposable messageSubscription;
        private IDisposable connectSubscription;
        private IDisposable disconnectSubscription;



        /// <summary>
        /// Occurs on errors during serialization.
        /// </summary>
        public event EventHandler<ErrorEventArgs> OnSerializerError;

        /// <summary>
        /// Occurs on reconnection of websocket.
        /// </summary>
        public event EventHandler<ReconnectEventArgs> OnReconnect;

        /// <summary>
        /// Occurs on disconnection of websocket.
        /// </summary>
        public event EventHandler<DisconnectEventArgs> OnDisconnect;

        /// <summary>
        /// A stream of PushEvents
        /// </summary>
        public IObservable<PushEventArgs> PushEventRecieved => messageReceivedSubject.AsObservable();


        /// <summary>
        /// Initializes a new instance of the <see cref="HomematicIpClient"/> class with the specified <see cref="HomematicIpConfiguration"/> configuration.
        /// </summary>
        /// <param name="homematicIpConfiguration">The <see cref="HomematicIpConfiguration"/> to use for sending requests.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public HomematicIpClient(HomematicIpConfiguration homematicIpConfiguration) : this(homematicIpConfiguration, new HttpClient()) 
        {
            disposeHttpClient = true;    
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HomematicIpClient"/> class with the specified <see cref="HomematicIpConfiguration"/> configuration and <see cref="HttpClient"/> instance.
        /// </summary>
        /// <param name="homematicIpConfiguration">The <see cref="HomematicIpConfiguration"/> to use for sending requests.</param>
        /// <param name="httpClient">The <see cref="HttpClient"/> instance to use for sending requests. The instance will not be disposed.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public HomematicIpClient(HomematicIpConfiguration homematicIpConfiguration, HttpClient httpClient)
        {
            this.homematicIpConfiguration = homematicIpConfiguration ?? throw new ArgumentNullException(nameof(homematicIpConfiguration));
            this.httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }


        /// <summary>
        /// Initializes the <see cref="HomematicIpClient"/> instance and starts listening for events.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token to cancel the operation.</param>
        /// <returns>The Task object representing the asynchonous operation.</returns>
        /// <exception cref="WebSocketException"></exception>
        /// <exception cref="HttpRequestException"></exception>
        public async Task InitializeAsync(CancellationToken cancellationToken)
        {
            hosts = await GetHostsAsync(cancellationToken).ConfigureAwait(false);

            if (socketClient != null)
            {
                await socketClient.ReconnectOrFail();
            }
            else
            {
                var factory = new Func<ClientWebSocket>(() =>
                {
                    var client = new ClientWebSocket();
                    client.Options.SetRequestHeader(AUTHTOKEN, homematicIpConfiguration.AuthToken);
                    client.Options.SetRequestHeader(CLIENTAUTH, homematicIpConfiguration.ClientAuthToken);
                    return client;

                });

                socketClient = new WebsocketClient(new Uri(hosts.WebSocketUrl), factory)
                {
                    ReconnectTimeout = TimeSpan.FromMinutes(5)
                };

                messageSubscription = socketClient.MessageReceived
                    .Where(msg => msg.MessageType == WebSocketMessageType.Binary)
                    .Select(msg => msg.Binary.Deserialize<PushEventArgs>(JsonSerializerSettings))
                    .Subscribe(messageReceivedSubject);

                connectSubscription = socketClient.ReconnectionHappened
                    .Subscribe(info => OnReconnect?.Invoke(this, new ReconnectEventArgs(info)));

                disconnectSubscription = socketClient.DisconnectionHappened
                    .Subscribe(info => OnDisconnect?.Invoke(this, new DisconnectEventArgs(info)));

                await Task.Delay(500, cancellationToken).ConfigureAwait(false);
                await socketClient.StartOrFail().ConfigureAwait(false);
            }
        }

        private JsonSerializerSettings JsonSerializerSettings { get; } = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver(), TraceWriter = new DiagnosticsTraceWriter(), MissingMemberHandling = MissingMemberHandling.Error, NullValueHandling = NullValueHandling.Ignore};

        

        public async Task<IEnumerable<IDevice>> GetDevicesAsync(CancellationToken cancellationToken)
        {
            var result = await GetCurrentStateAsync(cancellationToken).ConfigureAwait(false);
            return result.Devices;
        }

        public async Task<CurrentState> GetCurrentStateAsync(CancellationToken cancellationToken)
        {
            var content = new ClientCharacteristicsRoot(homematicIpConfiguration.AccessPointId);
            return await PostRequestAsync<CurrentState, ClientCharacteristicsRoot>(RequestUri.GetCurrentState, content, cancellationToken).ConfigureAwait(false);
        }

        public async Task<IDevice> GetDeviceAsync(string id, CancellationToken cancellationToken = default)
        {
            var result = await GetDevicesAsync(cancellationToken).ConfigureAwait(false);
            return result.SingleOrDefault(x => x.Id.Equals(id));
        }

        public async Task<T> GetDeviceAsync<T>(string id, CancellationToken cancellationToken = default) where T : IDevice
        {
            var result = await GetDevicesAsync(cancellationToken).ConfigureAwait(false);
            return result.OfType<T>().SingleOrDefault(x => x.Id.Equals(id));
        }

        public async Task<IEnumerable<IGroup>> GetGroupsAsync(CancellationToken cancellationToken)
        {
            var result = await GetCurrentStateAsync(cancellationToken).ConfigureAwait(false);
            return result.Groups;
        }

        public async Task<IGroup> GetGroupAsync(string id, CancellationToken cancellationToken = default)
        {
            var result = await GetGroupsAsync(cancellationToken).ConfigureAwait(false);
            return result.SingleOrDefault(x => x.Id.ToString().Equals(id));
        }

        public async Task<T> GetGroupAsync<T>(string id, CancellationToken cancellationToken = default) where T : IGroup
        {
            var result = await GetGroupsAsync(cancellationToken).ConfigureAwait(false);
            return result.OfType<T>().SingleOrDefault(x => x.Id.ToString().Equals(id));
        }

        public async Task SetDeviceLabelAsync(string id, string label, CancellationToken cancellationToken = default)
        {
            var content = new SetDeviceLabel(id, label);
            await PostRequestAsync(RequestUri.SetDeviceLabel, content, cancellationToken).ConfigureAwait(false);
        }

        public async Task SetDeviceStateAsync(string id, bool state, int channelIndex = 1, CancellationToken cancellationToken = default)
        {
            var content = new SetDeviceState(id, state, channelIndex);
            await PostRequestAsync(RequestUri.SetDeviceState, content, cancellationToken).ConfigureAwait(false);
        }

        public async Task SetDeviceDimLevelAsync(string id, double dimLevel, CancellationToken cancellationToken = default)
        {
            var content = new SetDimmerLevel(id, dimLevel);
            await PostRequestAsync(RequestUri.SetDeviceDimLevel, content, cancellationToken).ConfigureAwait(false);
        }

        public async Task SetGroupStateAsync(Guid id, bool state, CancellationToken cancellationToken = default)
        {
            var content = new SetGroupState(id, state);
            await PostRequestAsync(RequestUri.SetGroupState, content, cancellationToken).ConfigureAwait(false);
        }


        //protected async Task StartListen(CancellationToken cancellationToken)
        //{
        //    using var clientWebSocket = new ClientWebSocket();
        //    clientWebSocket.Options.SetRequestHeader(AUTHTOKEN, HomematicIpConfiguration.AuthToken);
        //    clientWebSocket.Options.SetRequestHeader(CLIENTAUTH, HomematicIpConfiguration.ClientAuthToken);
            

        //    await using var stream = new System.IO.MemoryStream();
        //    var buffer = WebSocket.CreateClientBuffer(4096, 4096);

        //    while (!cancellationToken.IsCancellationRequested)
        //    {
        //        if (clientWebSocket.State != WebSocketState.Open)
        //        {
        //            //throw new WebSocketException();
        //            //await Task.FromException(new WebSocketException()).ConfigureAwait(false);
        //            await clientWebSocket.ConnectAsync(new Uri(Hosts.WebSocketUrl), cancellationToken).WaitAsync(TimeSpan.FromSeconds(5), cancellationToken).ConfigureAwait(false);
        //        }
        //        try
        //        {
        //            WebSocketReceiveResult result;
        //            do
        //            {
        //                result = await clientWebSocket.ReceiveAsync(buffer, cancellationToken).ConfigureAwait(false);
        //                switch (result.MessageType)
        //                {
        //                    case WebSocketMessageType.Text:
        //                        break;

        //                    case WebSocketMessageType.Binary:
        //                        await stream.WriteAsync(buffer.AsMemory(0, result.Count), cancellationToken).ConfigureAwait(false);
        //                        break;

        //                    case WebSocketMessageType.Close:
        //                        await clientWebSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, string.Empty, CancellationToken.None).ConfigureAwait(false);
        //                        break;

        //                    default:
        //                        throw new ArgumentOutOfRangeException();
        //                }

        //            } while (!result.EndOfMessage);

        //            if (stream.Length != 0)
        //            {
        //                var data = stream.DeserializeStream<PushEventArgs>(JsonSerializerSettings, true);
        //                MessageRecieved?.Invoke(this, data);
        //            }
        //        }
        //        catch (TaskCanceledException)
        //        {
        //            if (!cancellationToken.IsCancellationRequested)
        //                throw;
        //        }
        //    }
        //}



        internal async Task<Hosts> GetHostsAsync(CancellationToken cancellationToken)
        {
            var content = new ClientCharacteristicsRoot(homematicIpConfiguration.AccessPointId);
            using var response = await httpClient.PostAsJsonAsync(new Uri(GetHostUri), content, cancellationToken).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<Hosts>(cancellationToken).ConfigureAwait(false);
        }

        internal async Task PostRequestAsync<TRequest>(RequestUri requestUri, TRequest value, CancellationToken cancellationToken)
            => await PostRequestAsync<HttpResponseMessage, TRequest>(requestUri, value, cancellationToken).ConfigureAwait(false);

       

        internal async Task<TResponse> PostRequestAsync<TResponse, TRequest>(RequestUri requestUri, TRequest value, CancellationToken cancellationToken)
        {
            if (hosts is null)
            {
                throw new InvalidOperationException("Missing Hosts data. Make sure to call Initialize().");
            }

            var uri = new Uri(hosts.GetRestUri(), requestUri.ToString());
            using var request = CreateJsonRequestMessage(value, HttpMethod.Post, uri);                  
            using var response = await httpClient.SendAsync(request, cancellationToken).ConfigureAwait(false); 
                
            response.EnsureSuccessStatusCode();

            var settings = JsonSerializerSettings;
            settings.Context = new StreamingContext(StreamingContextStates.Other, this);
            settings.Error += SerializerError;
            var formatters = new List<MediaTypeFormatter>{new DefaultJsonMediaTypeFormatter(settings)};

            return await response.Content.ReadAsAsync<TResponse>(formatters, cancellationToken).ConfigureAwait(false);

        }

        private HttpRequestMessage CreateJsonRequestMessage<T>(T value, HttpMethod method, Uri uri)
        {
            var content = new StringContent(JsonConvert.SerializeObject(value), Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage(method, uri)
                {
                    Content = content,
                };
                request.Headers.Add("VERSION", "12");
                request.Headers.Add(CLIENTAUTH, homematicIpConfiguration.ClientAuthToken);
                request.Headers.Add(AUTHTOKEN, homematicIpConfiguration.AuthToken); 
                
                return request;
            
        }

        private void SerializerError(object sender, ErrorEventArgs args)
        {
            if (args.CurrentObject == args.ErrorContext.OriginalObject)
            {
                OnSerializerError?.Invoke(this, args);
            }
            args.ErrorContext.Handled = true;
        }

        

        #region IDisposable Support

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        private void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    socketClient?.Dispose();
                    messageSubscription?.Dispose();
                    connectSubscription?.Dispose();
                    disconnectSubscription?.Dispose();
                    

                    if (disposeHttpClient)
                    {
                        httpClient?.Dispose();
                    }
                }
                disposedValue = true;
            }
        }

        /// <inheritdoc/>
        public void Dispose() => Dispose(true);
        #endregion
    }
}
