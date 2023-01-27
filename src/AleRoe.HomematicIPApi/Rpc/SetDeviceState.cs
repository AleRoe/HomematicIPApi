using Newtonsoft.Json;

namespace AleRoe.HomematicIpApi.Rpc
{
    public class SetDeviceState
    {
        public SetDeviceState(string deviceId, bool on, int channelIndex = 1)
        {
            DeviceId = deviceId;
            On = on;
            ChannelIndex = channelIndex;
        }

        [JsonProperty("channelIndex")] 
        public int ChannelIndex { get; set; }

        [JsonProperty("deviceId")] 
        public string DeviceId { get; set; }

        [JsonProperty("on")] 
        public bool On { get; set; }
    }
}