using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AleRoe.HomematicIpApi;
using AleRoe.HomematicIpApi.Model.Devices;
using AleRoe.HomematicIpApi.Model.Groups;
using AleRoe.HomematicIpApi.Rpc;

namespace AleRoe.HomematicIPApi.Tests
{
    [TestFixture()]
    [NonParallelizable]
    public class HomematicClientTests
    {
        private string accessPoint = "3014F711A00003D709B034F7";
        private string authToken = "F321A85FF95C4BB213B20DC0E005EAC6F649CB14A73A4A382335FB3CCB4DC3C8";

        [Test()]
        public void CtorTest_Success()
        {
            Assert.DoesNotThrow(() =>
            {
                using var client = new HomematicIpClient(accessPoint, authToken);
            });
        }

        [Test()]
        public void CtorTest_Fail()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                using var client = new HomematicIpClient("", "");
            });
        }

        [Test()]
        public void InitializeAsyncTest_Success()
        {
            using var client = new HomematicIpClient(accessPoint, authToken);
            Assert.DoesNotThrowAsync( async () => await client.Initialize());
            
        }

        [Test()]
        public async Task GetDevicesAsyncTest_ServiceProviderIsSet()
        {
            using var client = new HomematicIpClient(accessPoint, authToken);
            await client.Initialize();
            var result = await client.Service.GetDevicesAsync(CancellationToken.None);
            Assert.IsTrue(result.All(x => x.Service != null));

        }

        [Test()]
        public async Task GetGroupsAsyncTest_ServiceProviderIsSet()
        {
            using HomematicIpClient client = new HomematicIpClient(accessPoint, authToken);
            await client.Initialize();
            var result = await client.Service.GetGroupsAsync(CancellationToken.None);
            Assert.IsTrue(result.All(x => x.Service != null));

        }

        //[Test()]
        public void InitializeAsyncTest_RunTwiceFails()
        {
            using var client = new HomematicIpClient(accessPoint, authToken);
            Assert.DoesNotThrowAsync(() => client.Initialize());
            Assert.ThrowsAsync<InvalidOperationException>(() => client.Initialize());
        }

        [Test()]
        public void GetDevicesAsyncTest_Success()
        {
            IEnumerable<IDevice> result = default;
            var hasError = false;
            using var client = new HomematicIpClient(accessPoint, authToken);
            client.SerializerError += (s, e) =>
            {
                TestContext.Out.WriteLine(e.ErrorContext.Error.ToString());
                TestContext.Out.WriteLine();
                hasError = true;
            };
            
            Assert.DoesNotThrowAsync(async () => await client.Initialize());
            Assert.DoesNotThrowAsync(async () => result = await client.Service.GetDevicesAsync(CancellationToken.None));
            CollectionAssert.IsNotEmpty(result);
            Assert.IsFalse(hasError);
        }

        [Test()]
        public void GetGroupsAsyncTest_Success()
        {
            IEnumerable<IGroup> result = default;
            var hasError = false;
            using var client = new HomematicIpClient(accessPoint, authToken);
            client.SerializerError += (s, e) =>
            {
                TestContext.Out.WriteLine(e.ErrorContext.Error.ToString());
                TestContext.Out.WriteLine();
                hasError = true;
            };

            Assert.DoesNotThrowAsync(async () => await client.Initialize());
            Assert.DoesNotThrowAsync(async () => result = await client.Service.GetGroupsAsync(CancellationToken.None));
            CollectionAssert.IsNotEmpty(result);
            Assert.IsFalse(hasError);
        }

        [Test()]
        public void GetCurrentStateAsyncTest_Success()
        {
            CurrentState result = default;
            var hasError = false;
            using var client = new HomematicIpClient(accessPoint, authToken);
            client.SerializerError += (s, e) =>
            {
                TestContext.Out.WriteLine(e.ErrorContext.Error.ToString());
                TestContext.Out.WriteLine();
                hasError = true;
            };

            Assert.DoesNotThrowAsync(async () => await client.Initialize());
            Assert.DoesNotThrowAsync(async () => result = await client.Service.GetCurrentStateAsync());
            Assert.IsNotNull(result);
            Assert.IsFalse(hasError);

        }

        [Test()]
        public void GetDevicesAsyncTest_FailIfNotInitialized()
        {
            using var client = new HomematicIpClient(accessPoint, authToken);
            Assert.ThrowsAsync<InvalidOperationException>(async () =>
                await client.Service.GetDevicesAsync(CancellationToken.None));
            
        }

        [Test()]
        public async Task InitializeAsyncTest_RaisesEvents()
        {
            var tcs = new TaskCompletionSource<PushEventArgs>();
            
            using var client = new HomematicIpClient(accessPoint, authToken);
            client.SerializerError += (s, e) =>
            {
                TestContext.Out.WriteLine(e.ErrorContext.Error.ToString());
                TestContext.Out.WriteLine();
            };
            client.StateChanged += (s, e) => { tcs.SetResult(e);};
            
            await client.Initialize();

            var result = await client.Service.GetDevicesAsync(CancellationToken.None);
            var light = result.OfType<SwitchDeviceBase>().First();

            await client.Service.SetDeviceStateAsync(light.Id, !light.On);

            tcs.Task.Wait(5000);
            
            Assert.IsTrue(tcs.Task.IsCompleted);
            
        }
    }
}