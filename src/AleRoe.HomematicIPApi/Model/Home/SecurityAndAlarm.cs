using System.Collections.Generic;
using Newtonsoft.Json;

namespace AleRoe.HomematicIpApi.Model.Home
{
    public class SecurityAndAlarm
    {
        [JsonProperty("activationInProgress")]
        public bool ActivationInProgress { get; private set; }

        [JsonProperty("active")]
        public bool Active { get; private set; }

        [JsonProperty("alarmActive")]
        public bool AlarmActive { get; private set; }

        [JsonProperty("alarmEventDeviceChannel")]
        public object AlarmEventDeviceChannel { get; private set; }

        [JsonProperty("alarmEventTimestamp")]
        public long? AlarmEventTimestamp { get; private set; }

        [JsonProperty("alarmEventTriggerId")]
        public object AlarmEventTriggerId { get; private set; }

        [JsonProperty("alarmSecurityJournalEntryType")]
        public object AlarmSecurityJournalEntryType { get; private set; }

        [JsonProperty("functionalGroups")] 
        public FunctionalGroups FunctionalGroups { get; private set; }

        [JsonProperty("intrusionAlarmActive")]
        public bool? IntrusionAlarmActive { get; private set; }

        [JsonProperty("intrusionAlarmEventDeviceChannel")]
        public object IntrusionAlarmEventDeviceChannel { get; private set; }

        [JsonProperty("intrusionAlarmEventTimestamp")]
        public long? IntrusionAlarmEventTimestamp { get; private set; }

        [JsonProperty("intrusionAlarmEventTriggerId")]
        public object IntrusionAlarmEventTriggerId { get; private set; }

        [JsonProperty("intrusionAlarmSecurityJournalEntryType")]
        public object IntrusionAlarmSecurityJournalEntryType { get; private set; }
        
        [JsonProperty("intrusionAlertThroughSmokeDetectors")]
        public bool IntrusionAlertThroughSmokeDetectors { get; private set; }

        [JsonProperty("safetyAlarmActive")]
        public bool? SafetyAlarmActive { get; private set; }

        [JsonProperty("safetyAlarmEventDeviceChannel")]
        public object SafetyAlarmEventDeviceChannel { get; private set; }

        [JsonProperty("safetyAlarmEventTimestamp")]
        public long? SafetyAlarmEventTimestamp { get; private set; }

        [JsonProperty("safetyAlarmSecurityJournalEntryType")]
        public object SafetyAlarmSecurityJournalEntryType { get; private set; }

        [JsonProperty("securitySwitchingGroups")]
        public SecuritySwitchingGroups SecuritySwitchingGroups { get; private set; }

        [JsonProperty("securityZoneActivationMode")]
        public string SecurityZoneActivationMode { get; private set; }

        [JsonProperty("securityZones")] 
        public SecurityZones SecurityZones { get; private set; }

        [JsonProperty("solution")]
        public string Solution { get; private set; }

        [JsonProperty("zoneActivationDelay")] 
        public double ZoneActivationDelay { get; private set; }

        [JsonProperty("deviceChannelSpecificFunction")]
        public object DeviceChannelSpecificFunction { get; private set; }
    }
}