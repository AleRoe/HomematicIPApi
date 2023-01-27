using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AleRoe.HomematicIpApi.Json
{
    internal static class JsonExtensions
    {
        public static T Deserialize<T>(this byte[] data, JsonSerializerSettings settings = null) where T : class
        {
            using var stream = new MemoryStream(data);
            return stream.Deserialize<T>(settings);

        }

        public static T Deserialize<T>(this MemoryStream stream, JsonSerializerSettings settings = null, bool leaveOpen = false) where T : class
        {
            try
            {
                var serializer = (settings == null) ? JsonSerializer.CreateDefault() : JsonSerializer.CreateDefault(settings);
                stream.Seek(0, SeekOrigin.Begin);
                using (var reader = new StreamReader(stream, Encoding.UTF8, leaveOpen: leaveOpen)) 
                using (var jsonReader = new JsonTextReader(reader)) 
                    return serializer.Deserialize<T>(jsonReader);
            }
            catch (Exception e)
            {
                throw new ApplicationException($"Error deserializing {nameof(T)}", e);
            }
        }
    }
}
