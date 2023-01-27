using Newtonsoft.Json;

namespace AleRoe.HomematicIpApi.Model.Groups
{
    [GroupType(GroupType.HEATING_DEHUMIDIFIER)]
    public class HeatingDehumidifierGroup : Group
    {
        [JsonProperty("on")]
        public bool? On { get; set; }
    }
}