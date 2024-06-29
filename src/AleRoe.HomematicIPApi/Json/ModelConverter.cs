using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Diagnostics.CodeAnalysis;

namespace AleRoe.HomematicIpApi.Json
{
    /// <inheritdoc/>
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="Newtonsoft.Json.JsonConverter{T}" />
    internal abstract class ModelConverter<T> : JsonConverter<T>
    {
        /// <inheritdoc/>
        public override T ReadJson(JsonReader reader, Type objectType, [AllowNull] T existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if (Activator.CreateInstance(objectType) is T result)
            {
                serializer.Populate(reader, result);
                return result;
            }
            throw new JsonReaderException($"Could not create object of type {objectType}");
        }

        /// <inheritdoc/>
        public override void WriteJson(JsonWriter writer, [AllowNull] T value, JsonSerializer serializer)
        {
            var contract = (JsonObjectContract)serializer.ContractResolver.ResolveContract(value.GetType());

            writer.WriteStartObject();
            foreach (var property in contract.Properties)
            {
                if (property.Ignored) continue;

                var propertyName = property.PropertyName;
                var propertyValue = property.ValueProvider.GetValue(value) ?? property.DefaultValue;

                if (propertyValue == null & (property.NullValueHandling == NullValueHandling.Ignore || serializer.NullValueHandling == NullValueHandling.Ignore))
                {
                    continue;
                }

                writer.WritePropertyName(propertyName);

                if (property.Converter != null && property.Converter.CanWrite)
                {
                    property.Converter.WriteJson(writer, propertyValue, serializer);
                }
                else
                {
                    serializer.Serialize(writer, propertyValue);
                }
            }
            writer.WriteEndObject();
        }
    }
}
