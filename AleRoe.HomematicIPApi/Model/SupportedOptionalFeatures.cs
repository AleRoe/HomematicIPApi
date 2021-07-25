using AleRoe.HomematicIpApi.Model.Channels;
using Newtonsoft.Json;

namespace AleRoe.HomematicIpApi.Model
{
    public class SupportedOptionalFeatures
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [OptionalFeatureProperty(nameof(DeviceBaseChannel.CoProFaulty))]
        public bool? IFeatureDeviceCoProError { get; private set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [OptionalFeatureProperty(nameof(DeviceBaseChannel.CoProRestartNeeded))]
        public bool? IFeatureDeviceCoProRestart { get; private set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [OptionalFeatureProperty(nameof(DeviceBaseChannel.CoProUpdateFailure))]
        public bool? IFeatureDeviceCoProUpdate { get; private set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [OptionalFeatureProperty(nameof(DeviceBaseChannel.DeviceId))]
        public bool? IFeatureDeviceIdentify { get; private set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [OptionalFeatureProperty(nameof(DeviceBaseChannel.DeviceOverheated))]
        public bool? IFeatureDeviceOverheated { get; private set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [OptionalFeatureProperty(nameof(DeviceBaseChannel.DeviceOverloaded))]
        public bool? IFeatureDeviceOverloaded { get; private set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [OptionalFeatureProperty(nameof(DeviceBaseChannel.DevicePowerFailureDetected))]
        public bool? IFeatureDevicePowerFailure { get; private set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [OptionalFeatureProperty(nameof(DeviceBaseChannel.TemperatureOutOfRange))]
        public bool? IFeatureDeviceTemperatureOutOfRange { get; private set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [OptionalFeatureProperty(nameof(DeviceBaseChannel.DeviceUnderVoltage))]
        public bool? IFeatureDeviceUndervoltage { get; private set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [OptionalFeatureProperty(nameof(DeviceBaseChannel.MulticastRoutingEnabled))]
        public bool? IFeatureMulticastRouter { get; private set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [OptionalFeatureProperty(nameof(DeviceBaseChannel.DutyCycle))]
        public bool? IOptionalFeatureDutyCycle { get; private set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [OptionalFeatureProperty(nameof(DeviceBaseChannel.LowBat))]
        public bool? IOptionalFeatureLowBat { get; private set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [OptionalFeatureProperty(nameof(DeviceBaseChannel.BusConfigMismatch))]
        public bool? IFeatureBusConfigMismatch { get; private set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [OptionalFeatureProperty(nameof(DeviceBaseChannel.RssiDeviceValue))]
        public bool? IFeatureRssiValue { get; private set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [OptionalFeatureProperty(nameof(DeviceBaseChannel.ShortCircuitDataLine))]
        public bool? IFeatureShortCircuitDataLine { get; private set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [OptionalFeatureProperty(nameof(DeviceBaseChannel.PowerShortCircuit))]
        public bool? IFeaturePowerShortCircuit { get; private set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [OptionalFeatureProperty(nameof(DeviceBaseChannel.ParticulateMatterSensorCommunicationError))]
        public bool? IFeatureDeviceParticulateMatterSensorCommunicationError { get; private set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [OptionalFeatureProperty(nameof(DeviceBaseChannel.TemperatureHumiditySensorError))]
        public bool? IFeatureDeviceTemperatureHumiditySensorError { get; private set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [OptionalFeatureProperty(nameof(DeviceBaseChannel.TemperatureHumiditySensorCommunicationError))]
        public bool? IFeatureDeviceTemperatureHumiditySensorCommunicationError { get; private set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [OptionalFeatureProperty(nameof(DeviceBaseChannel.ParticulateMatterSensorError))]
        public bool? IFeatureDeviceParticulateMatterSensorError { get; private set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [OptionalFeatureProperty(nameof(DeviceBaseChannel.MountingOrientation))]
        public bool? IOptionalFeatureMountingOrientation { get; private set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [OptionalFeatureProperty(nameof(DeviceBaseChannel.ProfilePeriodLimitReached))]
        public bool? IFeatureProfilePeriodLimit { get; private set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [OptionalFeatureProperty(nameof(DeviceBaseChannel.DisplayContrast))]
        public bool? IOptionalFeatureDisplayContrast { get; private set; }
    }
}
