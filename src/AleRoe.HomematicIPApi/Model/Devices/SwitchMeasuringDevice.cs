using System.Runtime.Serialization;
using AleRoe.HomematicIpApi.Extensions;
using AleRoe.HomematicIpApi.Model.Channels;

namespace AleRoe.HomematicIpApi.Model.Devices
{
    public class SwitchMeasuringDevice : Device
    {
        public double EnergyCounter { get; private set; }

        public double CurrentPowerConsumption { get; private set; }

        [OnDeserialized]
        internal new void OnDeserializedMethod(StreamingContext context)
        {
            this.GetFunctionalChannel<SwitchMeasuringChannel>()
                .CopyTo(this);
        }
    }
}