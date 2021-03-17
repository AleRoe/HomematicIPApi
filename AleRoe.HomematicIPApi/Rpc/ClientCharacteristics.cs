using System.Globalization;
using AleRoe.HomematicIpApi.Json;
using Newtonsoft.Json;

namespace AleRoe.HomematicIpApi.Rpc
{
    public class ClientCharacteristics
    {
        [JsonProperty("apiVersion")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long ApiVersion { get; set; } = 10;

        [JsonProperty("applicationIdentifier")]
        public string ApplicationIdentifier { get; set; } = "HomeController";

        [JsonProperty("applicationVersion")] 
        public string ApplicationVersion { get; set; } = "1.0";

        [JsonProperty("deviceManufacturer")] 
        public string DeviceManufacturer { get; set; } = "none";

        [JsonProperty("deviceType")] 
        public string DeviceType { get; set; } = "Computer";

        [JsonProperty("language")] 
        public string Language { get; set; } = CultureInfo.CurrentCulture.Name;

        [JsonProperty("osType")] 
        public string OsType { get; set; } = "Windows";

        [JsonProperty("osVersion")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long OsVersion { get; set; } = 7;
    }
}