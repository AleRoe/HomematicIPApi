using Newtonsoft.Json;

namespace AleRoe.HomematicIpApi.Model.Groups
{
    [GroupType(GroupType.HEATING_COOLING_DEMAND_PUMP)]
    public class HeatingCoolingDemandPumpGroup : Group
    {
        [JsonProperty("pumpProtectionDuration")]
        public int PumpProtectionDuration { get; set; }

        [JsonProperty("pumpProtectionSwitchingInterval")]
        public int PumpProtectionSwitchingInterval { get; set; }

        [JsonProperty("pumpFollowUpTime")]
        public int PumpFollowUpTime { get; set; }

        [JsonProperty("pumpLeadTime")]
        public int PumpLeadTime { get; set; }

        [JsonProperty("on")]
        public bool? On { get; set; }

        [JsonProperty("heatDemand")]
        public object HeatDemand { get; set; }
    }
}