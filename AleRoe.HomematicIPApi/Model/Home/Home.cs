using AleRoe.HomematicIpApi.Json;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace AleRoe.HomematicIpApi.Model.Home
{
    public class Home
    {
        [JsonProperty("weather")] 
        public Weather Weather { get; set; }

        [JsonProperty("metaGroups")] 
        public List<Guid> MetaGroups { get; set; }

        [JsonProperty("clients")] 
        public List<Guid> Clients { get; set; }

        [JsonProperty("connected")] 
        public bool Connected { get; set; }

        [JsonProperty("currentAPVersion")] 
        public string CurrentAPVersion { get; set; }

        [JsonProperty("availableAPVersion", NullValueHandling= NullValueHandling.Include)] 
        public string AvailableAPVersion { get; set; }

        [JsonProperty("timeZoneId")] 
        public string TimeZoneId { get; set; }

        [JsonProperty("location")] 
        public Location Location { get; set; }

        [JsonProperty("pinAssigned")] 
        public bool PinAssigned { get; set; }

        [JsonProperty("isLiveUpdateSupported")]
        public bool? IsLiveUpdateSupported { get; set; }

        [JsonProperty("dutyCycle")] 
        public double? DutyCycle { get; set; }

        [JsonProperty("carrierSense", NullValueHandling = NullValueHandling.Include)] 
        public double? CarrierSense { get; set; }

        [JsonProperty("updateState")] 
        public LiveUpdateState UpdateState { get; set; }

        [JsonProperty("powerMeterUnitPrice")] 
        public double PowerMeterUnitPrice { get; set; }

        [JsonProperty("powerMeterCurrency")] 
        public string PowerMeterCurrency { get; set; }

        [JsonProperty("deviceUpdateStrategy")] 
        public DeviceUpdateStrategy DeviceUpdateStrategy { get; set; }

        [JsonProperty("lastReadyForUpdateTimestamp")]
        [JsonConverter(typeof(UnixTimestampConverter))]
        public DateTime LastReadyForUpdateTimestamp { get; set; }

        [JsonProperty("functionalHomes")] 
        public FunctionalHomes FunctionalHomes { get; set; }

        [JsonProperty("inboxGroup")] 
        public Guid InboxGroup { get; set; }

        [JsonProperty("apExchangeClientId", NullValueHandling = NullValueHandling.Include)] 
        public object ApExchangeClientId { get; set; }

        [JsonProperty("apExchangeState")] 
        public ApExchangeState ApExchangeState { get; set; }

        [JsonProperty("voiceControlSettings")] 
        public VoiceControlSettings VoiceControlSettings { get; set; }

        [JsonProperty("ruleGroups")] 
        public List<Guid> RuleGroups { get; set; }

        [JsonProperty("ruleMetaDatas")]
        public RuleMetaDatasCollection RuleMetaDatas { get; set; }

        [JsonProperty("liveOTAUStatus")] 
        public LiveOTAUStatus LiveOTAUStatus { get; set; }

        [JsonProperty("liveUpdateSupported")] 
        public bool? LiveUpdateSupported { get; set; }

        [JsonProperty("id")] 
        public string Id { get; set; }

        [JsonProperty("accessPointUpdateStates")]
        public AccessPointUpdateStatesDictionary AccessPointUpdateStates { get; set; }

    }
}