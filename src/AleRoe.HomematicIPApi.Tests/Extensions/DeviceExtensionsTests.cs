using NUnit.Framework;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AleRoe.HomematicIpApi.Extensions;
using AleRoe.HomematicIpApi.Model.Devices;

namespace AleRoe.HomematicIpApi.Tests.Extensions
{
    [TestFixture()]
    public class DeviceExtensionsTests : HomematicClientTestsBase
    {

        //[Test()]
        //public async Task IsLightAndShadowTest()
        //{
        //    var config = new HomematicIpConfiguration() { AccessPointId = accessPoint, AuthToken = authToken };
        //    using var client = new HomematicIpClient(config);
            
        //    await client.Initialize(CancellationToken.None);
        //    var result = await client.GetDevicesAsync(CancellationToken.None);
        //    var light = result.OfType<SwitchDeviceBase>().First();
            
        //    Assert.IsTrue(light.IsLightAndShadow());
        //}

        [Test()]
        public async Task ToggleOnTest()
        {
            var config = new HomematicIpConfiguration() { AccessPointId = AccessPoint, AuthToken = AuthToken };
            using var client = new HomematicIpClient(config);

            await client.InitializeAsync(CancellationToken.None);
            var result = await client.GetDevicesAsync(CancellationToken.None);
            var light = result.OfType<SwitchDeviceBase>().First();
            //await Task.Delay(1000);
            await light.ToggleStateAsync();
            var expected = await client.GetDeviceAsync<SwitchDeviceBase>(light.Id);

            Assert.AreEqual(light.Id, expected.Id);
            Assert.AreNotEqual(light.On, expected.On);
        }
    }
}