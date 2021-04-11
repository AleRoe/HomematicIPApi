using NUnit.Framework;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AleRoe.HomematicIpApi;
using AleRoe.HomematicIpApi.Extensions;
using AleRoe.HomematicIpApi.Model.Devices;

namespace AleRoe.HomematicIPApi.Tests.Extensions
{
    [TestFixture()]
    public class DeviceExtensionsTests
    {
        private string accessPoint = "3014F711A00003D709B034F7";
        private string authToken = "F321A85FF95C4BB213B20DC0E005EAC6F649CB14A73A4A382335FB3CCB4DC3C8";

        [Test()]
        public async Task IsLightAndShadowTest()
        {
            using var client = new HomematicIpClient(accessPoint, authToken);

            await client.Initialize();
            var result = await client.Service.GetDevicesAsync(CancellationToken.None);
            var light = result.OfType<SwitchDeviceBase>().First();
            
            Assert.IsTrue(light.IsLightAndShadow());
        }

        [Test()]
        public async Task ToggleOnTest()
        {
            using var client = new HomematicIpClient(accessPoint, authToken);

            await client.Initialize();
            var result = await client.Service.GetDevicesAsync(CancellationToken.None);
            var light = result.OfType<SwitchDeviceBase>().First();

            await light.ToggleStateAsync();

            var expected = await client.Service.GetDeviceAsync<SwitchDeviceBase>(light.Id);

            Assert.AreEqual(light.Id, expected.Id);
            Assert.AreNotEqual(light.On, expected.On);
        }

    }
}