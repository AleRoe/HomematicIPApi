using Newtonsoft.Json;

namespace AleRoe.HomematicIpApi.Model.Channels
{
    [FunctionalChannelType(FunctionalChannelType.SINGLE_KEY_CHANNEL)]
    public class SingleKeyChannel : FunctionalChannel
    {
        [JsonProperty("visibleChannelIndex")]
        public int VisibleChannelIndex { get; private set; }

        [JsonProperty("doorBellSensorEventTimestamp")]
        public object DoorBellSensorEventTimestamp { get; private set; }

        [JsonProperty("acousticSendStateEnabled")]
        public bool AcousticSendStateEnabled { get; private set; }

        [JsonProperty("doublePressTime")]
        public double DoublePressTime { get; private set; }

        [JsonProperty("actionParameter")]
        public ActionParameter ActionParameter { get; private set; }

        [JsonProperty("channelRole")]
        public ChannelRole? ChannelRole { get; private set; }
    }
}