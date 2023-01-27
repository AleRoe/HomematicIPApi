using Newtonsoft.Json;

namespace AleRoe.HomematicIpApi.Model.Home
{
    public class AccessPointUpdateState
    {
        [JsonProperty("accessPointUpdateState")]
        public LiveUpdateState State { get; set; } = LiveUpdateState.UP_TO_DATE;

        [JsonProperty("successfulUpdateTimestamp")]
        public long SuccessfulUpdateTimestamp { get; set; }

        [JsonProperty("updateStateChangedTimestamp")]
        public long UpdateStateChangedTimestamp { get; set; }

    }
}