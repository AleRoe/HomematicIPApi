using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace AleRoe.HomematicIpApi.Model.Channels
{

    public abstract class FunctionalChannel : IFunctionalChannel
    {
        [JsonProperty("index")] 
        public int Index { get; private set; }

        [JsonProperty("groupIndex")] 
        public int GroupIndex { get; private set; }

        [JsonProperty("label")]
        public string Label { get; private set; }

        [JsonProperty("deviceId")]
        public string DeviceId { get; private set; }

        [JsonProperty("functionalChannelType")]
        public FunctionalChannelType FunctionalChannelType { get; private set; }

        [JsonProperty("groups")] 
        public List<Guid> Groups { get; private set; }
                
        [JsonProperty("supportedOptionalFeatures", NullValueHandling = NullValueHandling.Ignore)]
        public SupportedOptionalFeatures SupportedOptionalFeatures { get; private set; }
    }
}