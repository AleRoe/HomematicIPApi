using AleRoe.HomematicIpApi.Extensions;
using AleRoe.HomematicIpApi.Model.Channels;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace AleRoe.HomematicIpApi.Model.Devices
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="AleRoe.HomematicIpApi.Model.Devices.IDevice" />
    [FunctionalChannelType(FunctionalChannelType.DEVICE_BASE)]
    public abstract class DeviceBase : Device
    {
        [JsonIgnore]
        public bool UnReach { get; private set; }

        [JsonIgnore]
        public bool? LowBat { get ; private set ; }

        [JsonIgnore]
        public bool RouterModuleSupported { get; private set; }

        [JsonIgnore]
        public bool RouterModuleEnabled { get; private set; }

        [JsonIgnore]
        public long? RssiDeviceValue { get; private set; }

        [JsonIgnore]
        public long? RssiPeerValue { get; private set; }

        [JsonIgnore]
        public bool DutyCycle { get; private set; }

        [JsonIgnore]
        public bool ConfigPending { get; private set; }

        [JsonIgnore]
        public bool? DeviceOverheated { get; private set; }

        [JsonIgnore]
        public bool? DeviceOverloaded { get; private set; }

        [JsonIgnore]
        public bool? DeviceUnderVoltage { get; private set; }

        [JsonIgnore]
        public bool? TemperatureOutOfRange { get; private set; }

        [JsonIgnore]
        public bool? CoProFaulty { get; private set; }

        [JsonIgnore]
        public bool? CoProRestartNeeded { get; private set; }

        [JsonIgnore]
        public bool? CoProUpdateFailure { get; private set; }

        
        public override string ToString()
        {
            return Label;
        }

        [OnDeserialized]
        internal new void OnDeserializedMethod(StreamingContext context)
        {
            this.GetFunctionalChannel<DeviceBaseChannel>().CopyTo(this);
            this.GetFunctionalChannel<DeviceBaseChannel>().SetSupportedOptionalFeatures(this);
        }
    }
}