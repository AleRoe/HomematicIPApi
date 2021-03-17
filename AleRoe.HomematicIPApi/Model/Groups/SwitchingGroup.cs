using Newtonsoft.Json;

namespace AleRoe.HomematicIpApi.Model.Groups
{
    [GroupType(GroupType.SWITCHING)]
    public class SwitchingGroup : SwitchGroupBase
    {
        [JsonProperty("processing")]
        public bool? Processing { get; set; }

        [JsonProperty("shutterLevel")]
        public double? ShutterLevel { get; set; }

        [JsonProperty("slatsLevel")]
        public double? SlatsLevel { get; set; }

        [JsonProperty("primaryShadingLevel")]
        public double? PrimaryShadingLevel { get; set; }

        [JsonProperty("primaryShadingStateType")]
        public ShadingStateType PrimaryShadingStateType { get; set; } = ShadingStateType.NOT_EXISTENT;

        [JsonProperty("secondaryShadingLevel")]
        public double? SecondaryShadingLevel { get; set; }

        [JsonProperty("secondaryShadingStateType")]
        public ShadingStateType SecondaryShadingStateType { get; set; } = ShadingStateType.NOT_EXISTENT;

    }
}