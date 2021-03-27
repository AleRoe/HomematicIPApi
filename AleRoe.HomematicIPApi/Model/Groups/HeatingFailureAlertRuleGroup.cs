using System;
using AleRoe.HomematicIpApi.Json;
using Newtonsoft.Json;

namespace AleRoe.HomematicIpApi.Model.Groups
{
    [GroupType(GroupType.HEATING_FAILURE_ALERT_RULE_GROUP)]
    public class HeatingFailureAlertRuleGroup : Group
    {
        [JsonProperty("checkInterval")]
        public int CheckInterval { get; private set; }

        [JsonProperty("enabled")]
        public bool Enabled { get; private set; }

        [JsonProperty("heatingFailureValidationResult")]
        public HeatingFailureValidationType HeatingFailureValidationResult { get; private set; }

        [JsonProperty("lastExecutionTimestamp")]
        [JsonConverter(typeof(UnixTimestampConverter))]
        public DateTime LastExecutionTimestamp { get; private set; }

        [JsonProperty("triggered")]
        public bool Triggered { get; private set; }

        [JsonProperty("validationTimeout")]
        public int ValidationTimeout { get; private set; }
    }
}