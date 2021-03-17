using Newtonsoft.Json;

namespace AleRoe.HomematicIpApi.Rpc
{
    public abstract class Event : IEvent
    {
        [JsonProperty("pushEventType")] 
        public EventType PushEventType { get; set; }
    }
}