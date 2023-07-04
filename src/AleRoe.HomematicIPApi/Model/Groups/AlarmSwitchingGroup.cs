using Newtonsoft.Json;

namespace AleRoe.HomematicIpApi.Model.Groups
{
    [GroupType(GroupType.ALARM_SWITCHING)]
    public class AlarmSwitchingGroup : SwitchGroupBase
    {
        [JsonProperty("onTime")]
        public double OnTime { get; private set; }

        [JsonProperty("signalAcoustic")]
        public AcousticAlarmSignalType SignalAcoustic { get; private set; }

        [JsonProperty("signalOptical")]
        public OpticalAlarmSignalType SignalOptical { get; private set; }
            
        [JsonProperty("smokeDetectorAlarmType")]
        public SmokeDetectorAlarmType? SmokeDetectorAlarmType { get; private set; }

        [JsonProperty("acousticFeedbackEnabled")]
        public bool AcousticFeedbackEnabled { get; private set; }
    }
}