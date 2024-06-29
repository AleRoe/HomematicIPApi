using Newtonsoft.Json;

namespace AleRoe.HomematicIpApi.Model.Devices
{
    [DeviceType(DeviceType.EXTERNAL)]
    public class ExternalDevice : Device
    {
        [JsonProperty("externalService")]
        public string ExternalService { get; private set; }

        [JsonProperty("supported")]
        public bool Supported { get; private set; }

        [JsonProperty("hasCustomLabel")]
        public bool HasCustomLabel { get; private set; }
    }
}
