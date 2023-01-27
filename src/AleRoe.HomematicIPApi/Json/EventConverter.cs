using AleRoe.HomematicIpApi.Rpc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace AleRoe.HomematicIpApi.Json
{
    internal class EventConverter : JsonConverter<IEvent>
    {
        public override IEvent ReadJson(JsonReader reader, Type objectType, IEvent existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var jsonObject = JObject.Load(reader);
            var eventType = jsonObject.SelectToken("pushEventType")?.ToObject<EventType>();

            Type type = default;
            if (eventType == EventType.DEVICE_CHANGED || eventType == EventType.DEVICE_ADDED || eventType == EventType.DEVICE_REMOVED)
                type = typeof(DeviceEvent);
            else if (eventType == EventType.GROUP_CHANGED || eventType == EventType.GROUP_ADDED || eventType == EventType.GROUP_REMOVED)
                type = typeof(GroupEvent);
            else if (eventType == EventType.CLIENT_ADDED|| eventType == EventType.CLIENT_CHANGED|| eventType == EventType.CLIENT_REMOVED)
                type = typeof(ClientEvent);
            else if (eventType == EventType.HOME_CHANGED)
                type = typeof(HomeEvent);

            if (type == null)
                throw new InvalidOperationException($"Could not find Event with type {eventType}");

            if (Activator.CreateInstance(type) is IEvent result)
            {
                serializer.Populate(jsonObject.CreateReader(), result);
                return result;
            }
            throw new InvalidOperationException($"Could not create Event with type {type}");
        }

        public override void WriteJson(JsonWriter writer, IEvent value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    }
}