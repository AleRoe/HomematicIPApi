﻿using AleRoe.HomematicIpApi.Model.Groups;
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
            if (reader.TokenType == JsonToken.Null)
                return null;

            var jsonObject = JObject.Load(reader);
            var groupType = jsonObject.SelectToken("type")?.ToObject<GroupType>();
            if (groupType == null)
                throw new InvalidOperationException($"Could not find GroupType.");

            var type = this.GetType().Assembly.GetTypes()
                .Where(t => typeof(IGroup).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract)
                .SingleOrDefault(t => t.GetCustomAttribute<GroupTypeAttribute>()?.GroupType == groupType);

            if (type == null)
                throw new InvalidOperationException($"Could not find Group with type {groupType}");

            if (Activator.CreateInstance(type) is IGroup result)
            {
                serializer.Populate(jsonObject.CreateReader(), result);
                return result;
            }
            throw new InvalidOperationException($"Could not create Group with type {type}");
        }
    }
}