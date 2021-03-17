using AleRoe.HomematicIpApi.Json;
using Newtonsoft.Json;

namespace AleRoe.HomematicIpApi.Rpc
{
    [JsonConverter(typeof(EventConverter))]
    public interface IEvent
    {
        EventType PushEventType { get; set; }
    }
}