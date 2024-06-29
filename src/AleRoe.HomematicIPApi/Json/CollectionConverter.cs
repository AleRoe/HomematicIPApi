using AleRoe.HomematicIpApi.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace AleRoe.HomematicIpApi.Json
{
    /// <summary>
    /// A <see cref="JsonConverter{TCollection}"/> class used to deserialize collection definitions.
    /// </summary>
    /// <typeparam name="TCollection"> The type of collection to deserialize.</typeparam>
    /// <typeparam name="TItem">The type of collection item.</typeparam>
    internal class CollectionConverter<TCollection, TItem> : JsonConverter<TCollection> where TCollection : IModelCollection<TItem>, new()
    {
        public override TCollection ReadJson(JsonReader reader, Type objectType, [AllowNull] TCollection existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var result = new TCollection();
            var tokens = JObject.Load(reader).Children();
            foreach (var token in tokens)
                try
                {
                    var item = token.First().ToObject<TItem>(serializer);
                    result.Add(item);
                }
                catch (Exception e)
                {
                    var message = $"Error deserializing {typeof(TCollection).FullName}. {e.InnerException?.Message ?? e.Message} - Item will be skipped.";
                    serializer.TraceWriter?.Trace(TraceLevel.Error, message, e);
                }

            return result;
        }

        public override void WriteJson(JsonWriter writer, [AllowNull] TCollection value, JsonSerializer serializer)
        {
            writer.WriteStartObject();
            foreach (var item in value)
            {
                writer.WritePropertyName(value.GetKeyValue(item));
                serializer.Serialize(writer, item);
            }
            writer.WriteEndObject();
        }
    }
}