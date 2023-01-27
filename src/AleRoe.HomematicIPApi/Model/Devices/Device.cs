using AleRoe.HomematicIpApi.Json;
using AleRoe.HomematicIpApi.Model.Channels;
using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace AleRoe.HomematicIpApi.Model.Devices
{
    public abstract class Device : IDevice
    {
        [JsonProperty("id")] 
        public string Id { get; private set; }

        [JsonProperty("homeId")] 
        public Guid HomeId { get; private set; }

        [JsonProperty("label")] 
        public string Label { get; private set; }

        [JsonProperty("lastStatusUpdate")]
        [JsonConverter(typeof(UnixTimestampConverter))]
        public DateTime LastStatusUpdate { get; private set; }

        [JsonProperty("type")] 
        public DeviceType Type { get; private set; }

        [JsonProperty("updateState")]
        public DeviceUpdateState UpdateState { get; private set; } = DeviceUpdateState.UP_TO_DATE;

        [JsonProperty("firmwareVersion")] 
        public string FirmwareVersion { get; private set; }

        [JsonProperty("firmwareVersionInteger")]
        public long FirmwareVersionInteger { get; private set; }

        [JsonProperty("availableFirmwareVersion")]
        public string AvailableFirmwareVersion { get; private set; }

        [JsonProperty("modelType")] 
        public string ModelType { get; private set; }

        [JsonProperty("modelId")] 
        public long ModelId { get; private set; }

        [JsonProperty("oem")] 
        public string Oem { get; private set; }

        [JsonProperty("manufacturerCode")] 
        public long ManufacturerCode { get; private set; }

        [JsonProperty("serializedGlobalTradeItemNumber")]
        public string SerializedGlobalTradeItemNumber { get; private set; }

        [JsonProperty("permanentlyReachable")] 
        public bool PermanentlyReachable { get; private set; }

        [JsonProperty("liveUpdateState")] 
        public LiveUpdateState LiveUpdateState { get; private set; }

        [JsonProperty("functionalChannels")] 
        public FunctionalChannelCollection FunctionalChannels { get; private set; }

        [JsonProperty("connectionType")] 
        public ConnectionType ConnectionType { get; private set; }

        [JsonProperty("deviceArchetype")]
        public DeviceArchetype DeviceArchetype { get; private set; }

        [JsonIgnore] 
        public IHomematicRpcService Service { get; protected set; }

        
        [OnDeserialized]
        internal void OnDeserializedMethod(StreamingContext context)
        {
            if (context.Context is IHomematicRpcService service)
            {
                this.Service = service;
            }
        }
    }
}
