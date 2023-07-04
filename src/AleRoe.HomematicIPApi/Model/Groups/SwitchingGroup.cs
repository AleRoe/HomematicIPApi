using Newtonsoft.Json;
using System;

namespace AleRoe.HomematicIpApi.Model.Groups
{
    [GroupType(GroupType.SWITCHING)]
    public class SwitchingGroup : SwitchGroupBase
    {
        [JsonProperty("processing")]
        public bool? Processing { get; private set; }

        [JsonProperty("shutterLevel")]
        public double? ShutterLevel { get; private set; }

        [JsonProperty("slatsLevel")]
        public double? SlatsLevel { get; private set; }

        [JsonProperty("primaryShadingLevel")]
        public double? PrimaryShadingLevel { get; private set; }

        [JsonProperty("primaryShadingStateType")]
        public ShadingStateType PrimaryShadingStateType { get; private set; } = ShadingStateType.NOT_EXISTENT;

        [JsonProperty("secondaryShadingLevel")]
        public double? SecondaryShadingLevel { get; private set; }

        [JsonProperty("secondaryShadingStateType")]
        public ShadingStateType SecondaryShadingStateType { get; private set; } = ShadingStateType.NOT_EXISTENT;

        [JsonProperty("hue")]
        public object Hue{ get; private set; }

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