using Newtonsoft.Json;

namespace AleRoe.HomematicIpApi.Model.Groups
{
    [GroupType(GroupType.LINKED_SWITCHING)]
    public class LinkedSwitchingGroup : SwitchGroupBase
    {
        [JsonProperty("triggered")]
        public bool Triggered { get; private set; }
    }
}