using Microsoft.Extensions.Logging.Abstractions;
using NUnit.Framework;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace AleRoe.HomematicIpApi.Tests
{
    [TestFixture()]
    public class HomematicClientDisposeTests : HomematicClientTestsBase
    {
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
            var config = new HomematicIpConfiguration() { AccessPointId = AccessPoint, AuthToken = AuthToken };
            var client = new HomematicIpClient(config);
            Assert.DoesNotThrow(client.Dispose);
            await Task.CompletedTask;
        }

        [Test()]
        public async Task DisposeWithCustomHttpClientTest()
        {
            var config = new HomematicIpConfiguration() { AccessPointId = AccessPoint, AuthToken = AuthToken };
            using var httpClient = new HttpClient();
            var client = new HomematicIpClient(config, httpClient);
            await client.InitializeAsync(CancellationToken.None);
            var events = client.PushEventReceived.Subscribe(msg => { });

            Assert.DoesNotThrow(client.Dispose);
            Assert.That(client.httpClient, Is.Not.Null);
            await Task.CompletedTask;
        }


        [Test()]
        public async Task DisposeWithCustomLoggerFactoryTest()
        {
            var config = new HomematicIpConfiguration() { AccessPointId = AccessPoint, AuthToken = AuthToken };
            using var loggerFactory = new NullLoggerFactory();
            var client = new HomematicIpClient(config, loggerFactory);
            await client.InitializeAsync(CancellationToken.None);
            var events = client.PushEventReceived.Subscribe(msg => { });

            Assert.DoesNotThrow(client.Dispose);
            Assert.That(client.loggerFactory, Is.Not.Null);
            await Task.CompletedTask;
        }
    }
}
