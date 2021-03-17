using Newtonsoft.Json;

namespace AleRoe.HomematicIpApi.Model.Home
{
    public class Location
    {
        [JsonProperty("city")] public string City { get; set; }

        [JsonProperty("latitude")] public string Latitude { get; set; }

        [JsonProperty("longitude")] public string Longitude { get; set; }
    }
}