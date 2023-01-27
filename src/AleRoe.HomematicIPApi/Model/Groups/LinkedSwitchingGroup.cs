using Newtonsoft.Json;

namespace AleRoe.HomematicIpApi.Model.Groups
{
    [GroupType(GroupType.LINKED_SWITCHING)]
    public class LinkedSwitchingGroup : SwitchGroupBase
    {
        [JsonProperty("triggered")]
        public object Triggered { get; private set; }
    }
}