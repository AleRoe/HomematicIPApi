using AleRoe.HomematicIpApi.Model.Devices;
using AleRoe.HomematicIpApi.Model.Groups;
using AleRoe.HomematicIpApi.Rpc;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace AleRoe.HomematicIpApi.Tests
{
    [TestFixture()]
    public class HomematicClientTests
    {
        private string accessPoint = "3014F711A00003D709B034F7";
        private string authToken = "F321A85FF95C4BB213B20DC0E005EAC6F649CB14A73A4A382335FB3CCB4DC3C8";


        

        [SetUp]
        public async Task Init()
        {
            await Task.Delay(500);
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
        public async Task InitializeAsyncWithHttpClientText()
        {
            using var httpClient = new HttpClient();
            _ = await httpClient.GetAsync("https://api.publicapis.org/entries");

            var config = new HomematicIpConfiguration() { AccessPointId = accessPoint, AuthToken = authToken };
            using var client = new HomematicIpClient(config);

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
        public async Task GetDevicesAsyncTest_ServiceProviderIsSet()
        {
            IEnumerable<IDevice> result = default;
            var config = new HomematicIpConfiguration() { AccessPointId = accessPoint, AuthToken = authToken };
            using var client = new HomematicIpClient(config);
            
            await client.InitializeAsync(CancellationToken.None);
            result = await client.GetDevicesAsync(CancellationToken.None);

            Assert.IsTrue(result.All(x => x.Service != null));
        }

        [Test()]
        public async Task GetGroupsAsyncTest_ServiceProviderIsSet()
        {
            IEnumerable<IGroup> result = default;
            var config = new HomematicIpConfiguration() { AccessPointId = accessPoint, AuthToken = authToken };
            using var client = new HomematicIpClient(config);
            
            await client.InitializeAsync(CancellationToken.None);
            result = await client.GetGroupsAsync(CancellationToken.None);
            
            Assert.IsTrue(result.All(x => x.Service != null));
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
        public async Task GetDevicesAsyncTest()
        {
            IEnumerable<IDevice> result = default;
            var hasError = false;
            var config = new HomematicIpConfiguration() { AccessPointId = accessPoint, AuthToken = authToken };
            using var client = new HomematicIpClient(config);
            client.OnSerializerError += (s, e) =>
            {
                TestContext.Out.WriteLine(e.ErrorContext.Error.ToString());
                TestContext.Out.WriteLine();
                hasError = true;
            };
            
            await client.InitializeAsync(CancellationToken.None);
            result = await client.GetDevicesAsync(CancellationToken.None);
            
            CollectionAssert.IsNotEmpty(result);
            Assert.IsFalse(hasError);
        }

        [Test()]
        public async Task GetGroupsAsyncTest()
        {
            var hasError = false;
            var config = new HomematicIpConfiguration() { AccessPointId = accessPoint, AuthToken = authToken };
            using var client = new HomematicIpClient(config);
            client.OnSerializerError += (s, e) =>
            {
                TestContext.Out.WriteLine(e.ErrorContext.Error.ToString());
                TestContext.Out.WriteLine();
                hasError = true;
            };
            await client.InitializeAsync(CancellationToken.None);
            var result = await client.GetGroupsAsync(CancellationToken.None);
                            
            CollectionAssert.IsNotEmpty(result);
            Assert.IsFalse(hasError);
        }

        [Test()]
        public async Task GetCurrentStateAsyncTest()
        {
            var hasError = false;
            var config = new HomematicIpConfiguration() { AccessPointId = accessPoint, AuthToken = authToken };
            using var client = new HomematicIpClient(config);
            client.OnSerializerError += (s, e) =>
            {
                TestContext.Out.WriteLine(e.ErrorContext.Error.ToString());
                TestContext.Out.WriteLine();
                hasError = true;
            };

            await client.InitializeAsync(CancellationToken.None);
            var result = await client.GetCurrentStateAsync(CancellationToken.None);
            
            Assert.IsNotNull(result);
            Assert.IsFalse(hasError);

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

        [Test()]
        public async Task Dispose()
        {
            var config = new HomematicIpConfiguration() { AccessPointId = accessPoint, AuthToken = authToken };
            var client = new HomematicIpClient(config);
            var events = client.PushEventRecieved.Subscribe(msg => { });
            await client.InitializeAsync(CancellationToken.None);
            Assert.DoesNotThrow(client.Dispose);

            await Task.CompletedTask;
        }

        [Test()]
        public async Task DisposeWithCustomHttpClient()
        {
            var config = new HomematicIpConfiguration() { AccessPointId = accessPoint, AuthToken = authToken };
            using var httpClient = new HttpClient();
            using var client = new HomematicIpClient(config, httpClient);
            Assert.DoesNotThrow(client.Dispose);
            Assert.IsNotNull(client.httpClient);

            await Task.CompletedTask;
        }

        [Test()]
        public async Task RaisesEvents()
        {
            var tcs = new TaskCompletionSource<PushEventArgs>();
            var cts = new CancellationTokenSource();

            var config = new HomematicIpConfiguration() { AccessPointId = accessPoint, AuthToken = authToken };
            using var client = new HomematicIpClient(config);
            using var events = client.PushEventRecieved.Subscribe(msg => tcs.SetResult(msg));

            await client.InitializeAsync(CancellationToken.None);
            

            var result = await client.GetDevicesAsync(CancellationToken.None);
            var light = result.OfType<SwitchDeviceBase>().First();
            await client.SetDeviceStateAsync(light.Id, !light.On);
                            
            await tcs.Task.WaitAsync(TimeSpan.FromSeconds(5));

        }
    }
}