using System.Collections.Generic;
using AleRoe.HomematicIpApi.Json;
using Newtonsoft.Json;

namespace AleRoe.HomematicIpApi.Rpc
{
    public class PushEventArgs
    {
        [JsonProperty("events")]
        [JsonConverter(typeof(DictionaryToListConverter<IEvent>))]
        public List<IEvent> Events { get; set; }

        [JsonProperty("origin")] 
        public Origin Origin { get; set; }
    }
}