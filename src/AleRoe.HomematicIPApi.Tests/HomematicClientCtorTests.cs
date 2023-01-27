using AleRoe.HomematicIpApi.Model.Client;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AleRoe.HomematicIpApi.Tests
{
    [TestFixture()]
    public class HomematicClientCtorTests
    {
        private string accessPoint = "3014F711A00003D709B034F7";
        private string authToken = "F321A85FF95C4BB213B20DC0E005EAC6F649CB14A73A4A382335FB3CCB4DC3C8";

        [SetUp]
        public async Task Init()
        {
            await Task.Delay(1000);
        }

        [Test()]
        public async Task CtorTest()
        {
            Assert.DoesNotThrow(() =>
            {
                var config = new HomematicIpConfiguration() { AccessPointId = accessPoint, AuthToken = authToken };
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
                var config = new HomematicIpConfiguration() { AccessPointId = accessPoint, AuthToken = authToken };
                using var client = new HomematicIpClient(config, httpClient);
                Assert.AreSame(httpClient, client.httpClient);
            });
            await Task.CompletedTask;
        }

        [Test()]
        public async Task DisposeTest()
        {
            var config = new HomematicIpConfiguration() { AccessPointId = accessPoint, AuthToken = authToken };
            var client = new HomematicIpClient(config);
            await client.InitializeAsync(CancellationToken.None);
            var events = client.PushEventRecieved.Subscribe(msg => { });
            Assert.DoesNotThrow(client.Dispose);
            await Task.CompletedTask;
        }

        [Test()]
        public async Task DisposeWithoutInitializeTest()
        {
            var config = new HomematicIpConfiguration() { AccessPointId = accessPoint, AuthToken = authToken };
            var client = new HomematicIpClient(config);
            Assert.DoesNotThrow(client.Dispose);
            await Task.CompletedTask;
        }

        [Test()]
        public async Task DisposeWithCustomHttpClientTest()
        {
            var config = new HomematicIpConfiguration() { AccessPointId = accessPoint, AuthToken = authToken };
            using var httpClient = new HttpClient();
            var client = new HomematicIpClient(config, httpClient);
            Assert.DoesNotThrow(client.Dispose);
            Assert.IsNotNull(client.httpClient);

            await Task.CompletedTask;
        }
    }
}
