using System;
using Newtonsoft.Json;

namespace AleRoe.HomematicIpApi.Model.Groups
{
    [GroupType(GroupType.SHUTTER_PROFILE)]
    public class ShutterProfile : Group
    {
        [JsonProperty("shutterLevel")]
        public double ShutterLevel { get; private set; }

        [JsonProperty("slatsLevel")]
        public double? SlatsLevel { get; private set; }

        [JsonProperty("primaryShadingLevel")]
        public double PrimaryShadingLevel { get; private set; }

        [JsonProperty("primaryShadingStateType")]
        public ShadingStateType PrimaryShadingStateType { get; private set; }

        [JsonProperty("secondaryShadingLevel")]
        public double? SecondaryShadingLevel { get; private set; }

        [JsonProperty("secondaryShadingStateType")]
        public ShadingStateType SecondaryShadingStateType { get; private set; }

        [JsonProperty("processing")]
        public bool Processing { get; private set; }

        [JsonProperty("profileId")]
        public Guid ProfileId { get; private set; }

        [JsonProperty("profileMode")]
        public ProfileMode ProfileMode { get; private set; } = ProfileMode.MANUAL;
    }
}