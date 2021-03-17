using AleRoe.HomematicIpApi.Model.Devices;
using Newtonsoft.Json;

namespace AleRoe.HomematicIpApi.Rpc
{
    public class DeviceEvent : Event
    {
        [JsonProperty("device")] 
        public IDevice Device { get; set; }

        public override string ToString()
        {
            return $"{Device.Label}";
        }
    }
}