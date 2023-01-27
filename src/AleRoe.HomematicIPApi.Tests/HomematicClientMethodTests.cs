using AleRoe.HomematicIpApi.Model.Devices;
using AleRoe.HomematicIpApi.Rpc;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AleRoe.HomematicIpApi.Tests
{
    [TestFixture()]
    public class HomematicClientMethodTests : HomematicClientTestsBase
    {
        private HomematicIpClient client;
        private bool hasError = false;

        [OneTimeSetUp]
        public async Task Init()
        {
            var config = new HomematicIpConfiguration() {AccessPointId = AccessPoint, AuthToken = AuthToken };
            client = new HomematicIpClient(config);

            await client.InitializeAsync(CancellationToken.None);
            
            client.OnSerializerError += (s, e) =>
            {
                TestContext.Out.WriteLine(e.ErrorContext.Error.ToString());
                TestContext.Out.WriteLine();
                hasError = true;
            };

        }

        [OneTimeTearDown]
        public void Cleanup()
        { 
            client.Dispose();
        }

        [SetUp]
        public void PreTest()
        {
            hasError = false;
        }


        [Test()]
        public async Task GetDevicesAsyncTest_ServiceProviderIsSet()
        {
            var result = await client.GetDevicesAsync(CancellationToken.None);
            Assert.IsTrue(result.All(x => x.Service != null));
            Assert.IsFalse(hasError);
        }

        [Test()]
        public async Task GetGroupsAsyncTest_ServiceProviderIsSet()
        {
            var result = await client.GetGroupsAsync(CancellationToken.None);
            Assert.IsTrue(result.All(x => x.Service != null));
            Assert.IsFalse(hasError);
        }

                
        [Test()]
        public async Task GetDevicesAsyncTest()
        {
            var result = await client.GetDevicesAsync(CancellationToken.None);
            
            CollectionAssert.IsNotEmpty(result);
            Assert.IsFalse(hasError);
        }

        [Test()]
        public async Task GetGroupsAsyncTest()
        {
            var result = await client.GetGroupsAsync(CancellationToken.None);
            CollectionAssert.IsNotEmpty(result);
            Assert.IsFalse(hasError);
        }

        [Test()]
        public async Task GetCurrentStateAsyncTest()
        {
            var result = await client.GetCurrentStateAsync(CancellationToken.None);
            
            Assert.IsNotNull(result);
            Assert.IsFalse(hasError);

        }


        [Test()]
        public async Task PushEventReceivedTest()
        {
            var tcs = new TaskCompletionSource<PushEventArgs>();
            
            using var events = client.PushEventReceived.Subscribe(msg => tcs.SetResult(msg));

            await Task.Delay(1000);
            var result = await client.GetDevicesAsync(CancellationToken.None);
            var light = result.OfType<SwitchDeviceBase>().First();
            
            await client.SetDeviceStateAsync(light.Id, !light.On);
                            
            await tcs.Task.WaitAsync(TimeSpan.FromSeconds(5));

        }
    }
}