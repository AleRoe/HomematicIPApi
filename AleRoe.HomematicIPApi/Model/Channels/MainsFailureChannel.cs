using Newtonsoft.Json;

namespace AleRoe.HomematicIpApi.Model.Channels
{
    [FunctionalChannelType(FunctionalChannelType.MAINS_FAILURE_CHANNEL)]
    public class MainsFailureChannel : FunctionalChannel
    {
        [JsonProperty("powerMainsFailure")]
        public bool PowerMainsFailure { get; set; }

        [JsonProperty("genericAlarmSignal")]
        public AlarmSignalType GenericAlarmSignal { get; set; } = AlarmSignalType.NO_ALARM;

    }
}
