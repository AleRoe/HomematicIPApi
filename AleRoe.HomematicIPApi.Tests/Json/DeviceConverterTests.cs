using NUnit.Framework;
using AleRoe.HomematicIpApi.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using AleRoe.HomematicIpApi.Model.Channels;
using AleRoe.HomematicIpApi.Model.Devices;
using AleRoe.HomematicIpApi.Tests;

namespace AleRoe.HomematicIpApi.Json.Tests
{
    [TestFixture()]
    public class DeviceConverterTests
    {

        private static IEnumerable<TestCaseData> AddCases()
        {
            string path = @"TestData\DeviceConverter";
            var files = Directory.GetFiles(path, "*.json");
            foreach (var file in files)
            {
                var typeName = $"AleRoe.HomematicIpApi.Model.Devices.{Path.GetFileNameWithoutExtension(file)}";

                var type = typeof(IFunctionalChannel).Assembly.GetType(typeName, true);
                yield return new TestCaseData(file, type);
            }
        }


        [Test, TestCaseSource(nameof(AddCases))]
        public void TestConversion(string filePath, Type type)
        {
            var json = File.ReadAllText(filePath);

            JsonAssert.Deserialize<IDevice>(json, out var result);

            Assert.IsInstanceOf(type, result);

            JsonAssert.Serialize(result, out var jsonResult);
            JsonAssert.AreDeepEqual(jsonResult, json);
        }
    }
}