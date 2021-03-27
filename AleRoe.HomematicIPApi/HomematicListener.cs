using AleRoe.HomematicIpApi.Rpc;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Nito.AsyncEx.Synchronous;

namespace AleRoe.HomematicIpApi
{
    internal class HomematicListener : IDisposable
    {
        private readonly CancellationTokenSource cts;
        private readonly JsonClient client;
        private readonly ClientWebSocket socket;
        
        public HomematicListener(JsonClient client)
        {
            this.client = client ?? throw new ArgumentNullException(nameof(client));
            this.cts = new CancellationTokenSource();
            this.socket = new ClientWebSocket();
        }

        public async Task ConnectAsync(CancellationToken cancellationToken = default)
        {
            var socketUri = client.Hosts.GetWebSocketUri();
            socket.Options.SetRequestHeader("AUTHTOKEN", client.AuthToken);
            socket.Options.SetRequestHeader("CLIENTAUTH", client.ClientAuth);

            await socket.ConnectAsync(socketUri, cancellationToken).ConfigureAwait(false);
        }

        public async Task DisconnectAsync(CancellationToken cancellationToken = default)
        {
            if (socket.State != WebSocketState.Aborted & socket.State != WebSocketState.Closed)
            {
                await socket.CloseAsync(WebSocketCloseStatus.NormalClosure, string.Empty, cancellationToken).ConfigureAwait(false);
            }
        }

        private static Task SocketListenTask(WebSocket socket, Action<PushEventArgs> receiveDelegate, JsonSerializerSettings settings, CancellationToken cancellationToken)
        {
            return Task.Run(async () =>
            {
                await using var stream = new MemoryStream();
                while (socket.State == WebSocketState.Open)
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    var buffer = new byte[1024];
                    var result = await socket.ReceiveAsync(new ArraySegment<byte>(buffer), cancellationToken).ConfigureAwait(false);
                    if (result.MessageType == WebSocketMessageType.Binary)
                    {
                        await stream.WriteAsync(buffer.AsMemory(0, result.Count), cancellationToken).ConfigureAwait(false);
                        if (result.EndOfMessage)
                        {
                            stream.Seek(0, SeekOrigin.Begin);
                            var data = Deserialize<PushEventArgs>(stream, settings, true);
                            if (data != null) receiveDelegate(data);
                            stream.SetLength(0);
                        }
                    }
                    else if (result.MessageType == WebSocketMessageType.Close)
                    {
                        throw new WebSocketException(WebSocketError.ConnectionClosedPrematurely);
                    }
                }
            }, cancellationToken);
        }

        public async Task ReceiveAsync(Action<PushEventArgs> receiveDelegate, CancellationToken cancellationToken = default)
        {
            using var lts = CancellationTokenSource.CreateLinkedTokenSource(cts.Token, cancellationToken);
            try
            {
                await SocketListenTask(socket, receiveDelegate, client.Settings, lts.Token).ConfigureAwait(false);
            }
            catch (TaskCanceledException)
            {
                if (!lts.IsCancellationRequested)
                    throw;
            }
            catch (OperationCanceledException)
            {
                //Ignore and end gracefully
            }

            //needed to terminate the task, we ignore any errors
            await Task.CompletedTask.ConfigureAwait(false);
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
                    cts?.Cancel();
                    cts?.Dispose();
                    DisconnectAsync().WaitAndUnwrapException();
                    socket?.Dispose();
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