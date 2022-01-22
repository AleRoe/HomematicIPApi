using System;
using System.Collections.Generic;
using AleRoe.HomematicIpApi.Json;
using Newtonsoft.Json;

namespace AleRoe.HomematicIpApi.Model.Home
{
    public class RuleMetaData
    {
        [JsonProperty("id")]
        public string Id { get; private set; }

        [JsonProperty("homeId")]
        public Guid HomeId { get; private set; }

        [JsonProperty("label")]
        public string Label { get; private set; }

        [JsonProperty("type")]
        public AutomationRuleType Type { get; private set; }

        [JsonProperty("active")]
        public bool Active { get; private set; }

        [JsonProperty("ruleErrorCategories")]
        public List<object> RuleErrorCategories { get; private set; }

        [JsonProperty("lastExecutionTimestamp", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(UnixTimestampConverter))]
        public DateTime LastExecutionTimestamp { get; private set; }

        [JsonProperty("executionCounterOfDay")]
        public int ExecutionCounterOfDay { get; private set; }

        [JsonProperty("specialInterestCategories")]
        public object SpecialInterestCategories { get; private set; }

    }
}