using AleRoe.HomematicIpApi.Rpc;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.WebSockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

[assembly : InternalsVisibleTo("AleRoe.HomematicIpApi.Tests")]
[assembly: InternalsVisibleTo("TestProject1")]
namespace AleRoe.HomematicIpApi
{
    internal class HomematicListener : IDisposable
    {
        private readonly JsonClient client;
        internal ClientWebSocket Socket;
        private CancellationTokenSource socketLoopTokenSource;
        internal CancellationTokenSource CancellationTokenSource;
        private bool reconnect;
        private bool isListening;

        public HomematicListener(JsonClient client)
        {
            this.client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public  WebSocketState State => Socket?.State ?? WebSocketState.None;

        public async Task ConnectAsync(CancellationToken cancellationToken = default)
        {
            this.socketLoopTokenSource = new CancellationTokenSource();
            this.Socket = new ClientWebSocket();
            var socketUri = client.Hosts.GetWebSocketUri();
            Socket.Options.SetRequestHeader("AUTHTOKEN", client.AuthToken);
            Socket.Options.SetRequestHeader("CLIENTAUTH", client.ClientAuth);
            //Socket.Options.KeepAliveInterval = TimeSpan.FromSeconds(20);

            await Socket.ConnectAsync(socketUri, cancellationToken).ConfigureAwait(false);
        }

        public async Task CloseAsync(int timeoutDelay = 10000)
        {
            if (Socket == null || Socket.State != WebSocketState.Open) return;
            var timeout = new CancellationTokenSource(timeoutDelay);
            try
            {
                if (isListening)
                {
                    // close the socket first, because ReceiveAsync leaves an invalid socket (state = aborted) when the token is cancelled
                    // after this, the socket state which change to CloseSent
                    await Socket.CloseOutputAsync(WebSocketCloseStatus.NormalClosure, "Closing", timeout.Token);
                    // now we wait for the server response, which will close the socket
                    while (Socket.State != WebSocketState.Closed && !timeout.Token.IsCancellationRequested) { }
                }
                else
                {
                    await Socket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Closing", timeout.Token);
                }
            }
            catch (OperationCanceledException)
            {
                // normal upon task/token cancellation, disregard
            }
            finally
            {
                // whether we closed the socket or timed out, we cancel the token causing ReceiveAsync to abort the socket
                socketLoopTokenSource.Cancel();
            }
        }


        private Task SocketProcessingLoopAsync(Action<PushEventArgs> receiveDelegate)
        {
            return Task.Run(async () =>
            {
                try
                {
                    if (State != WebSocketState.Open)
                        throw new WebSocketException(WebSocketError.InvalidState);

                    isListening = true;
                    await using var stream = new MemoryStream();
                    var buffer = WebSocket.CreateClientBuffer(4096, 4096);
                    var cancellationToken = socketLoopTokenSource.Token;

                    while (Socket.State != WebSocketState.Closed && !cancellationToken.IsCancellationRequested)
                    {
                        var result = await Socket.ReceiveAsync(buffer, cancellationToken).ConfigureAwait(false);
                        // if the token is cancelled while ReceiveAsync is blocking, the socket state changes to aborted and it can't be used
                        if (!cancellationToken.IsCancellationRequested)
                        {
                            // the server is notifying us that the connection will close; send acknowledgement
                            if (Socket.State == WebSocketState.CloseReceived && result.MessageType == WebSocketMessageType.Close)
                            {
                                await Socket.CloseOutputAsync(WebSocketCloseStatus.NormalClosure, "Acknowledge Close frame", CancellationToken.None).ConfigureAwait(false);
                            }
                            else if (Socket.State == WebSocketState.Open && result.MessageType == WebSocketMessageType.Binary)
                            {
                                await stream.WriteAsync(buffer.AsMemory(0, result.Count), cancellationToken).ConfigureAwait(false);
                                if (result.EndOfMessage)
                                {
                                    stream.Seek(0, SeekOrigin.Begin);
                                    var data = Deserialize<PushEventArgs>(stream, client.Settings, true);
                                    if (data != null) receiveDelegate(data);
                                    stream.SetLength(0);
                                }
                            }
                        }
                    }
                }
                catch (OperationCanceledException)
                {
                    // normal upon task/token cancellation, disregard
                }
                finally
                {
                   
                    isListening = false;
                }
            }, CancellationToken.None);
        }

        
        public async Task ReceiveAsync(Action<PushEventArgs> receiveDelegate, CancellationToken cancellationToken)
        {
            //CancellationTokenSource = new CancellationTokenSource();
            //using var linkedTokenSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, CancellationTokenSource.Token);
            try
            {
                await using var registration = cancellationToken.Register(async ()
                    => await CloseAsync().ConfigureAwait(false));

                if (reconnect)
                {
                    await ConnectAsync(CancellationToken.None).ConfigureAwait(false);
                }

                await SocketProcessingLoopAsync(receiveDelegate).ConfigureAwait(false);
            }
            catch (TaskCanceledException)
            {
                if (!cancellationToken.IsCancellationRequested)
                    throw;
            }
            catch (OperationCanceledException)
            {
                //Ignore and end gracefully
            }
            finally
            {
                this.Socket?.Dispose();
                Socket = null;
            }
            reconnect = true;
        }

        private static T Deserialize<T>(MemoryStream stream, JsonSerializerSettings settings, bool leaveOpen = false) where T : class
        {
            try
            {
                using var reader = new StreamReader(stream, Encoding.UTF8, leaveOpen: leaveOpen);
                using var jsonReader = new JsonTextReader(reader);
                var serializer = JsonSerializer.CreateDefault(settings);
                return serializer.Deserialize<T>(jsonReader);
            }
            catch (Exception e)
            {
                throw new ApplicationException("Error deserializing PushEventArgs", e);
            }
        }

        #region IDisposable Support

        private bool disposedValue; 

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    CloseAsync().Wait();
                    socketLoopTokenSource?.Dispose();
                    CancellationTokenSource?.Dispose();
                    Socket?.Dispose();
                    Socket = null;
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
        #endregion
    }
}