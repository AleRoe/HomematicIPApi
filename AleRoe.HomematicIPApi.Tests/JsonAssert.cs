using System;
using JsonDiffPatchDotNet;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using NUnit.Framework;

namespace AleRoe.HomematicIpApi.Tests
{
    public static class JsonAssert
    {

        public static JsonSerializerSettings AddConverter(this JsonSerializerSettings settings, JsonConverter converter)
        {
            settings.Converters.Add(converter);
            return settings;
        }

        public static JsonSerializerSettings GetJsonSerializerSettings()
        {
            return new JsonSerializerSettings
            {
                TraceWriter = new TestContextTraceWriter(),
                MissingMemberHandling = MissingMemberHandling.Error,
                NullValueHandling = NullValueHandling.Include
            };
        }

        public static void Deserialize(string json, Type type, JsonSerializerSettings settings, out object result)
        {
            var hasErrors = false;
            settings.Error = delegate (object sender, ErrorEventArgs e)
            {
                TestContext.Out.WriteLine(e.ErrorContext.Error.ToString());
                TestContext.Out.WriteLine();
                hasErrors = true;
            };

            result = JsonConvert.DeserializeObject(json, type, settings);
            Assert.IsFalse(hasErrors, "Serialization errors occured.");
        }

        public static void Deserialize(string json, Type type, JsonConverter[] converters, out object result)
        {
            var settings = GetJsonSerializerSettings();
            foreach (var converter in converters)
            {
                settings.Converters.Add(converter);
            }

            Deserialize(json, type, settings, out result);
        }

        public static void Deserialize<T>(string json, JsonSerializerSettings settings, out T result)
        {
            Deserialize(json, typeof(T), settings, out var innerResult);
            result = (T)innerResult;
        }

        public static void Deserialize<T>(string json, JsonConverter[] converters, out T result)
        {
            Deserialize(json, typeof(T), converters, out var innerResult);
            result = (T)innerResult;

        }

        public static void Deserialize<T>(string json, out T result)
        {
            Deserialize<T>(json, GetJsonSerializerSettings(), out result);
        }

        public static void Serialize(object value, JsonSerializerSettings settings, out string result)
        {
            var hasErrors = false;
            settings.Error = delegate (object sender, ErrorEventArgs e)
            {
                TestContext.Out.WriteLine(e.ErrorContext.Error.ToString());
                TestContext.Out.WriteLine();
                hasErrors = true;
            };
            
            result = JsonConvert.SerializeObject(value, Formatting.Indented, settings);
            Assert.IsFalse(hasErrors, "Serialization errors occured.");
        }

        public static void Serialize(object value, out string result)
        {
            Serialize(value, GetJsonSerializerSettings(), out result);
        }

        public static void AreDeepEqual(JToken left, JToken right)
        {
            if (!JToken.DeepEquals(left, right))
            {
                var jdp = new JsonDiffPatch();
                var diff = jdp.Diff(left, right);
                TestContext.Out.WriteLine(diff.ToString());

                TestContext.Out.WriteLine(left.ToString());

                //var formatter = new JsonDeltaFormatter();
                //var operations = formatter.Format(diff);
                //operations.ToList().ForEach(x => TestContext.Out.WriteLine(x));

                Assert.Fail("Values do not match.");
            }

            Assert.Pass();
        }

        public static void AreDeepEqual(string left, string right)
        {
            AreDeepEqual(JToken.Parse(left), JToken.Parse(right));
        }
    }
}
