using AleRoe.HomematicIpApi.Json;
using AleRoe.HomematicIpApi.Model.Groups;
using Newtonsoft.Json;

namespace AleRoe.HomematicIpApi.Rpc
{
    public class GroupEvent : Event
    {
        [JsonProperty("group")] 
        [JsonConverter(typeof(GroupConverter))]
        public IGroup Group { get; set; }

        public override string ToString()
        {
            return $"{Group.Label}";
        }
    }
}