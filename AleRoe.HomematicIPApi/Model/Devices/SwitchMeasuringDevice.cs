using System.Runtime.Serialization;
using AleRoe.HomematicIpApi.Extensions;
using AleRoe.HomematicIpApi.Model.Channels;
using Newtonsoft.Json;

namespace AleRoe.HomematicIpApi.Model.Devices
{
    public class SwitchMeasuringDevice : SwitchDeviceBase
    {
        [JsonProperty("energyCounter")]
        public double EnergyCounter { get; private set; }

        [JsonProperty("currentPowerConsumption")]
        public double CurrentPowerConsumption { get; private set; }

        [OnDeserialized]
        internal new void OnDeserializedMethod(StreamingContext context)
        {
            this.GetFunctionalChannel<SwitchMeasuringChannel>()
                .CopyTo(this);
        }
    }
}