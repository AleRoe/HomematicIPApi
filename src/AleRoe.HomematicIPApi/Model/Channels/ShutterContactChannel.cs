using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace AleRoe.HomematicIpApi.Model.Channels
{
    [FunctionalChannelType(FunctionalChannelType.SHUTTER_CONTACT_CHANNEL)]
    public class ShutterContactChannel : FunctionalChannel
    {
        [JsonProperty("windowState")]
        [JsonConverter(typeof(StringEnumConverter))]
        public WindowState? WindowState { get; private set; }

        [JsonProperty("eventDelay")]
        public long EventDelay { get; private set; }

        [JsonProperty("channelRole")]
        public ChannelRole? ChannelRole { get; private set; }
    }
}