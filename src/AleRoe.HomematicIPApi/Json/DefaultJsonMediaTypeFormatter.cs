using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AleRoe.HomematicIpApi.Json
{
    /// <summary>
    /// A <see cref="MediaTypeFormatter"/> class to handle JSON using custom <see cref="JsonSerializerSettings"/>.
    /// </summary>
    /// <seealso cref="System.Net.Http.Formatting.JsonMediaTypeFormatter" />
    internal class DefaultJsonMediaTypeFormatter : JsonMediaTypeFormatter
    {
        private readonly JsonSerializerSettings settings;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultJsonMediaTypeFormatter"/> class.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <exception cref="ArgumentNullException">settings</exception>
        public DefaultJsonMediaTypeFormatter(JsonSerializerSettings settings)
        {
            this.settings = settings ?? throw new ArgumentNullException(nameof(settings));
        }

        public override JsonSerializer CreateJsonSerializer()
        {
            return JsonSerializer.CreateDefault(settings);
        }
        public override Task<object> ReadFromStreamAsync(Type type, Stream readStream, HttpContent content, IFormatterLogger formatterLogger, CancellationToken cancellationToken)
        {
#if DEBUG
            Dump(readStream);
#endif
            return base.ReadFromStreamAsync(type, readStream, content, formatterLogger, cancellationToken);
        }

        private void Dump(Stream stream)
        {
            using (var reader = new StreamReader(stream, null, true, -1, true))
            {
                var dump = reader.ReadToEnd();
                var tempFile = GetTempFile();
                File.WriteAllText(tempFile, dump);
                Debug.Print("Debug dump at: " + tempFile);
            }
            stream.Seek(0, SeekOrigin.Begin);
        }

        private string GetTempFile()
        {
            var path = Path.GetTempPath();
            var fileName = $"HomematicIpDump_{Guid.NewGuid()}.json";
            return Path.Combine(path, fileName);
        }
    }
}