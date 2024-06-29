using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using AleRoe.HomematicIpApi.Extensions;
using AleRoe.HomematicIpApi.Model;
using AleRoe.HomematicIpApi.Model.Channels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AleRoe.HomematicIpApi.Json
{
    internal class FunctionalChannelConverter : ModelConverter<IFunctionalChannel>
    {
        public override IFunctionalChannel ReadJson(JsonReader reader, Type objectType, [AllowNull] IFunctionalChannel existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;

            var jsonObject = JObject.Load(reader);
            var channelType = jsonObject.SelectToken("functionalChannelType", true).ToObject<FunctionalChannelType>(serializer);
            var type = this.GetType().Assembly.GetTypesWithInterface<IFunctionalChannel>()
                  .SingleOrDefault(t => t.GetCustomAttribute<FunctionalChannelTypeAttribute>()?.FunctionalChannelType == channelType)
                  ?? throw new JsonReaderException($"Could not find Channel with type {channelType}");
            
            return base.ReadJson(jsonObject.CreateReader(), type, existingValue, hasExistingValue, serializer);
            
        }
    }
}
