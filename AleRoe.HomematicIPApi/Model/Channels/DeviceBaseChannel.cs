﻿using Newtonsoft.Json;

namespace AleRoe.HomematicIpApi.Model.Channels
{
    [FunctionalChannelType(FunctionalChannelType.DEVICE_BASE)]
    public class DeviceBaseChannel : FunctionalChannel
    {
        [JsonProperty("unreach")] 
        public bool? UnReach { get; private set; }

        [JsonProperty("lowBat")]
        public bool? LowBat { get; private set; }

        [JsonProperty("routerModuleEnabled")] 
        public bool RouterModuleEnabled { get; private set; }

        [JsonProperty("routerModuleSupported")]
        public bool RouterModuleSupported { get; private set; }

        [JsonProperty("rssiDeviceValue")] 
        public long? RssiDeviceValue { get; private set; }

        [JsonProperty("rssiPeerValue")] 
        public long? RssiPeerValue { get; private set; }

        [JsonProperty("dutyCycle")]
        public bool? DutyCycle { get; private set; }

        [JsonProperty("configPending")]
        public bool ConfigPending { get; private set; }

        [JsonProperty("coProFaulty")] 
        public bool CoProFaulty { get;  private set; }

        [JsonProperty("coProRestartNeeded")]
        public bool CoProRestartNeeded { get; private set; }

        [JsonProperty("coProUpdateFailure")]
        public bool CoProUpdateFailure { get; private set; }

        [JsonProperty("deviceOverheated")]
        public bool? DeviceOverheated { get; private set; }

        [JsonProperty("deviceOverloaded")]
        public bool DeviceOverloaded { get; private set; }

        [JsonProperty("devicePowerFailureDetected")]
        public bool DevicePowerFailureDetected { get; private set; }

        [JsonProperty("deviceUndervoltage")]
        public bool DeviceUnderVoltage { get; private set; }

        [JsonProperty("temperatureOutOfRange")]
        public bool TemperatureOutOfRange { get; private set; }

        [JsonProperty("supportedOptionalFeatures")]
        public SupportedOptionalFeatures SupportedOptionalFeatures { get; private set; }

        [JsonProperty("multicastRoutingEnabled")]
        public bool MulticastRoutingEnabled { get; private set; }

        [JsonProperty("busConfigMismatch")]
        public bool? BusConfigMismatch { get; private set; }

        [JsonProperty("powerShortCircuit")]
        public bool? PowerShortCircuit { get; private set; }

        [JsonProperty("shortCircuitDataLine")]
        public object ShortCircuitDataLine { get; private set; }

        [JsonProperty("particulateMatterSensorError")]
        public bool? ParticulateMatterSensorError { get; private set; }

        [JsonProperty("particulateMatterSensorCommunicationError")]
        public bool? ParticulateMatterSensorCommunicationError { get; private set; }
        
        [JsonProperty("temperatureHumiditySensorError")]
        public bool? TemperatureHumiditySensorError { get; private set; }

        [JsonProperty("temperatureHumiditySensorCommunicationError")]
        public bool? TemperatureHumiditySensorCommunicationError { get; private set; }

        [JsonProperty("mountingOrientation")]
        public object MountingOrientation { get; private set; }
    }
}