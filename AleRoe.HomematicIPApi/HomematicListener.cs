using AleRoe.HomematicIpApi.Rpc;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AleRoe.HomematicIpApi
{
    internal class HomematicListener : IDisposable
    {
        private readonly CancellationTokenSource cts;
        private readonly JsonClient client;
        public HomematicListener(JsonClient client)
        {
            this.client = client ?? throw new ArgumentNullException(nameof(client));
            this.cts = new CancellationTokenSource();
        }

        public async Task ReceiveAsync(Action<PushEventArgs> receiveDelegate, CancellationToken cancellationToken = default)
        {
            using var lts = CancellationTokenSource.CreateLinkedTokenSource(cts.Token, cancellationToken);
            using var socket = new ClientWebSocket();

            try
            {
                var socketUri = client.Hosts.GetWebSocketUri();
                socket.Options.SetRequestHeader("AUTHTOKEN", client.AuthToken);
                socket.Options.SetRequestHeader("CLIENTAUTH", client.ClientAuth);
                await socket.ConnectAsync(socketUri, cancellationToken).ConfigureAwait(false);

                while (!lts.IsCancellationRequested)
                {
                    WebSocketReceiveResult result;
                    await using var stream = new MemoryStream();
                    do
                    {
                        //var buffer = new ArraySegment<byte>(new byte[1024 * 8 * 4]);
                        var buffer = new ArraySegment<byte>(new byte[1024]);
                        result = await socket.ReceiveAsync(buffer, lts.Token).ConfigureAwait(false);
                        if (buffer.Array != null)
                        {
                            await stream.WriteAsync(buffer.Array, 0, result.Count, lts.Token).ConfigureAwait(false);
                        }
                    } while (!result.EndOfMessage);

                    stream.Seek(0, SeekOrigin.Begin);
                    var data = Deserialize<PushEventArgs>(stream);
                    if (data != null) receiveDelegate(data);
                }
            }
            catch (OperationCanceledException)
            {
                //Ignore and end gracefully
            }
            catch (Exception e)
            {
                throw;
            }
            finally
            {
                if (socket.State != WebSocketState.Aborted & socket.State != WebSocketState.Closed)
                {
                    await socket.CloseAsync(WebSocketCloseStatus.NormalClosure, string.Empty, CancellationToken.None).ConfigureAwait(false);
                }
            }

            //needed to terminate the task, we ignore any errors
            await Task.CompletedTask.ConfigureAwait(false);
        }

        private T Deserialize<T>(MemoryStream stream) where T : class
        {
            try
            {
                using var reader = new StreamReader(stream, Encoding.UTF8);
                using var jsonReader = new JsonTextReader(reader);
                var serializer = JsonSerializer.CreateDefault(client.Settings);
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