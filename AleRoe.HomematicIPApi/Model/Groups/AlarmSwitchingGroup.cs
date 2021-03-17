using Newtonsoft.Json;

namespace AleRoe.HomematicIpApi.Model.Groups
{
    [GroupType(GroupType.ALARM_SWITCHING)]
    public class AlarmSwitchingGroup : SwitchGroupBase
    {
        [JsonProperty("onTime")]
        public double OnTime { get; set; }

        [JsonProperty("signalAcoustic")]
        public AcousticAlarmSignalType SignalAcoustic { get; set; }

        [JsonProperty("signalOptical")]
        public OpticalAlarmSignalType SignalOptical { get; set; }

        [JsonProperty("smokeDetectorAlarmType")]
        public object SmokeDetectorAlarmType { get; set; }

        [JsonProperty("acousticFeedbackEnabled")]
        public bool AcousticFeedbackEnabled { get; set; }
    }
}