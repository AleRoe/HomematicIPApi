using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace AleRoe.HomematicIpApi.Model.Groups
{
    [GroupType(GroupType.META)]
    public class MetaGroup : Group
    {
        [JsonProperty("groups", NullValueHandling = NullValueHandling.Ignore)]
        public List<Guid> Groups { get; set; }

        
        [JsonProperty("sabotage")]
        public bool? Sabotage { get; set; }

        [JsonProperty("configPending", NullValueHandling = NullValueHandling.Ignore)]
        public bool ConfigPending { get; set; }

        [JsonProperty("incorrectPositioned")]
        public bool? IncorrectPositioned { get; set; }
        
        [JsonProperty("groupIcon")]
        public object GroupIcon { get; set; }

    }
}