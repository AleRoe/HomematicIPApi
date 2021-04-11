using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
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
            var jsonObject = JObject.Load(reader);
            var deviceType = jsonObject.SelectToken("type")?.ToObject<DeviceType>();
            if (deviceType == null)
                throw new InvalidOperationException($"Could not find DeviceType.");

            var type = this.GetType().Assembly.GetTypes()
                .Where(t => typeof(IDevice).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract)
                .SingleOrDefault(t => t.GetCustomAttribute<DeviceTypeAttribute>()?.DeviceType == deviceType);

            if (type == null)
                throw new InvalidOperationException($"Could not find Device with type {deviceType}.");

            if (Activator.CreateInstance(type) is IDevice result)
            {
                serializer.Populate(jsonObject.CreateReader(), result);
                return result;
            }
            throw new InvalidOperationException($"Could not create Device with type {type}");
        }
    }
}
