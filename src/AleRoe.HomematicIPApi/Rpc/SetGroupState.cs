using System;
using Newtonsoft.Json;

namespace AleRoe.HomematicIpApi.Rpc
{
    public readonly struct SetGroupState
    {
        public SetGroupState(Guid groupId, bool on)
        {
            this.GroupId = groupId;
            this.On = on;
        }

        [JsonProperty("groupId")]
        public Guid GroupId { get; }

        [JsonProperty("on")]
        public bool On { get; }
    }
}