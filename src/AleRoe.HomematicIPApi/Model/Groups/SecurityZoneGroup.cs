using System.Collections.Generic;
using Newtonsoft.Json;

namespace AleRoe.HomematicIpApi.Model.Groups
{
    [GroupType(GroupType.SECURITY_ZONE)]
    public class SecurityZoneGroup : Group
    {
        [JsonProperty("active")]
        public bool Active { get; private set; }

        [JsonProperty("silent")]
        public bool Silent { get; private set; }

        [JsonProperty("ignorableDeviceChannels")]
        public List<object> IgnorableDeviceChannels { get; private set; }

        [JsonProperty("windowState")]
        public string WindowState { get; private set; }

        [JsonProperty("motionDetected")]
        public bool? MotionDetected { get; private set; }

        [JsonProperty("presenceDetected")]
        public bool? PresenceDetected { get; private set; }

        [JsonProperty("sabotage")]
        public object Sabotage { get; private set; }

        [JsonProperty("zoneAssignmentIndex")]
        public string ZoneAssignmentIndex { get; private set; }

        [JsonProperty("configPending")]
        public object ConfigPending { get; private set; }
    }
}