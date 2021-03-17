using Newtonsoft.Json;

namespace AleRoe.HomematicIpApi.Model.Groups
{
    [GroupType(GroupType.EXTENDED_LINKED_SWITCHING)]
    public class ExtendedLinkedSwitchingGroup : SwitchGroupBase
    {
        [JsonProperty("onTime")]
        public double OnTime { get; set; }

        [JsonProperty("onLevel")]
        public double OnLevel { get; set; }

        [JsonProperty("sensorSpecificParameters")]
        public object SensorSpecificParameters { get; set; }

        [JsonProperty("groupVisibility")]
        public GroupVisibility GroupVisibility { get; set; }
    }
}