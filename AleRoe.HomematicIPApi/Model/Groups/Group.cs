using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using AleRoe.HomematicIpApi.Json;
using Newtonsoft.Json;

namespace AleRoe.HomematicIpApi.Model.Groups
{
    public abstract class Group : IGroup
    {
        [JsonProperty("id")] 
        public Guid Id { get; set; }

        [JsonProperty("homeId")] 
        public Guid HomeId { get; set; }

        [JsonProperty("metaGroupId")]
        public Guid? MetaGroupId { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonConverter(typeof(UnixTimestampConverter))]
        [JsonProperty("lastStatusUpdate")]
        public DateTime LastStatusUpdate { get; set; }

        [JsonProperty("unreach")]
        public bool? UnReach { get; set; }

        [JsonProperty("lowBat")]
        public bool? LowBat { get; set; }

        [JsonProperty("dutyCycle")]
        public bool? DutyCycle { get; set; }

        [JsonProperty("type")]
        public GroupType Type { get; set; }
        
        [JsonProperty("channels")] 
        public List<Channel> Channels { get; set; }

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