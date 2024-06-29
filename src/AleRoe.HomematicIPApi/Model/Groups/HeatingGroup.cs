using Newtonsoft.Json;

namespace AleRoe.HomematicIpApi.Model.Groups
{
    [GroupType(GroupType.HEATING)]
    public class HeatingGroup : Group
    {
        [JsonProperty("windowOpenTemperature")]
        public double WindowOpenTemperature { get; private set; }

        [JsonProperty("setPointTemperature")]
        public object SetPointTemperature { get; private set; }

        [JsonProperty("minTemperature")]
        public double MinTemperature { get; private set; }

        [JsonProperty("maxTemperature")]
        public double MaxTemperature { get; private set; }

        [JsonProperty("windowState")]
        public object WindowState { get; private set; }

        [JsonProperty("cooling")]
        public object Cooling { get; private set; }

        [JsonProperty("partyMode")]
        public bool PartyMode { get; private set; }

        [JsonProperty("controlMode")]
        public string ControlMode { get; private set; }

        [JsonProperty("profiles")]
        public ProfileCollection Profiles { get; private set; }

        [JsonProperty("activeProfile")]
        public string ActiveProfile { get; private set; }

        [JsonProperty("boostMode")]
        public bool BoostMode { get; private set; }

        [JsonProperty("boostDuration")]
        public int BoostDuration { get; private set; }

        [JsonProperty("actualTemperature")]
        public object ActualTemperature { get; private set; }

        [JsonProperty("humidity")]
        public object Humidity { get; private set; }

        [JsonProperty("coolingAllowed")]
        public bool CoolingAllowed { get; private set; }

        [JsonProperty("coolingIgnored")]
        public bool CoolingIgnored { get; private set; }

        [JsonProperty("ecoAllowed")]
        public bool EcoAllowed { get; private set; }

        [JsonProperty("ecoIgnored")]
        public bool EcoIgnored { get; private set; }

        [JsonProperty("controllable")]
        public bool Controllable { get; private set; }

        [JsonProperty("boostAllowed")]
        public bool? BoostAllowed { get; private set; }

        [JsonProperty("floorHeatingMode")]
        public string FloorHeatingMode { get; private set; }

        [JsonProperty("humidityLimitEnabled")]
        public bool HumidityLimitEnabled { get; private set; }

        [JsonProperty("humidityLimitValue")]
        public int HumidityLimitValue { get; private set; }

        [JsonProperty("externalClockEnabled")]
        public bool ExternalClockEnabled { get; private set; }

        [JsonProperty("externalClockHeatingTemperature")]
        public double ExternalClockHeatingTemperature { get; private set; }

        [JsonProperty("externalClockCoolingTemperature")]
        public double ExternalClockCoolingTemperature { get; private set; }

        [JsonProperty("valvePosition")]
        public object ValvePosition { get; private set; }

        [JsonProperty("sabotage")]
        public object Sabotage { get; private set; }

        [JsonProperty("valveSilentModeSupported")]
        public bool ValveSilentModeSupported { get; private set; }

        [JsonProperty("valveSilentModeEnabled")]
        public bool ValveSilentModeEnabled { get; private set; }

        [JsonProperty("lastSetPointReachedTimestamp")]
        public long LastSetPointReachedTimestamp { get; private set; }

        [JsonProperty("lastSetPointUpdatedTimestamp")]
        public long LastSetPointUpdatedTimestamp { get; private set; }

        [JsonProperty("heatingFailureSupported")]
        public bool HeatingFailureSupported { get; private set; }

        [JsonProperty("humidityLimiterAlarm")]
        public object HumidityLimiterAlarm { get; private set; }

        [JsonProperty("humidityLimitPreEnabled")]
        public bool HumidityLimitPreEnabled { get; private set; }

        [JsonProperty("humidityLimitPreValue")]
        public int HumidityLimitPreValue { get; private set; }

        [JsonProperty("humidityLimiterPreAlarm")]
        public object HumidityLimiterPreAlarm { get; private set; }

        [JsonProperty("switchClimateFunction")]
        public SwitchClimateFunction SwitchClimateFunction { get; private set; }

        [JsonProperty("supportedOptionalFeatures")]
        public SupportedOptionalFeatures SupportedOptionalFeatures { get; private set; }

        [JsonProperty("processing")]
        public object Processing { get; private set; }

        [JsonProperty("ventilationState")]
        public object VentilationState { get; private set; }

        [JsonProperty("ventilationLevel")]
        public object VentilationLevel { get; private set; }

        [JsonProperty("switchClimateCoolingEnable")]
        public bool SwitchClimateCoolingEnable { get; private set; }

        [JsonProperty("switchClimateHeatingEnable")]
        public bool SwitchClimateHeatingEnable { get; private set; }

        [JsonProperty("windowOpenTemperatureCooling")]
        public object WindowOpenTemperatureCooling { get; private set; }

        [JsonProperty("controlDifferantialTemperature")]
        public double ControlDifferantialTemperature { get; private set; }
        
        [JsonProperty("duration")]
        public double Duration { get; private set; }

        [JsonProperty("valveActualTemperature")]
        public double? ValveActualTemperature { get; private set; }
    }
}