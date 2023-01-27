using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using AleRoe.HomematicIpApi;
using AleRoe.HomematicIpApi.Rpc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using NUnit.Framework;

namespace AleRoe.HomematicIpApi.Tests
{
    [TestFixture()]
    public class HomematicListenerTests
    {
        private string accessPoint = "3014F711A00003D709B034F7";
        private string authToken = "F321A85FF95C4BB213B20DC0E005EAC6F649CB14A73A4A382335FB3CCB4DC3C8";

        [SetUp]
        public void Init()
        {
            /* ... */
            Thread.Sleep(1000);
        }

        [Test]
        public void CtorTest()
        {
            using var client = CreateClient();
            HomematicListener listener = null;
            Assert.DoesNotThrow(() => listener = new HomematicListener(client));
            Assert.IsInstanceOf<HomematicListener>(listener);
            Assert.AreEqual(WebSocketState.None, listener.State);
            Assert.DoesNotThrow(() => listener.Dispose());
            Assert.AreEqual(WebSocketState.None, listener.State);
        }

        [Test]
        public void ConnectAndCloseAsyncTest()
        {
            using var client = CreateClient();
            using var listener = new HomematicListener(client);

            Assert.DoesNotThrowAsync(async () => await listener.ConnectAsync());
            Assert.AreEqual(WebSocketState.Open, listener.State);
            Assert.DoesNotThrowAsync(async () => await listener.CloseAsync());
            Assert.AreEqual(WebSocketState.Closed, listener.State);
        }

        [Test]
        public void CloseAsyncTest_NotConnectedDoesNotThrow()
        {
            using var client = CreateClient();
            using var listener = new HomematicListener(client);

            Assert.DoesNotThrowAsync(async () => await listener.CloseAsync());
            Assert.AreEqual(WebSocketState.None, listener.State);
        }

        [Test]
        public void ReceiveAsyncTest_Close()
        {
            using var client = CreateClient();
            using var listener = new HomematicListener(client);
            void ReceiveDelegate(PushEventArgs args) { }

            Assert.DoesNotThrowAsync(async () => await listener.ConnectAsync());
            Assert.AreEqual(WebSocketState.Open, listener.State);
            _ = listener.ReceiveAsync(ReceiveDelegate, CancellationToken.None);
            Assert.DoesNotThrowAsync(async () => await listener.CloseAsync());
            Assert.AreEqual(WebSocketState.Closed, listener.State);
        }

        [Test]
        public void ReceiveAsyncTest_Cancel()
        {
            using var client = CreateClient();
            using var listener = new HomematicListener(client);
            using var cts = new CancellationTokenSource(1000);
            static void ReceiveDelegate(PushEventArgs args) { }
            
            Assert.DoesNotThrowAsync(async () => await listener.ConnectAsync(CancellationToken.None));
            Assert.DoesNotThrowAsync(async () => await listener.ReceiveAsync(ReceiveDelegate, cts.Token));
            Assert.AreEqual(WebSocketState.None, listener.State);
        }

        [Test]
        public void ReceiveAsyncTest_NotConnectedThrows()
        {
            using var client = CreateClient();
            using var listener = new HomematicListener(client);
            using var cts = new CancellationTokenSource(1000);
            static void ReceiveDelegate(PushEventArgs args) { }
            
            Assert.ThrowsAsync<WebSocketException>(async () => await listener.ReceiveAsync(ReceiveDelegate, cts.Token));
            
        }

        [Test]
        public void ReceiveAsyncTest_Recycle()
        {
            using var client = CreateClient();
            using var listener = new HomematicListener(client);
            static void ReceiveDelegate(PushEventArgs args) { }

            Assert.DoesNotThrowAsync(async () => await listener.ConnectAsync(CancellationToken.None));
            Assert.DoesNotThrowAsync(async () =>
            {
                var cts = new CancellationTokenSource(500);
                await listener.ReceiveAsync(ReceiveDelegate, cts.Token);
            });
            Assert.AreEqual(WebSocketState.None, listener.State);

            Assert.DoesNotThrowAsync(async () =>
            {
                var cts = new CancellationTokenSource(500);
                await listener.ReceiveAsync(ReceiveDelegate, cts.Token);
            });
            Assert.AreEqual(WebSocketState.None, listener.State);
            
        }

        private JsonClient CreateClient()
        {
            var settings = new JsonSerializerSettings()
            {
                TraceWriter = new DiagnosticsTraceWriter(),
                MissingMemberHandling = MissingMemberHandling.Error,
                NullValueHandling = NullValueHandling.Include
            };

            return new JsonClient(accessPoint, authToken, settings);

        }
    }
}