using NUnit.Framework;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace AleRoe.HomematicIpApi.Tests
{
    [TestFixture()]
    public class HomematicClientInitializeTests
    {
        private string accessPoint = "3014F711A00003D709B034F7";
        private string authToken = "F321A85FF95C4BB213B20DC0E005EAC6F649CB14A73A4A382335FB3CCB4DC3C8";

        [SetUp]
        public async Task Init()
        {
            await Task.Delay(1000);
        }

        [Test()]
        public async Task InitializeAsyncWithHttpClientTest()
        {
            using var httpClient = new HttpClient();
            _ = await httpClient.GetAsync("https://api.publicapis.org/entries");

            var config = new HomematicIpConfiguration() { AccessPointId = accessPoint, AuthToken = authToken };
            using var client = new HomematicIpClient(config, httpClient);

            Assert.DoesNotThrowAsync(async () => await client.InitializeAsync(CancellationToken.None));
            await Task.CompletedTask;
        }

        [Test()]
        public async Task InitializeAsyncTest()
        {
            var config = new HomematicIpConfiguration() { AccessPointId = accessPoint, AuthToken = authToken };
            using var client = new HomematicIpClient(config);
            Assert.DoesNotThrowAsync(async () => await client.InitializeAsync(CancellationToken.None));
            await Task.CompletedTask;
        }

        [Test()]
        public async Task InitializeAsyncCanceledTest()
        {
            var config = new HomematicIpConfiguration() { AccessPointId = accessPoint, AuthToken = authToken };
            using var client = new HomematicIpClient(config);

            var cts = new CancellationTokenSource();
            cts.Cancel();

            Assert.ThrowsAsync<TaskCanceledException>(async () => await client.InitializeAsync(cts.Token));
            await Task.CompletedTask;
        }

        [Test()]
        public async Task InitializeAsyncRunTwiceTest()
        {
            var config = new HomematicIpConfiguration() { AccessPointId = accessPoint, AuthToken = authToken };
            using var client = new HomematicIpClient(config);
            Assert.DoesNotThrowAsync(async () => await client.InitializeAsync(CancellationToken.None));
            var socket = client.socketClient.NativeClient;
            Assert.DoesNotThrowAsync(async () => await client.InitializeAsync(CancellationToken.None));
            Assert.AreNotSame(client.socketClient.NativeClient, socket);
            await Task.CompletedTask;
        }

        [Test()]
        public async Task GetDevicesAsyncTest_FailIfNotInitialized()
        {
            var config = new HomematicIpConfiguration() { AccessPointId = accessPoint, AuthToken = authToken };
            using var client = new HomematicIpClient(config);
            Assert.ThrowsAsync<InvalidOperationException>(async () => await client.GetDevicesAsync(CancellationToken.None));
            await Task.CompletedTask;
        }

        [Test()]
        public async Task GetGroupsAsyncTest_FailIfNotInitialized()
        {
            var config = new HomematicIpConfiguration() { AccessPointId = accessPoint, AuthToken = authToken };
            using var client = new HomematicIpClient(config);
            Assert.ThrowsAsync<InvalidOperationException>(async () => await client.GetGroupsAsync(CancellationToken.None));
            await Task.CompletedTask;
        }

    }
}
