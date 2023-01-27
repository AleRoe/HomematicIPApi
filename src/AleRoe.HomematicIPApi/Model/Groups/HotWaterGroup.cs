using System;
using Newtonsoft.Json;

namespace AleRoe.HomematicIpApi.Model.Groups
{
    [GroupType(GroupType.HOT_WATER)]
    public class HotWaterGroup : Group
    {
        [JsonProperty("on")]
        public bool? On { get; private set; }

        [JsonProperty("onTime")]
        public double OnTime { get; private set; }

        [JsonProperty("profileId")]
        public Guid ProfileId { get; private set; }

        [JsonProperty("profileMode")] 
        public ProfileMode? ProfileMode { get; private set; } 
    }
}