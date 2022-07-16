using Newtonsoft.Json;

namespace AleRoe.HomematicIpApi.Model.Groups
{
    [GroupType(GroupType.HEATING_TEMPERATURE_LIMITER)]
    public class HeatingTemperatureLimiterGroup : Group
    {
        [JsonProperty("temperatureLimiterActive", NullValueHandling = NullValueHandling.Ignore)]
        public bool? TemperatureLimiterActive { get; private set; }
    }
}