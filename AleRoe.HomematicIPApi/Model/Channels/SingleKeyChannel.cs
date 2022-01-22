using Newtonsoft.Json;

namespace AleRoe.HomematicIpApi.Model.Channels
{
    [FunctionalChannelType(FunctionalChannelType.SINGLE_KEY_CHANNEL)]
    public class SingleKeyChannel : FunctionalChannel
    {
        [JsonProperty("visibleChannelIndex")]
        public int VisibleChannelIndex { get; private set; }

    }
}