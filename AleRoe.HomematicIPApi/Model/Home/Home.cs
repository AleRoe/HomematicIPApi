using AleRoe.HomematicIpApi.Json;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace AleRoe.HomematicIpApi.Model.Home
{
    public class Home
    {
        [JsonProperty("weather")] 
        public Weather Weather { get; private set; }

        [JsonProperty("metaGroups")] 
        public List<Guid> MetaGroups { get; private set; }

        [JsonProperty("clients")] 
        public List<Guid> Clients { get; private set; }

        [JsonProperty("connected")] 
        public bool Connected { get; private set; }

        [JsonProperty("currentAPVersion")] 
        public string CurrentAPVersion { get; private set; }

        [JsonProperty("availableAPVersion", NullValueHandling= NullValueHandling.Include)] 
        public string AvailableAPVersion { get; private set; }

        [JsonProperty("timeZoneId")] 
        public string TimeZoneId { get; private set; }

        [JsonProperty("location")] 
        public Location Location { get; private set; }

        [JsonProperty("pinAssigned")] 
        public bool PinAssigned { get; private set; }

        [JsonProperty("isLiveUpdateSupported")]
        public bool? IsLiveUpdateSupported { get; private set; }

        [JsonProperty("dutyCycle")] 
        public double? DutyCycle { get; private set; }

        [JsonProperty("carrierSense", NullValueHandling = NullValueHandling.Include)] 
        public double? CarrierSense { get; private set; }

        [JsonProperty("updateState")] 
        public LiveUpdateState UpdateState { get; private set; }

        [JsonProperty("powerMeterUnitPrice")] 
        public double PowerMeterUnitPrice { get; private set; }

        [JsonProperty("powerMeterCurrency")] 
        public string PowerMeterCurrency { get; private set; }

        [JsonProperty("deviceUpdateStrategy")] 
        public DeviceUpdateStrategy DeviceUpdateStrategy { get; private set; }

        [JsonProperty("lastReadyForUpdateTimestamp")]
        [JsonConverter(typeof(UnixTimestampConverter))]
        public DateTime LastReadyForUpdateTimestamp { get; private set; }

        [JsonProperty("functionalHomes")] 
        public FunctionalHomes FunctionalHomes { get; private set; }

        [JsonProperty("inboxGroup")] 
        public Guid InboxGroup { get; private set; }

        [JsonProperty("apExchangeClientId", NullValueHandling = NullValueHandling.Include)] 
        public object ApExchangeClientId { get; private set; }

        [JsonProperty("apExchangeState")] 
        public ApExchangeState ApExchangeState { get; private set; }

        [JsonProperty("voiceControlSettings")] 
        public VoiceControlSettings VoiceControlSettings { get; private set; }

        [JsonProperty("ruleGroups")] 
        public List<Guid> RuleGroups { get; private set; }

        [JsonProperty("ruleMetaDatas")]
        public RuleMetaDatasCollection RuleMetaDatas { get; private set; }

        [JsonProperty("liveOTAUStatus")] 
        public LiveOTAUStatus LiveOTAUStatus { get; private set; }

        [JsonProperty("liveUpdateSupported")] 
        public bool? LiveUpdateSupported { get; private set; }

        [JsonProperty("id")] 
        public string Id { get; private set; }

        [JsonProperty("accessPointUpdateStates")]
        public AccessPointUpdateStatesDictionary AccessPointUpdateStates { get; private set; }

        [JsonProperty("pinChangeTimestamp", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(UnixTimestampConverter))]
        public DateTime PinChangeTimestamp { get; private set; }

        [JsonProperty("pinChangeClientLabel")]
        public string PinChangeClientLabel { get; private set; }

    }
}