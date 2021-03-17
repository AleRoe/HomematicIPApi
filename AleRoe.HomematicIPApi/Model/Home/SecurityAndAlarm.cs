using System.Collections.Generic;
using Newtonsoft.Json;

namespace AleRoe.HomematicIpApi.Model.Home
{
    public class SecurityAndAlarm
    {
        [JsonProperty("activationInProgress")]
        public bool ActivationInProgress { get; set; }

        [JsonProperty("active")]
        public bool Active { get; set; }

        [JsonProperty("alarmActive")]
        public bool AlarmActive { get; set; }

        [JsonProperty("alarmEventDeviceChannel", NullValueHandling = NullValueHandling.Include)]
        public object AlarmEventDeviceChannel { get; set; }

        [JsonProperty("alarmEventDeviceId", NullValueHandling = NullValueHandling.Include)]
        public string AlarmEventDeviceId { get; set; }

        [JsonProperty("alarmEventTimestamp", NullValueHandling = NullValueHandling.Include)]
        public long? AlarmEventTimestamp { get; set; }

        [JsonProperty("alarmEventTriggerId", NullValueHandling = NullValueHandling.Include)]
        public object AlarmEventTriggerId { get; set; }

        [JsonProperty("alarmSecurityJournalEntryType", NullValueHandling = NullValueHandling.Include)]
        public object AlarmSecurityJournalEntryType { get; set; }

        [JsonProperty("functionalGroups")] 
        public List<string> FunctionalGroups { get; set; }

        [JsonProperty("intrusionAlarmActive")]
        public bool IntrusionAlarmActive { get; set; }

        [JsonProperty("intrusionAlarmEventDeviceChannel", NullValueHandling = NullValueHandling.Include)]
        public object IntrusionAlarmEventDeviceChannel { get; set; }

        [JsonProperty("intrusionAlarmEventTimestamp", NullValueHandling = NullValueHandling.Include)]
        public long? IntrusionAlarmEventTimestamp { get; set; }

        [JsonProperty("intrusionAlarmEventTriggerId", NullValueHandling = NullValueHandling.Include)]
        public object IntrusionAlarmEventTriggerId { get; set; }

        [JsonProperty("intrusionAlarmSecurityJournalEntryType", NullValueHandling = NullValueHandling.Include)]
        public object IntrusionAlarmSecurityJournalEntryType { get; set; }
        
        [JsonProperty("intrusionAlertThroughSmokeDetectors")]
        public bool IntrusionAlertThroughSmokeDetectors { get; set; }

        [JsonProperty("safetyAlarmActive")]
        public bool SafetyAlarmActive { get; set; }

        [JsonProperty("safetyAlarmEventDeviceChannel", NullValueHandling = NullValueHandling.Include)]
        public object SafetyAlarmEventDeviceChannel { get; set; }

        [JsonProperty("safetyAlarmEventTimestamp", NullValueHandling = NullValueHandling.Include)]
        public long? SafetyAlarmEventTimestamp { get; set; }

        [JsonProperty("safetyAlarmSecurityJournalEntryType", NullValueHandling = NullValueHandling.Include)]
        public object SafetyAlarmSecurityJournalEntryType { get; set; }

        [JsonProperty("securitySwitchingGroups")]
        public SecuritySwitchingGroups SecuritySwitchingGroups { get; set; }

        [JsonProperty("securityZoneActivationMode")]
        public string SecurityZoneActivationMode { get; set; }

        [JsonProperty("securityZones")] 
        public SecurityZones SecurityZones { get; set; }

        [JsonProperty("solution")]
        public string Solution { get; set; }

        [JsonProperty("zoneActivationDelay")] 
        public double ZoneActivationDelay { get; set; }
    }
}