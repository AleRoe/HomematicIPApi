using System.ComponentModel;
using Newtonsoft.Json;

namespace AleRoe.HomematicIpApi.Model.Channels
{
    [FunctionalChannelType(FunctionalChannelType.DIMMER_CHANNEL)]
    public class DimmerChannel : FunctionalChannel
    {
        [JsonProperty("on")]
        public bool On { get; private set; }

        [JsonProperty("dimLevel")] 
        public double DimLevel { get; private set; }

        [JsonProperty("profileMode")] 
        public ProfileMode ProfileMode { get; private set; }

        [JsonProperty("userDesiredProfileMode")]
        public ProfileMode UserDesiredProfileMode { get; private set; }

        [JsonProperty("deviceOverloaded")]
        [DefaultValue(false)]
        public bool? DeviceOverloaded { get; private set; }

        [JsonProperty("coProFaulty")]
        [DefaultValue(false)]
        public bool? CoProFaulty { get; private set; }

        [JsonProperty("coProRestartNeeded")]
        [DefaultValue(false)]
        public bool? CoProRestartNeeded { get; private set; }

        [JsonProperty("deviceOverheated")]
        [DefaultValue(null)]
        public bool? DeviceOverheated { get; private set; }

        [JsonProperty("channelRole")]
        public ChannelRole? ChannelRole { get; private set; }

        [JsonProperty("onMinLevel")]
        public double OnMinLevel { get; private set; }

        [JsonProperty("dimmingMode")]
        public DimmingMode DimmingMode { get; private set; }

        [JsonProperty("dimLevelLowest")]
        public double DimLevelLowest { get; private set; }

        [JsonProperty("dimLevelHighest")]
        public double DimLevelHighest { get; private set; }

        [JsonProperty("internalLinkConfiguration")]
        public InternalLinkConfiguration InternalLinkConfiguration { get; private set; }
    }
}