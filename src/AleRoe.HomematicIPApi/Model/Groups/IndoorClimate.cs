using Newtonsoft.Json;

namespace AleRoe.HomematicIpApi.Model.Groups
{
    [GroupType(GroupType.INDOOR_CLIMATE)]
    public class IndoorClimateGroup : Group
    {
        [JsonProperty("processing")]
        public object Processing { get; private set; }

        [JsonProperty("ventilationState")]
        public object VentilationState { get; private set; }

        [JsonProperty("ventilationLevel")]
        public object VentilationLevel { get; private set; }

        [JsonProperty("windowState")]
        public object WindowState { get; private set; }

        [JsonProperty("sabotage")]
        public bool? Sabotage { get; private set; }

    }
}
