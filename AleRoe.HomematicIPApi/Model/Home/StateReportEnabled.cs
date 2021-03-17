using Newtonsoft.Json;

namespace AleRoe.HomematicIpApi.Model.Home
{
    public class StateReportEnabled
    {
        [JsonProperty("hmip_alexa_skill", NullValueHandling = NullValueHandling.Ignore)] 
        public string HmipAlexaSkill { get; set; }

        [JsonProperty("conrad_connect", NullValueHandling = NullValueHandling.Ignore)]
        public string ConradConnect { get; set; }
    }
}