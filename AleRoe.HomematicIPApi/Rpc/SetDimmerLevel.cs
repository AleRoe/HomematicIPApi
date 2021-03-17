using Newtonsoft.Json;

namespace AleRoe.HomematicIpApi.Rpc
{
    public class SetDimmerLevel
    {
        public SetDimmerLevel(string deviceId, double dimLevel = 0.0, int channelIndex = 1)
        {
            DeviceId = deviceId;
            DimLevel = dimLevel;
            ChannelIndex = channelIndex;
        }

        [JsonProperty("channelIndex")] 
        public int ChannelIndex { get; set; }

        [JsonProperty("deviceId")] 
        public string DeviceId { get; set; }

        [JsonProperty("dimLevel")] 
        public double DimLevel { get; set; }
    }
}