using Newtonsoft.Json;

namespace AleRoe.HomematicIpApi.Rpc
{
    public class SetDeviceLabel
    {
        public SetDeviceLabel(string deviceId, string label)
        {
            DeviceId = deviceId;
            Label = label;
        }

        [JsonProperty("deviceId")]
        public string DeviceId { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }
    }
}