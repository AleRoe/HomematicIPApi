using System;
using Newtonsoft.Json;

namespace AleRoe.HomematicIpApi.Model.Home
{
    public class FloorHeatingSpecificGroups
    {
        [JsonProperty("HEATING_COOLING_DEMAND_PUMP")]
        public Guid HeatingCoolingDemandPump { get; set; }

        [JsonProperty("HEATING_COOLING_DEMAND_BOILER")]
        public Guid HeatingCoolingDemandBoiler { get; set; }

        [JsonProperty("HEATING_HUMIDITY_LIMITER")]
        public Guid HeatingHumidityLimiter { get; set; }

        [JsonProperty("HEATING_TEMPERATURE_LIMITER")]
        public Guid HeatingTemperatureLimiter { get; set; }

        [JsonProperty("HEATING_DEHUMIDIFIER")] public Guid HeatingDehumidifier { get; set; }

        [JsonProperty("HEATING_CHANGEOVER")] public Guid HeatingChangeover { get; set; }

        [JsonProperty("HEATING_EXTERNAL_CLOCK")]
        public Guid HeatingExternalClock { get; set; }
    }
}