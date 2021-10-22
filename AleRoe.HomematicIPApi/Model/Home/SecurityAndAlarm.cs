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

        [JsonProperty("alarmEventDeviceChannel")]
        public object AlarmEventDeviceChannel { get; set; }

        [JsonProperty("alarmEventDeviceId")]
        public string AlarmEventDeviceId { get; set; }

        [JsonProperty("alarmEventTimestamp")]
        public long? AlarmEventTimestamp { get; set; }

        [JsonProperty("alarmEventTriggerId")]
        public object AlarmEventTriggerId { get; set; }

        [JsonProperty("alarmSecurityJournalEntryType")]
        public object AlarmSecurityJournalEntryType { get; set; }

        [JsonProperty("functionalGroups")] 
        public List<string> FunctionalGroups { get; set; }

        [JsonProperty("intrusionAlarmActive")]
        public bool? IntrusionAlarmActive { get; set; }

        [JsonProperty("intrusionAlarmEventDeviceChannel")]
        public object IntrusionAlarmEventDeviceChannel { get; set; }

        [JsonProperty("intrusionAlarmEventTimestamp")]
        public long? IntrusionAlarmEventTimestamp { get; set; }

        [JsonProperty("intrusionAlarmEventTriggerId")]
        public object IntrusionAlarmEventTriggerId { get; set; }

        [JsonProperty("intrusionAlarmSecurityJournalEntryType")]
        public object IntrusionAlarmSecurityJournalEntryType { get; set; }
        
        [JsonProperty("intrusionAlertThroughSmokeDetectors")]
        public bool IntrusionAlertThroughSmokeDetectors { get; set; }

        [JsonProperty("safetyAlarmActive")]
        public bool? SafetyAlarmActive { get; set; }

        [JsonProperty("safetyAlarmEventDeviceChannel")]
        public object SafetyAlarmEventDeviceChannel { get; set; }

        [JsonProperty("safetyAlarmEventTimestamp")]
        public long? SafetyAlarmEventTimestamp { get; set; }

        [JsonProperty("safetyAlarmSecurityJournalEntryType")]
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

        [JsonProperty("deviceChannelSpecificFunction")]
        public object DeviceChannelSpecificFunction { get; set; }
    }
}