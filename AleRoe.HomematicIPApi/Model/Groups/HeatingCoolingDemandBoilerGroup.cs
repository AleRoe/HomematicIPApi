using Newtonsoft.Json;

namespace AleRoe.HomematicIpApi.Model.Groups
{
    [GroupType(GroupType.HEATING_COOLING_DEMAND_BOILER)]
    public class HeatingCoolingDemandBoilerGroup : Group
    {
        [JsonProperty("on")]
        public bool? On { get; set; }

        [JsonProperty("boilerLeadTime")]
        public int BoilerLeadTime { get; set; }

        [JsonProperty("boilerFollowUpTime")]
        public int BoilerFollowUpTime { get; set; }

        [JsonProperty("heatDemand")]
        public object HeatDemand { get; set; }
    }
}