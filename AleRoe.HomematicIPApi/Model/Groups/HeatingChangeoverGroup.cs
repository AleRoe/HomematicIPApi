using Newtonsoft.Json;

namespace AleRoe.HomematicIpApi.Model.Groups
{
    [GroupType(GroupType.HEATING_CHANGEOVER)]
    public class HeatingChangeoverGroup : Group
    {
        [JsonProperty("on")]
        public bool? On { get; private set; }

        [JsonProperty("changeOver")]
        public object ChangeOver { get; private set; }
    }
}