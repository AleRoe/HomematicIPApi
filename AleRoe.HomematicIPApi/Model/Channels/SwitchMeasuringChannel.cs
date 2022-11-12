using Newtonsoft.Json;

namespace AleRoe.HomematicIpApi.Model.Channels
{
    [FunctionalChannelType(FunctionalChannelType.SWITCH_MEASURING_CHANNEL)]
    public class SwitchMeasuringChannel : SwitchChannel
    {
        [JsonProperty("energyCounter")] 
        public double? EnergyCounter { get; private set; }

        [JsonProperty("currentPowerConsumption")]
        public double? CurrentPowerConsumption { get; private set; }

        [JsonProperty("energyMeterMode")]
        public EnergyMeterMode EnergyMeterMode { get; private set; }

        



    }
}