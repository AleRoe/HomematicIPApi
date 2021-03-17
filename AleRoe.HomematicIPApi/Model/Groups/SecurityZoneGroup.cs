using System.Collections.Generic;
using Newtonsoft.Json;

namespace AleRoe.HomematicIpApi.Model.Groups
{
    [GroupType(GroupType.SECURITY_ZONE)]
    public class SecurityZoneGroup : Group
    {
        [JsonProperty("active")]
        public bool Active { get; set; }

        [JsonProperty("silent")]
        public bool Silent { get; set; }

        [JsonProperty("ignorableDevices")]
        public List<object> IgnorableDevices { get; set; }

        [JsonProperty("ignorableDeviceChannels")]
        public List<object> IgnorableDeviceChannels { get; set; }

        [JsonProperty("windowState")]
        public string WindowState { get; set; }

        [JsonProperty("motionDetected")]
        public bool? MotionDetected { get; set; }

        [JsonProperty("presenceDetected")]
        public bool? PresenceDetected { get; set; }

        [JsonProperty("sabotage")]
        public object Sabotage { get; set; }

        [JsonProperty("zoneAssignmentIndex")]
        public string ZoneAssignmentIndex { get; set; }

        [JsonProperty("configPending")]
        public object ConfigPending { get; set; }
    }
}