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
            var clientType = jsonObject.SelectToken("clientType")?.ToObject<ClientType>();
            if (clientType == null)
                throw new InvalidOperationException($"Could not find ClientType.");

            var type = this.GetType().Assembly.GetTypes()
                .Where(t => typeof(IClient).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract)
                .SingleOrDefault(t => t.GetCustomAttribute<ClientTypeAttribute>()?.ClientType == clientType);

            if (type == null)
                throw new InvalidOperationException($"Could not find Client with type {clientType}.");

            if (Activator.CreateInstance(type) is IClient result)
            {
                serializer.Populate(jsonObject.CreateReader(), result);
                return result;
            }
            throw new InvalidOperationException($"Could not create Client with type {type}");
        }
    }
}
