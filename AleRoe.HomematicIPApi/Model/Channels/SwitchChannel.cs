using Newtonsoft.Json;

namespace AleRoe.HomematicIpApi.Model.Channels
{
    [FunctionalChannelType(FunctionalChannelType.SWITCH_CHANNEL)]
    public class SwitchChannel : FunctionalChannel
    {
        [JsonProperty("on", NullValueHandling = NullValueHandling.Ignore)] 
        public bool On { get; private set; }

        [JsonProperty("profileMode")] 
        public string ProfileMode { get; private set; }

        [JsonProperty("userDesiredProfileMode")]
        public string UserDesiredProfileMode { get; private set; }
    }
}