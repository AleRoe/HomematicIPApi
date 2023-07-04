using Newtonsoft.Json;
using System;

namespace AleRoe.HomematicIpApi.Model.Groups
{
    [GroupType(GroupType.EXTENDED_LINKED_SWITCHING)]
    public class ExtendedLinkedSwitchingGroup : LinkedSwitchingGroup
    {
        [JsonProperty("onTime")]
        public double OnTime { get; private set; }

        [JsonProperty("onLevel")]
        public double OnLevel { get; private set; }

        [JsonProperty("sensorSpecificParameters")]
        public object SensorSpecificParameters { get; private set; }

        [JsonProperty("groupVisibility")]
        public GroupVisibility GroupVisibility { get; private set; }

        [JsonProperty("dimStep")]
        public double DimStep { get; private set; }

        [JsonProperty("onHue")]
        public int OnHue { get; private set; }

        [JsonProperty("onSaturationLevel")]
        public double OnSaturationLevel { get; private set; }

        [JsonProperty("onColorTemperature")]
        public int OnColorTemperature { get; private set; }

        [JsonProperty("longPressBehavior")]
        public LongPressBehavior LongPressBehavior { get; private set; }

        [JsonProperty("onLightSceneId")]
        public int OnLightSceneId { get; private set; }

        [JsonProperty("hue")]
        public object Hue { get; private set; }

        [JsonProperty("saturationLevel")]
        public double? SaturationLevel { get; private set; }

        [JsonProperty("colorTemperature")]
        public double? ColorTemperature { get; private set; }

        [JsonProperty("minimalColorTemperature")]
        public double? MinimalColorTemperature { get; private set; }

        [JsonProperty("maximumColorTemperature")]
        public double? MaximumColorTemperature { get; private set; }

        [JsonProperty("dim2WarmActive")]
        public bool? Dim2WarmActive { get; private set; }

        [JsonProperty("humanCentricLightActive")]
        public bool? HumanCentricLightActive { get; private set; }

        [JsonProperty("lightSceneId")]
        public Guid? LightSceneId { get; private set; }

        [JsonProperty("supportedOptionalFeatures")]
        public SupportedOptionalFeatures SupportedOptionalFeatures { get; private set; }

    }
}