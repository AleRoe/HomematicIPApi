using Newtonsoft.Json;

namespace AleRoe.HomematicIpApi.Model.Home
{
    public class FunctionalHomes
    {
        [JsonProperty("WEATHER_AND_ENVIRONMENT")]
        public WeatherAndEnvironment WeatherAndEnvironment { get; set; }

        [JsonProperty("SECURITY_AND_ALARM")] 
        public SecurityAndAlarm SecurityAndAlarm { get; set; }

        [JsonProperty("LIGHT_AND_SHADOW")] 
        public LightAndShadow LightAndShadow { get; set; }

        [JsonProperty("INDOOR_CLIMATE")] 
        public IndoorClimate IndoorClimate { get; set; }
    }
}