using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace AleRoe.HomematicIpApi.Model.Groups
{
    [GroupType(GroupType.META)]
    public class MetaGroup : Group
    {
        [JsonProperty("groups", NullValueHandling = NullValueHandling.Ignore)]
        public List<Guid> Groups { get; private set; }
                
        [JsonProperty("sabotage")]
        public bool? Sabotage { get; private set; }

        [JsonProperty("configPending", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ConfigPending { get; private set; }

        [JsonProperty("incorrectPositioned")]
        public bool? IncorrectPositioned { get; private set; }
        
        [JsonProperty("groupIcon")]
        public object GroupIcon { get; private set; }

    }
}