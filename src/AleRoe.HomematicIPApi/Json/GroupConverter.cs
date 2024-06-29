using AleRoe.HomematicIpApi.Model.Groups;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using AleRoe.HomematicIpApi.Model;

namespace AleRoe.HomematicIpApi.Json
{
    /// <summary>
    /// A <see cref="JsonConverter{T}"/> class used to deserialize group definitions.
    /// </summary>
    /// <remarks>
    /// This converter relies on the group classes being decorated with <see cref="GroupTypeAttribute"/> attribute in order to instantiate the concrete type.
    /// </remarks>
    /// <seealso cref="Newtonsoft.Json.JsonConverter{IGroup}" />
    /// <inheritdoc/>
    internal class GroupConverter : ModelConverter<IGroup>
    {
        /// <inheritdoc/>
        public override IGroup ReadJson(JsonReader reader, Type objectType, [AllowNull] IGroup existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;

            var jsonObject = JObject.Load(reader);
            var groupType = jsonObject.SelectToken("type",true).ToObject<GroupType>(serializer);
            var type = this.GetType().Assembly.GetTypes()
                .Where(t => typeof(IGroup).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract)
                .SingleOrDefault(t => t.GetCustomAttribute<GroupTypeAttribute>()?.GroupType == groupType)
                ?? throw new JsonReaderException($"Could not find Group with type {groupType}");

            return base.ReadJson(jsonObject.CreateReader(), type, existingValue, hasExistingValue, serializer);
        }
    }
}