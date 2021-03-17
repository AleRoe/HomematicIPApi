using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace AleRoe.HomematicIpApi.Json
{
    internal class UnixTimestampConverter : DateTimeConverterBase
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value is DateTime dateTime)
            {
                if (dateTime.Year >= 1970)
                {
                    var offset = new DateTimeOffset(dateTime);
                    writer.WriteRawValue(offset.ToUnixTimeMilliseconds().ToString());
                }
                else
                {
                    writer.WriteNull();
                }
            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var offset = DateTimeOffset.FromUnixTimeMilliseconds((long) reader.Value);
            return offset.UtcDateTime;
        }
    }
}