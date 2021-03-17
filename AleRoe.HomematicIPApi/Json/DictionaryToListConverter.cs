using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AleRoe.HomematicIpApi.Json
{
    /// <summary>
    /// A <see cref="Newtonsoft.Json.JsonConverter{T}"/> class to convert a JSON dictionary to a s<see cref="List{T}"/>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="Newtonsoft.Json.JsonConverter{T}" />
    internal class DictionaryToListConverter<T> : JsonConverter<List<T>>
    {
        private readonly string key;

        public DictionaryToListConverter()
        {
            var attr = typeof(T).GetCustomAttribute<DictionaryToListConverterKeyAttribute>();
            if (attr != null) this.key = attr.Value;
        }

        public DictionaryToListConverter(string key)
        {
            this.key = key;
        }

        /// <inheritdoc/>
        public override List<T> ReadJson(JsonReader reader, Type objectType, List<T> existingValue,
            bool hasExistingValue, JsonSerializer serializer)
        {
            var result = new List<T>();
            var tokens = JObject.Load(reader).Children();
            foreach (var token in tokens)
                try
                {
                    var item = token.First().ToObject<T>(serializer);
                    result.Add(item);
                }
                catch (Exception e)
                {
                    var errorMessage = e.InnerException?.Message ?? e.Message;
                    serializer.TraceWriter?.Trace(TraceLevel.Error,
                        $"Error deserializing collection item {typeof(T).Name}. \r{errorMessage}\rItem will be skipped.",
                        e);
                }

            return result;
        }

        /// <inheritdoc/>
        public override void WriteJson(JsonWriter writer, List<T> value, JsonSerializer serializer)
        {
            if (key is null)
                throw new ArgumentNullException(nameof(key), "No key defined for collection items.");
            
            var propInfo = typeof(T).GetProperty(key) ?? throw new ArgumentException($"The property '{key}' does not exist on item '{typeof(T).Name}'.");
            writer.WriteStartObject();
            foreach (var item in value)
            {
                var propName = propInfo.GetValue(item).ToString();
                writer.WritePropertyName(propName);
                serializer.Serialize(writer, item);
            }

            writer.WriteEndObject();
        }
    }
}