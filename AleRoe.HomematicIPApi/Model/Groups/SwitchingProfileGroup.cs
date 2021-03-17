using Newtonsoft.Json;
using System;

namespace AleRoe.HomematicIpApi.Model.Groups
{
    [GroupType(GroupType.SWITCHING_PROFILE)]
    public class SwitchingProfileGroup : Group
    {
        [JsonProperty("on")]
        public bool? On { get; private set; }

        [JsonProperty("dimLevel")]
        public double? DimLevel { get; private set; }

        [JsonProperty("profileId")]
        public Guid ProfileId { get; private set; }

        [JsonProperty("profileMode", NullValueHandling = NullValueHandling.Ignore)]
        public ProfileMode ProfileMode { get; private set; } = ProfileMode.MANUAL;

    }
}