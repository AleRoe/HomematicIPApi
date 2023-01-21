using System;
using System.Collections.Generic;
using System.Data;
using AleRoe.HomematicIpApi.Json;
using AleRoe.HomematicIpApi.Model;
using Microsoft.VisualBasic;
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
        public override string ToString() => $"Origin: {Origin} / AccessPointId: {AccessPointId} / Events: {Events.Count} / Timestamp: {Timestamp} ";
        
    }
}