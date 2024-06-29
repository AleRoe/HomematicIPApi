using AleRoe.HomematicIpApi.Model;
using AleRoe.HomematicIpApi.Model.Client;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Reflection;

namespace AleRoe.HomematicIpApi.Json
{
    /// <summary>
    /// A <see cref="JsonConverter{T}"/> class used to deserialize client definitions.
    /// </summary>
    /// <remarks>
    /// This converter relies on the client classes being decorated with <see cref="ClientTypeAttribute"/> attribute in order to instantiate the concrete type.
    /// </remarks>
    /// <seealso cref="Newtonsoft.Json.JsonConverter{IClient}" />
    /// <inheritdoc/>
    internal class ClientConverter : ModelConverter<IClient>
    {
        /// <inheritdoc/>
        public override IClient ReadJson(JsonReader reader, Type objectType, IClient existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var jsonObject = JObject.Load(reader);
            var clientType = jsonObject.SelectToken("clientType", true).ToObject<ClientType>(serializer);
            var type = this.GetType().Assembly.GetTypes()
                .Where(t => typeof(IClient).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract)
                .SingleOrDefault(t => t.GetCustomAttribute<ClientTypeAttribute>()?.ClientType == clientType)
                ?? throw new JsonReaderException($"Could not find Client with type {clientType}.");

            return base.ReadJson(jsonObject.CreateReader(), type, existingValue, hasExistingValue, serializer);
        }
    }
}
