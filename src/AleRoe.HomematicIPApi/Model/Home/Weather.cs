using Newtonsoft.Json;

namespace AleRoe.HomematicIpApi.Model.Home
{
    public class Weather
    {
        [JsonProperty("temperature")] public double Temperature { get; set; }

        [JsonProperty("weatherCondition")] public string WeatherCondition { get; set; }

        [JsonProperty("weatherDayTime")] public string WeatherDayTime { get; set; }

        [JsonProperty("minTemperature")] public double MinTemperature { get; set; }

        [JsonProperty("maxTemperature")] public double MaxTemperature { get; set; }

        [JsonProperty("humidity")] public int Humidity { get; set; }

        [JsonProperty("windSpeed")] public double WindSpeed { get; set; }

        [JsonProperty("windDirection")] public int WindDirection { get; set; }

        [JsonProperty("vaporAmount")] public double VaporAmount { get; set; }
    }
}