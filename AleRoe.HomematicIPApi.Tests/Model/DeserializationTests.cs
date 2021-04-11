using AleRoe.HomematicIpApi.Model.Client;
using AleRoe.HomematicIpApi.Model.Devices;
using AleRoe.HomematicIpApi.Model.Groups;
using AleRoe.HomematicIpApi.Model.Home;
using AleRoe.HomematicIpApi.Rpc;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System.IO;

namespace AleRoe.HomematicIpApi.Tests.Model
{
    [TestFixture()]
    [NonParallelizable]
    [TestFixtureSource("FixtureArgs")]
    public class DeserializationTests
    {
        private readonly string json;
        public DeserializationTests(string fileName)
        {
            json = File.ReadAllText(fileName);
        }

        private static object[] FixtureArgs =
        {
            @"TestData\hmip-config_LATEST.json",
            @"TestData\hmip-config_27EE.json",
            @"TestData\hmip-config_CORE.json",
        };

        [Test()]
        public void DeserializeCurrentStateTest_Success()
        {
            var source = JToken.Parse(json).ToString();
            JsonAssert.Deserialize<CurrentState>(source, out var result);
            JsonAssert.Serialize(result, out var jsonResult);
            JsonAssert.AreDeepEqual(source, jsonResult);
        }

        [Test()]
        public void DeserializeAndCompareDevicesTest_Success()
        {
            var source = JToken.Parse(json).SelectToken("devices").ToString();
            JsonAssert.Deserialize<DeviceCollection>(source, out var result);
            JsonAssert.Serialize(result, out var jsonResult);
            JsonAssert.AreDeepEqual(source, jsonResult);
        }

        [Test()]
        public void DeserializeAndCompareHomeTest_Success()
        {
            var source = JToken.Parse(json).SelectToken("home").ToString();
            JsonAssert.Deserialize<Home>(source, out var result);
            JsonAssert.Serialize(result, out var jsonResult);
            JsonAssert.AreDeepEqual(source, jsonResult);
        }

        [Test()]
        public void DeserializeAndCompareClientsTest_Success()
        {
            var source = JToken.Parse(json).SelectToken("clients").ToString();
            JsonAssert.Deserialize<ClientCollection>(source, out var result);
            JsonAssert.Serialize(result, out var jsonResult);
            JsonAssert.AreDeepEqual(source, jsonResult);
        }

        [Test()]
        public void DeserializeAndCompareGroupsTest_Success()
        {
            var source = JToken.Parse(json).SelectToken("groups").ToString();
            JsonAssert.Deserialize<GroupCollection>(source, out var result);
            JsonAssert.Serialize(result, out var jsonResult);
            JsonAssert.AreDeepEqual(source, jsonResult);
        }

    }
}
