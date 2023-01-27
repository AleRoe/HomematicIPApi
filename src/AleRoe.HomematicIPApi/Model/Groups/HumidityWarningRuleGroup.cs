using System;
using AleRoe.HomematicIpApi.Json;
using Newtonsoft.Json;

namespace AleRoe.HomematicIpApi.Model.Groups
{
    [GroupType(GroupType.HUMIDITY_WARNING_RULE_GROUP)]
    public class HumidityWarningRuleGroup : Group
    {
        [JsonProperty("enabled")]
        public bool Enabled { get; private set; }

        [JsonProperty("humidityValidationResult")]
        public HumidityValidationType? HumidityValidationResult { get; private set; }

        [JsonProperty("humidityLowerThreshold")]
        public int HumidityLowerThreshold { get; private set; }

        [JsonProperty("humidityUpperThreshold")]
        public int HumidityUpperThreshold { get; private set; }

        [JsonProperty("lastExecutionTimestamp")]
        [JsonConverter(typeof(UnixTimestampConverter))]
        public DateTime LastExecutionTimestamp { get; private set; }

        [JsonProperty("triggered")]
        public bool Triggered { get; private set; }

        [JsonProperty("ventilationRecommended")]
        public bool VentilationRecommended { get; private set; }

        [JsonProperty("outdoorClimateSensor")]
        public object OutdoorClimateSensor { get; private set; }
    }
}