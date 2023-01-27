using System.Collections.Generic;
using Newtonsoft.Json;

namespace AleRoe.HomematicIpApi.Model.Home
{
    public class WeatherAndEnvironment
    {
        [JsonProperty("functionalGroups")] public List<object> FunctionalGroups { get; set; }

        [JsonProperty("solution")] public string Solution { get; set; }

        [JsonProperty("active")] public bool Active { get; set; }
    }
}