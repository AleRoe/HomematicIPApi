using Newtonsoft.Json;

namespace AleRoe.HomematicIpApi.Model.Home
{
    public class FunctionalHomes
    {
        [JsonProperty("WEATHER_AND_ENVIRONMENT")]
        public WeatherAndEnvironment WeatherAndEnvironment { get; private set; }

        [JsonProperty("SECURITY_AND_ALARM")] 
        public SecurityAndAlarm SecurityAndAlarm { get; private set; }

        [JsonProperty("LIGHT_AND_SHADOW")] 
        public LightAndShadow LightAndShadow { get; private set; }

        [JsonProperty("INDOOR_CLIMATE")] 
        public IndoorClimate IndoorClimate { get; private set; }

        [JsonProperty("ACCESS_CONTROL")]
        public AccessControl AccessControl { get; private set; }

        [JsonProperty("ENERGY")]
        public Energy Energy { get; private set; }
    }
}