using System;
using Newtonsoft.Json;

namespace AleRoe.HomematicIpApi.Json
{
    internal class ParseStringConverter : JsonConverter<long>
    {
        public override void WriteJson(JsonWriter writer, long value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value.ToString());
        }

        public override long ReadJson(JsonReader reader, Type objectType, long existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return 0;
            var value = serializer.Deserialize<string>(reader);

            if (long.TryParse(value, out var result)) return result;
            throw new Exception("Cannot unmarshal type long");
        }
    }
}