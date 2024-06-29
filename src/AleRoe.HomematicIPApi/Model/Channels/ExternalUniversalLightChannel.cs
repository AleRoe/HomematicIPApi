using AleRoe.HomematicIpApi.Json;
using Newtonsoft.Json;
using System;

namespace AleRoe.HomematicIpApi.Model.Channels
{
    [FunctionalChannelType(FunctionalChannelType.EXTERNAL_UNIVERSAL_LIGHT_CHANNEL)]
    public class ExternalUniversalLightChannel : FunctionalChannel
    {
        [JsonProperty("channelId")]
        public Guid ChannelId { get; private set; }
        
        [JsonProperty("on")]
        public bool On { get; private set; }

        [JsonProperty("dimLevel")]
        public double DimLevel { get; private set; }

        [JsonProperty("hue")]
        public object Hue { get; private set; }

        [JsonProperty("saturationLevel")]
        public double? SaturationLevel { get; private set; }

        [JsonProperty("colorTemperature")]
        public int? ColorTemperature { get; private set; }

        [JsonProperty("minimalColorTemperature")]
        public int MinimalColorTemperature { get; private set; }

        [JsonProperty("maximumColorTemperature")]
        public int MaximumColorTemperature { get; private set; }
        
        [JsonProperty("channelRole")]
        public ChannelRole ChannelRole { get; private set; }
    }
}
