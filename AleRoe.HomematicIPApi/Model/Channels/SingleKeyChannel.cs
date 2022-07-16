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

        [JsonProperty("supportedOptionalFeatures")]
        public SupportedOptionalFeatures SupportedOptionalFeatures { get; private set; }

    }
}