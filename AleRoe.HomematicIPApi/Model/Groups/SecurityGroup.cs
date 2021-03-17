using Newtonsoft.Json;

namespace AleRoe.HomematicIpApi.Model.Groups
{
    [GroupType(GroupType.SECURITY)]
    public class SecurityGroup : Group
    {
        [JsonProperty("windowState")] 
        public WindowState? WindowState { get; set; }

        [JsonProperty("motionDetected")] 
        public bool? MotionDetected { get; set; }

        [JsonProperty("presenceDetected")]
        public bool? PresenceDetected { get; set; }

        [JsonProperty("sabotage")]
        public bool? Sabotage { get; set; }

        [JsonProperty("smokeDetectorAlarmType", NullValueHandling = NullValueHandling.Ignore)]
        public SmokeDetectorAlarmType SmokeDetectorAlarmType { get; set; } = SmokeDetectorAlarmType.IDLE_OFF;

        [JsonProperty("moistureDetected")]
        public bool? MoistureDetected { get; set; }

        [JsonProperty("powerMainsFailure")]
        public bool? PowerMainsFailure { get; set; }

        [JsonProperty("waterlevelDetected")]
        public bool? WaterLevelDetected { get; set; }
    }
}