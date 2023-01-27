using Newtonsoft.Json;

namespace AleRoe.HomematicIpApi.Model.Groups
{
    [GroupType(GroupType.ENVIRONMENT)]
    public class EnvironmentGroup : Group
    {
        [JsonProperty("actualTemperature")]
        public double ActualTemperature { get; private set; }

        [JsonProperty("humidity")]
        public int Humidity { get; private set; }

        [JsonProperty("illumination")]
        public double Illumination { get; private set; }

        [JsonProperty("raining")]
        public bool Raining { get; private set; }

        [JsonProperty("windSpeed")]
        public double WindSpeed { get; private set; }

    }
}