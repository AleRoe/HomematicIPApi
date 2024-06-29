using AleRoe.HomematicIpApi.Model.Channels;
using AleRoe.HomematicIpApi.Model.Groups;
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

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [OptionalFeatureProperty(nameof(DeviceBaseChannel.LockJammed))]
        public bool? IOptionalFeatureDeviceErrorLockJammed { get; private set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [OptionalFeatureProperty(nameof(SwitchChannel.InternalLinkConfiguration))]
        public bool? IOptionalFeatureInternalLinkConfiguration { get; private set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [OptionalFeatureProperty(nameof(SwitchMeasuringChannel.EnergyMeterMode))]
        public bool? IOptionalFeatureEnergyMeterMode { get; private set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [OptionalFeatureProperty(nameof(DeviceBaseChannel.DeviceDriveModeError))]
        public bool? IFeatureDeviceDriveModeError { get; private set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [OptionalFeatureProperty(nameof(DeviceBaseChannel.DeviceDriveError))]
        public bool? IFeatureDeviceDriveError { get; private set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [OptionalFeatureProperty(nameof(DeviceBaseChannel.DeviceCommunicationError))]
        public bool? IFeatureDeviceCommunicationError { get; private set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        //[OptionalFeatureProperty(nameof(DeviceBaseChannel))]
        public bool? IOptionalFeaturePowerUpSwitchState { get; private set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        //[OptionalFeatureProperty(nameof(DeviceBaseChannel))]
        public bool? IOptionalFeatureLongPressSupported { get; private set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        //[OptionalFeatureProperty(nameof(DeviceBaseChannel.EnergyMeterMode))]
        public bool? IOptionalFeatureDoorBellSensorEventTimestamp { get; private set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        //[OptionalFeatureProperty(nameof(DeviceBaseChannel.EnergyMeterMode))]
        public bool? IOptionalFeatureAcousticSendStateEnabled { get; private set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        //[OptionalFeatureProperty(nameof(DeviceBaseChannel.EnergyMeterMode))]
        public bool? IOptionalFeatureHumidityLimitPre { get; private set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        //[OptionalFeatureProperty(nameof(DeviceBaseChannel.EnergyMeterMode))]
        public bool? IOptionalFeatureSwitchClimateFunction { get; private set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        //[OptionalFeatureProperty(nameof(DeviceBaseChannel.EnergyMeterMode))]
        public bool? IOptionalFeatureDimmerState { get; private set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [OptionalFeatureProperty(nameof(SwitchingGroup.ColorTemperature))]
        public bool? IOptionalFeatureColorTemperature { get; private set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [OptionalFeatureProperty(nameof(SwitchingGroup.SaturationLevel))]
        public bool? IOptionalFeatureHueSaturationValue { get; private set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        //[OptionalFeatureProperty(nameof(SwitchingGroup.SaturationLevel))]
        public bool? IOptionalFeatureColorTemperatureDynamicDaylight { get; private set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [OptionalFeatureProperty(nameof(SwitchingGroup.Dim2WarmActive))]
        public bool? IOptionalFeatureColorTemperatureDim2Warm { get; private set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        //[OptionalFeatureProperty(nameof(SwitchingGroup.SaturationLevel))]
        public bool? IOptionalFeatureDeviceOperationMode { get; private set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        //[OptionalFeatureProperty(nameof(SwitchingGroup.SaturationLevel))]
        public bool? IFeatureLightGroupActuatorChannel { get; private set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        //[OptionalFeatureProperty(nameof(SwitchingGroup.SaturationLevel))]
        public bool? IFeatureAccessAuthorizationActuatorChannel { get; private set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        //[OptionalFeatureProperty(nameof(SwitchingGroup.SaturationLevel))]
        public bool? IFeatureLightProfileActuatorChannel { get; private set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        //[OptionalFeatureProperty(nameof(SwitchingGroup.SaturationLevel))]
        public bool? IFeatureGarageGroupSensorChannel { get; private set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [OptionalFeatureProperty(nameof(SingleKeyChannel.DoublePressTime))]
        public bool? IOptionalFeatureDoublePressTime { get; private set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        //[OptionalFeatureProperty(nameof(SwitchingGroup.SaturationLevel))]
        public bool? IFeatureLightGroupSensorChannel { get; private set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        //[OptionalFeatureProperty(nameof(SwitchingGroup.SaturationLevel))]
        public bool? IFeatureAccessAuthorizationSensorChannel { get; private set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        //[OptionalFeatureProperty(nameof(SwitchingGroup.SaturationLevel))]
        public bool? IFeatureVentilationGroupSensorChannel { get; private set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        //[OptionalFeatureProperty(nameof(SwitchingGroup.SaturationLevel))]
        public bool? IFeatureShadingGroupSensorChannel { get; private set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        //[OptionalFeatureProperty(nameof(SwitchingGroup.SaturationLevel))]
        public bool? IOptionalFeatureLightSceneWithShortTimes { get; private set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        //[OptionalFeatureProperty(nameof(SwitchingGroup.SaturationLevel))]
        public bool? IOptionalFeatureLightScene { get; private set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        //[OptionalFeatureProperty(nameof(SwitchingGroup.SaturationLevel))]
        public bool? IFeatureDeviceDaliBusError { get; private set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        //[OptionalFeatureProperty(nameof(SwitchingGroup.SaturationLevel))]
        public bool? IOptionalFeatureDefaultLinkedGroup { get; private set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        //[OptionalFeatureProperty(nameof(SwitchingGroup.SaturationLevel))]
        public bool? IOptionalFeatureMotionSensorZones { get; private set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        //[OptionalFeatureProperty(nameof(SwitchingGroup.SaturationLevel))]
        public bool? IOptionalFeatureMotionSensorSensitivity { get; private set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        //[OptionalFeatureProperty(nameof(SwitchingGroup.SaturationLevel))]
        public bool? IOptionalFeatureBlockingPeriod { get; private set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        //[OptionalFeatureProperty(nameof(SwitchingGroup.SaturationLevel))]
        public bool? IFeatureDeviceSensorCommunicationError { get; private set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        //[OptionalFeatureProperty(nameof(SwitchingGroup.SaturationLevel))]
        public bool? IFeatureDeviceSensorError { get; private set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        //[OptionalFeatureProperty(nameof(SwitchingGroup.SaturationLevel))]
        public bool? IFeatureGarageGroupActuatorChannel { get; private set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        //[OptionalFeatureProperty(nameof(SwitchingGroup.SaturationLevel))]
        public bool? IOptionalFeatureCurrentDetectionBehavior { get; private set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        //[OptionalFeatureProperty(nameof(SwitchingGroup.SaturationLevel))]
        public bool? IOptionalFeatureFilteredMulticastRouter { get; private set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        //[OptionalFeatureProperty(nameof(SwitchingGroup.SaturationLevel))]
        public bool? IOptionalFeatureMotionSensorZoneSensitivity { get; private set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        //[OptionalFeatureProperty(nameof(SwitchingGroup.SaturationLevel))]
        public bool? IOptionalFeatureSwitchClimateHeatingCoolingEnabled { get; private set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        //[OptionalFeatureProperty(nameof(SwitchingGroup.SaturationLevel))]
        public bool? IOptionalFeatureWindowOpenTemperatureCooling { get; private set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool? IOptionalFeatureInvertedDisplayColors { get; private set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool? IOptionalFeatureOperationDays { get; private set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool? IOptionalFeatureDisplayMode { get; private set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool? IOptionalFeatureDeviceAliveSignalEnabled { get; private set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool? IOptionalFeatureDimmerMode { get; private set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool? IOptionalFeatureLedDimmingRange { get; private set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool? IOptionalFeatureOnMinLevel { get; private set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool? IOptionalFeatureControlsMountingOrientation { get; private set; }


    }
}
