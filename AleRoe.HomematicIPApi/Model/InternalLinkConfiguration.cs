using Newtonsoft.Json;

namespace AleRoe.HomematicIpApi.Model
{
    public class InternalLinkConfiguration
    {
        [JsonProperty("internalLinkConfigurationType")]
        public InternalLinkConfigurationType InternalLinkConfigurationType { get; private set; }

        [JsonProperty("onTime")]
        public double OnTime { get; private set; }

        [JsonProperty("firstInputAction")]
        public FirstInputAction FirstInputAction { get; private set; }

        [JsonProperty("longPressOnTimeEnabled")]
        public bool LongPressOnTimeEnabled { get; private set; }
    }
}
