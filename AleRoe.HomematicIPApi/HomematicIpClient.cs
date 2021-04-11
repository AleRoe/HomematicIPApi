using AleRoe.HomematicIpApi.Rpc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace AleRoe.HomematicIpApi
{
    /// <summary>
    /// A C# programming interface for HomematicIP cloud services.
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public sealed class HomematicIpClient : IDisposable
    {
        private bool disposedValue;
        private Task listenerTask;
        private HomematicListener listener;
        private CancellationTokenSource cts;
        private IHomematicRpcService service;
        private JsonClient client;
        private readonly string accessPoint;
        private readonly string authToken;

        public IHomematicRpcService Service
        {
            get => service ?? throw new InvalidOperationException("Make sure to call Initialize.");
            private set  => service = value; 
        }

        /// <summary>
        /// Occurs when the state of a Device, Group or Client changes.
        /// </summary>
        public event EventHandler<PushEventArgs> StateChanged;

        /// <summary>
        /// Occurs on errors during serialization.
        /// </summary>
        public event EventHandler<ErrorEventArgs> SerializerError;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomematicIpClient"/> class.
        /// </summary>
        /// <param name="accessPoint">The access point.</param>
        /// <param name="authToken">The authentication token.</param>
        /// <exception cref="ArgumentException"></exception>
        public HomematicIpClient(string accessPoint, string authToken)
        {
            if (string.IsNullOrEmpty(accessPoint))
                throw new ArgumentException("Must specify AccessPoint.");
            this.accessPoint = accessPoint;

            if (string.IsNullOrEmpty(authToken))
                throw new ArgumentException("Must specify AuthToken.");
            this.authToken = authToken;
        }

        /// <summary>
        /// Initializes the <see cref="HomematicIpClient"/> for use.
        /// </summary>
        /// <returns>A <see cref="Task"/>.</returns>
        public async Task Initialize()
        {
            if (service == null)
            {
                var settings = new JsonSerializerSettings()
                {
                    TraceWriter = new DiagnosticsTraceWriter(),
                    MissingMemberHandling = MissingMemberHandling.Error,
                    NullValueHandling = NullValueHandling.Include
                };
                
                client = new JsonClient(accessPoint, authToken, settings);
                Service = new HomematicRpcService(client);
                listener = new HomematicListener(client);

                //need to set the StreamingContext after the service is created!
                client.Settings.Context = new StreamingContext(StreamingContextStates.Other, this.Service);
                client.Settings.Error += OnSerializerError;
                
                cts = new CancellationTokenSource();
                await listener.ConnectAsync(CancellationToken.None);
                this.listenerTask = listener.ReceiveAsync(OnStateChanged, cts.Token);
                
            }
        }

        /// <summary>
        /// Shuts down the client.
        /// </summary>
        /// <returns></returns>
        public Task ShutDown()
        {
            try
            {
                cts?.Cancel();
                listenerTask?.Wait(5000);
                return Task.CompletedTask;
            }
            catch (Exception e)
            {
                return Task.FromException(e);
            }
        }

        private void OnSerializerError(object sender, ErrorEventArgs args)
        {
            if (args.CurrentObject == args.ErrorContext.OriginalObject)
            {
                SerializerError?.Invoke(this, args);
            }
            args.ErrorContext.Handled = true;
        }

        private void OnStateChanged(PushEventArgs args)
        {
            StateChanged?.Invoke(this, args);
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
                    ShutDown().Wait(15000);
                    cts?.Dispose();
                    listenerTask?.Dispose();
                    listener?.Dispose();
                    client?.Dispose();
                }
                disposedValue = true;
            }
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            Dispose(true);
        }
        #endregion
    }
}
