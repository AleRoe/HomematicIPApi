using System;
using System.Collections.Generic;
using AleRoe.HomematicIpApi.Json;
using Newtonsoft.Json;

namespace AleRoe.HomematicIpApi.Rpc
{
    public class PushEventArgs
    {
        [JsonProperty("events")]
        [JsonConverter(typeof(DictionaryToListConverter<IEvent>))]
        public List<IEvent> Events { get; private set; }

        [JsonProperty("origin")] 
        public Origin Origin { get; private set; }

        [JsonProperty("accessPointId")]
        public string AccessPointId { get; private set; }

        [JsonProperty("timestamp")]
        public long Timestamp { get; private set; }
    }
}