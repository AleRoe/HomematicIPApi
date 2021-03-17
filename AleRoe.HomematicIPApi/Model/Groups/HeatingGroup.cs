using Newtonsoft.Json;

namespace AleRoe.HomematicIpApi.Model.Groups
{
    [GroupType(GroupType.HEATING)]
    public class HeatingGroup : Group
    {
        [JsonProperty("windowOpenTemperature")]
        public double WindowOpenTemperature { get; set; }

        [JsonProperty("setPointTemperature")]
        public object SetPointTemperature { get; set; }

        [JsonProperty("minTemperature")]
        public double MinTemperature { get; set; }

        [JsonProperty("maxTemperature")]
        public double MaxTemperature { get; set; }

        [JsonProperty("windowState")]
        public object WindowState { get; set; }

        [JsonProperty("cooling")]
        public object Cooling { get; set; }

        [JsonProperty("partyMode")]
        public bool PartyMode { get; set; }

        [JsonProperty("controlMode")]
        public string ControlMode { get; set; }

        [JsonProperty("profiles")]
        public ProfileCollection Profiles { get; set; }

        [JsonProperty("activeProfile")]
        public string ActiveProfile { get; set; }

        [JsonProperty("boostMode")]
        public bool BoostMode { get; set; }

        [JsonProperty("boostDuration")]
        public int BoostDuration { get; set; }

        [JsonProperty("actualTemperature")]
        public object ActualTemperature { get; set; }

        [JsonProperty("humidity")]
        public object Humidity { get; set; }

        [JsonProperty("coolingAllowed")]
        public bool CoolingAllowed { get; set; }

        [JsonProperty("coolingIgnored")]
        public bool CoolingIgnored { get; set; }

        [JsonProperty("ecoAllowed")]
        public bool EcoAllowed { get; set; }

        [JsonProperty("ecoIgnored")]
        public bool EcoIgnored { get; set; }

        [JsonProperty("controllable")]
        public bool Controllable { get; set; }

        [JsonProperty("boostAllowed")]
        public bool BoostAllowed { get; set; }

        [JsonProperty("floorHeatingMode")]
        public string FloorHeatingMode { get; set; }

        [JsonProperty("humidityLimitEnabled")]
        public bool HumidityLimitEnabled { get; set; }

        [JsonProperty("humidityLimitValue")]
        public int HumidityLimitValue { get; set; }

        [JsonProperty("externalClockEnabled")]
        public bool ExternalClockEnabled { get; set; }

        [JsonProperty("externalClockHeatingTemperature")]
        public double ExternalClockHeatingTemperature { get; set; }

        [JsonProperty("externalClockCoolingTemperature")]
        public double ExternalClockCoolingTemperature { get; set; }

        [JsonProperty("valvePosition")]
        public object ValvePosition { get; set; }

        [JsonProperty("sabotage")]
        public object Sabotage { get; set; }

        [JsonProperty("valveSilentModeSupported")]
        public bool ValveSilentModeSupported { get; set; }

        [JsonProperty("valveSilentModeEnabled")]
        public bool ValveSilentModeEnabled { get; set; }

        [JsonProperty("lastSetPointReachedTimestamp")]
        public long LastSetPointReachedTimestamp { get; set; }

        [JsonProperty("lastSetPointUpdatedTimestamp")]
        public long LastSetPointUpdatedTimestamp { get; set; }

        [JsonProperty("heatingFailureSupported")]
        public bool HeatingFailureSupported { get; set; }
    }
}