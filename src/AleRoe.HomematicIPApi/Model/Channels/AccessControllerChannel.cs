using Newtonsoft.Json;

namespace AleRoe.HomematicIpApi.Model.Channels
{
    [FunctionalChannelType(FunctionalChannelType.ACCESS_CONTROLLER_CHANNEL)]
    public class AccessControllerChannel : DeviceBaseChannel
    {
        //[JsonProperty("accessPointPriority")]
        //public int AccessPointPriority { get; private set; }

        [JsonProperty("carrierSenseLevel")]
        public double CarrierSenseLevel { get; private set; }

        [JsonProperty("dutyCycleLevel")]
        public double DutyCycleLevel { get; private set; }

        [JsonProperty("signalBrightness")]
        public double SignalBrightness { get; private set; }

        [JsonProperty("filteredMulticastRoutingEnabled")]
        public bool FilteredMulticastRoutingEnabled { get; private set; }
    }
}