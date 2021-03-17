using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
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
        public override void WriteJson(JsonWriter writer, [AllowNull] T value, JsonSerializer serializer)
        {
            var contract = (JsonObjectContract)serializer.ContractResolver.ResolveContract(value.GetType());

            writer.WriteStartObject();
            foreach (var property in contract.Properties)
            {
                if (property.Ignored) continue;

                var propertyName = property.PropertyName;
                var propertyValue = property.ValueProvider.GetValue(value) ?? property.DefaultValue;
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
