using Newtonsoft.Json;
using System;

namespace AleRoe.HomematicIpApi.Model.Home
{
    public class SecuritySwitchingGroups
    {
        [JsonProperty("SIREN")] 
        public Guid Siren { get; private set; }

        [JsonProperty("PANIC")] 
        public Guid Panic { get; private set; }

        [JsonProperty("ALARM")] 
        public Guid Alarm { get; private set; }

        [JsonProperty("COMING_HOME")] 
        public Guid ComingHome { get; private set; }

        [JsonProperty("BACKUP_ALARM_SIREN")] 
        public Guid BackupAlarmSiren { get; private set; }
    }
}