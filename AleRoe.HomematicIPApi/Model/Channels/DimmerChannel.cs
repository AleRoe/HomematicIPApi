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

    }
}