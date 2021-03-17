using System.Collections.Generic;
using Newtonsoft.Json;

namespace AleRoe.HomematicIpApi.Model.Home
{
    public class VoiceControlSettings
    {
        [JsonProperty("language", NullValueHandling = NullValueHandling.Include, DefaultValueHandling = DefaultValueHandling.Include)]
        public string Language { get; private set; }

        [JsonProperty("allowedActiveSecurityZoneIds")]
        public List<object> AllowedActiveSecurityZoneIds { get; private set; }

        [JsonProperty("stateReportEnabled", NullValueHandling = NullValueHandling.Ignore)] 
        public StateReportEnabled StateReportEnabled { get; private set; }
    }
}