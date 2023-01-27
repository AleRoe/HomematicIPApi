using System;
using System.Globalization;
using AleRoe.HomematicIpApi.Json;
using Newtonsoft.Json;

namespace AleRoe.HomematicIpApi.Rpc
{
    public class ClientCharacteristics
    {
        [JsonProperty("apiVersion")]
        public string ApiVersion => "10";

        [JsonProperty("applicationIdentifier")]
        public string ApplicationIdentifier { get; set; } = "AleRoe.HomematicIpApi";

        [JsonProperty("applicationVersion")] 
        public string ApplicationVersion { get; set; } = "1.0";

        [JsonProperty("deviceManufacturer")] 
        public string DeviceManufacturer { get; set; } = "none";

        [JsonProperty("deviceType")]
        public ClientDeviceType DeviceType { get; set; } = ClientDeviceType.Computer;

        [JsonProperty("language")]
        public string Language => CultureInfo.CurrentCulture.Name;

        [JsonProperty("osType")]
        public string OsType => Environment.OSVersion.Platform.ToString();

        [JsonProperty("osVersion")]
        public string OsVersion => Environment.OSVersion.Version.ToString();

        public override string ToString() => $"API: {ApiVersion} / OS Type: {OsType} / OS Version: {OsVersion} / Language: {Language} / Device Type: {DeviceType}";
    }
}