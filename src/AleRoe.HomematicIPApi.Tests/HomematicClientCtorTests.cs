using NUnit.Framework;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace AleRoe.HomematicIpApi.Tests
{
    [TestFixture()]
    public class HomematicClientCtorTests : HomematicClientTestsBase
    {

        [Test()]
        public async Task CtorTest()
        {
            Assert.DoesNotThrow(() =>
            {
                var config = new HomematicIpConfiguration() { AccessPointId = AccessPoint, AuthToken = AuthToken };
                using var client = new HomematicIpClient(config);
            });
            await Task.CompletedTask;
        }

        [Test()]
        public async Task CtorArgumentNullTest()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                using var client = new HomematicIpClient(null);
            });
            await Task.CompletedTask;
        }

        [Test()]
        public async Task CtorWithHttpClientTest()
        {
            Assert.DoesNotThrow(() =>
            {
                using var httpClient = new HttpClient();
                var config = new HomematicIpConfiguration() { AccessPointId = AccessPoint, AuthToken = AuthToken };
                using var client = new HomematicIpClient(config, httpClient);
                Assert.AreSame(httpClient, client.httpClient);
            });
            await Task.CompletedTask;
        }

        [Test()]
        public async Task DisposeTest()
        {
            var config = new HomematicIpConfiguration() { AccessPointId = AccessPoint, AuthToken = AuthToken };
            var client = new HomematicIpClient(config);
            await client.InitializeAsync(CancellationToken.None);
            var events = client.PushEventReceived.Subscribe(msg => { });
            Assert.DoesNotThrow(client.Dispose);
            await Task.CompletedTask;
        }

        [Test()]
        public async Task DisposeWithoutInitializeTest()
        {
            var config = new HomematicIpConfiguration() {AccessPointId = AccessPoint, AuthToken = AuthToken };
            var client = new HomematicIpClient(config);
            Assert.DoesNotThrow(client.Dispose);
            await Task.CompletedTask;
        }

        [Test()]
        public async Task DisposeWithCustomHttpClientTest()
        {
            var config = new HomematicIpConfiguration() {AccessPointId = AccessPoint, AuthToken = AuthToken };
            using var httpClient = new HttpClient();
            var client = new HomematicIpClient(config, httpClient);
            Assert.DoesNotThrow(client.Dispose);
            Assert.IsNotNull(client.httpClient);

            await Task.CompletedTask;
        }
    }
}
