using AleRoe.HomematicIpApi.Model.Channels;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;

namespace AleRoe.HomematicIpApi.Tests.Json
{
    [TestFixture()]
    public class FunctionalChannelConverterTests
    {
        private static IEnumerable<TestCaseData> AddCases()
        {
            string path = @"TestData\\FunctionalChannelConverter";
            var files = Directory.GetFiles(path, "*.json");
            foreach (var file in files)
            {
                var typeName = $"AleRoe.HomematicIpApi.Model.Channels.{Path.GetFileNameWithoutExtension(file)}";

                var type = typeof(IFunctionalChannel).Assembly.GetType(typeName, true);
                yield return new TestCaseData(file, type);
            }
        }

        [Test, TestCaseSource(nameof(AddCases))]
        public void TestConversion(string filePath, Type type)
        {
            var json = File.ReadAllText(filePath);
            
            JsonAssert.Deserialize<IFunctionalChannel>(json, out var result);
            
            Assert.IsInstanceOf(type, result);

            JsonAssert.Serialize(result, out var jsonResult);
            JsonAssert.AreDeepEqual(json, jsonResult);
        }
    }
}