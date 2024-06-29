using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using AleRoe.HomematicIpApi.Model;
using AleRoe.HomematicIpApi.Model.Devices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AleRoe.HomematicIpApi.Json
{
    /// <summary>
    /// A <see cref="JsonConverter{T}"/> class used to deserialize device definitions.
    /// </summary>
    /// <remarks>
    /// This converter relies on the device classes being decorated with <see cref="DeviceTypeAttribute"/> attribute in order to instantiate the concrete device type.
    /// </remarks>
    /// <seealso cref="Newtonsoft.Json.JsonConverter{IDevice}" />
    /// <inheritdoc/>
    internal class DeviceConverter : ModelConverter<IDevice>
    {
        /// <inheritdoc/>
        public override IDevice ReadJson(JsonReader reader, Type objectType, [AllowNull] IDevice existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;

            var jsonObject = JObject.Load(reader);
            var deviceType = jsonObject.SelectToken("type",true).ToObject<DeviceType>(serializer);
            var type = this.GetType().Assembly.GetTypes()
                .Where(t => typeof(IDevice).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract)
                .SingleOrDefault(t => t.GetCustomAttribute<DeviceTypeAttribute>()?.DeviceType == deviceType) 
                ?? throw new JsonReaderException($"Could not find Device with type {deviceType}.");
            
            return base.ReadJson(jsonObject.CreateReader(), type, existingValue, hasExistingValue, serializer);
        }
    }
}
