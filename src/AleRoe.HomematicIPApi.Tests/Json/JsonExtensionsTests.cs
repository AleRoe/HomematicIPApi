using AleRoe.HomematicIpApi.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System.IO;
using System.Text;

namespace AleRoe.HomematicIpApi.Tests.Json
{

    [TestFixture()]
    public class JsonExtensionsTests
    {
        [Test()]
        public void DeserializeByteArryTest()
        {
            var test = new TestClass();
            var json = JsonConvert.SerializeObject(test);
            var bytes = Encoding.UTF8.GetBytes(json);

            var result = bytes.Deserialize<TestClass>();
            JsonAssert.AreDeepEqual(JToken.FromObject(test), JToken.FromObject(result));
        }

        [Test()]
        public void DeserializeStreamTest()
        {
            var test = new TestClass();
            var json = JsonConvert.SerializeObject(test);
            var bytes = Encoding.UTF8.GetBytes(json);
            using var stream = new MemoryStream();
            stream.Write(bytes);
            
            var result = stream.Deserialize<TestClass>();
            JsonAssert.AreDeepEqual(JToken.FromObject(test), JToken.FromObject(result));

            Assert.That(stream.CanRead, Is.False);

        }

        [Test()]
        public void DeserializeStreamLeaveOpenTest()
        {
            var test = new TestClass();
            var json = JsonConvert.SerializeObject(test);
            var bytes = Encoding.UTF8.GetBytes(json);
            using var stream = new MemoryStream();
            stream.Write(bytes);

            var result = stream.Deserialize<TestClass>(leaveOpen: true);
            JsonAssert.AreDeepEqual(JToken.FromObject(test), JToken.FromObject(result));

            Assert.That(stream.CanRead, Is.True);

        }

        internal class TestClass
        { 
            public TestClass() 
            {
                Name = "SomeName";
                Value = "SomeValue";    
            }
            
            [JsonProperty("name")]
            public string Name { get; private set; }
            
            [JsonProperty("value")]
            public string Value { get; private set; }
        }
    }

    
}
