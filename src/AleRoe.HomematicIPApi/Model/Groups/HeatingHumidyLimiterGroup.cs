using Newtonsoft.Json;

namespace AleRoe.HomematicIpApi.Model.Groups
{
    [GroupType(GroupType.HEATING_HUMIDITY_LIMITER)]
    public class HeatingHumidyLimiterGroup : Group
    {
        [JsonProperty("humidityLimiterActive")]
        public object HumidityLimiterActive { get; private set; }
    }
}