using Newtonsoft.Json;

namespace AleRoe.HomematicIpApi.Model.Home
{
    public class Energy
    {
        [JsonProperty("functionalGroups")]
        public FunctionalGroups FunctionalGroups { get; private set; }

        [JsonProperty("solution")]
        public string Solution { get; private set; }

        [JsonProperty("active")]
        public bool Active { get; private set; }
    }
}
