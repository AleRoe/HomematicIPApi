using Newtonsoft.Json;
using System.ComponentModel;

namespace AleRoe.HomematicIpApi.Model
{
    public class InternalLinkConfiguration
    {
        [JsonProperty("internalLinkConfigurationType")]
        public InternalLinkConfigurationType InternalLinkConfigurationType { get; private set; }

        [JsonProperty("onTime")]
        public double OnTime { get; private set; }

        [JsonProperty("firstInputAction")]
        public InputAction FirstInputAction { get; private set; }

        [JsonProperty("longPressOnTimeEnabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool? LongPressOnTimeEnabled { get; private set; }

        [JsonProperty("secondInputAction", NullValueHandling = NullValueHandling.Ignore)]
        public InputAction? SecondInputAction { get; private set; }

        [JsonProperty("onLevel", NullValueHandling = NullValueHandling.Ignore)]
        public double? OnLevel { get; private set; }

        [JsonProperty("dimStep", NullValueHandling = NullValueHandling.Ignore)]
        public double? DimStep { get; private set; }
    }
}
