using NUnit.Framework;
using AleRoe.HomematicIPApi.Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using AleRoe.HomematicIPApi.Model;
using System.Threading.Tasks;
using System.Linq;

namespace AleRoe.HomematicIPApi.Extensions.Tests
{
    [TestFixture()]
    public class FunctionalChannelExtensionsTests
    {
        private string accessPoint = "3014F711A00003D709B034F7";
        private string authToken = "F321A85FF95C4BB213B20DC0E005EAC6F649CB14A73A4A382335FB3CCB4DC3C8";

        [Test()]
        public async Task IsLightAndShadowTest()
        {
            var client = new HomematicClient(accessPoint, authToken);

            await client.InitializeAsync();
            var result = await client.GetDevicesAsync(CancellationToken.None);

            var lights = result.Where(x => x.IsLightAndShadow());
            Assert.AreEqual(3, lights.Count());
        }
    }
}