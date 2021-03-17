using AleRoe.HomematicIpApi.Model.Channels;
using AleRoe.HomematicIpApi.Tests;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;

namespace AleRoe.HomematicIpApi.Json.Tests
{
    [TestFixture()]
    public class DictionaryToListConverterTests
    {
        private static IEnumerable<TestCaseData> AddCases()
        {
            string path = @"TestData\DictionaryToListConverter";
            var files = Directory.GetFiles(path, "*.json");
            foreach (var file in files)
            {
                //var typeName = $"AleRoe.HomematicIpApi.Model.Channels.{Path.GetFileNameWithoutExtension(file)}";

                //var type = typeof(FunctionalChannelConverter).Assembly.GetType(typeName, true);
                var type = typeof(List<IFunctionalChannel>);
                yield return new TestCaseData(file, type);
            }
        }

        [Test, TestCaseSource(nameof(AddCases))]
        public void TestConversion(string filePath, Type type)
        {
            var json = File.ReadAllText(filePath);
            var settings = JsonAssert.GetJsonSerializerSettings()
                .AddConverter(new DictionaryToListConverter<IFunctionalChannel>());

            JsonAssert.Deserialize(json, type, settings, out var result);
            JsonAssert.Serialize(result, settings, out var jsonResult);
            JsonAssert.AreDeepEqual(json, jsonResult);
        }
    }
}