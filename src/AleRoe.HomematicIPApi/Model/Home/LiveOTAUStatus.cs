using Newtonsoft.Json;
using System;

namespace AleRoe.HomematicIpApi.Model.Home
{
    public class LiveOTAUStatus
    {
        [JsonProperty("liveOTAUState")] 
        public LiveOTAUState LiveOTAUState { get; set; }

        [JsonProperty("progress")] 
        public double Progress { get; set; }

        [JsonProperty("deviceId", NullValueHandling = NullValueHandling.Include)] 
        public Guid? DeviceId { get; set; }
    }
}