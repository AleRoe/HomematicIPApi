using AleRoe.HomematicIpApi.Extensions;
using AleRoe.HomematicIpApi.Model.Channels;
using System.Runtime.Serialization;

namespace AleRoe.HomematicIpApi.Model.Devices
{
    [DeviceType(DeviceType.PLUGGABLE_MAINS_FAILURE_SURVEILLANCE)]
    [DataContract]
    public class PluggableMainsFailureSurveillance : DeviceBase
    {
        // [HMIP-PMFS] (Plugable Power Supply Monitoring) 
        public bool PowerMainsFailure { get; private set; }
        public AlarmSignalType AlarmSignalType { get; private set; } = AlarmSignalType.NO_ALARM;

        [OnDeserialized]
        internal new void OnDeserializedMethod(StreamingContext context)
        {
            this.GetFunctionalChannel<MainsFailureChannel>()
                .CopyTo<PluggableMainsFailureSurveillance>(this);
        }

    }
}
