using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace AleRoe.HomematicIpApi.Model.Home
{
    public class RuleMetaData
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("homeId")]
        public Guid HomeId { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("type")]
        public AutomationRuleType Type { get; set; }

        [JsonProperty("active")]
        public bool Active { get; set; }

        [JsonProperty("ruleErrorCategories")]
        public List<object> RuleErrorCategories { get; set; }
    }
}