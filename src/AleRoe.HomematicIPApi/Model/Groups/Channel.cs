using Newtonsoft.Json;

namespace AleRoe.HomematicIpApi.Model.Groups
{
    public class Channel
    {
        [JsonProperty("deviceId")] 
        public string Guid { get; set; }

        [JsonProperty("channelIndex")] 
        public long ChannelIndex { get; set; }
    }
}