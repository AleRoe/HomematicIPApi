using System;
using AleRoe.HomematicIpApi.Json;
using Newtonsoft.Json;

namespace AleRoe.HomematicIpApi.Model.Client
{
    public abstract class Client : IClient
    {
        [JsonProperty("clientType")]
        public ClientType ClientType { get; private set; }

        [JsonProperty("id")]
        public Guid Id { get; private set; }

        [JsonProperty("label")]
        public string Label { get; private set; }

        [JsonProperty("homeId")]
        public Guid HomeId { get; private set; }

        [JsonProperty("lastSeenAtTimestamp")]
        [JsonConverter(typeof(UnixTimestampConverter))]
        public DateTime? LastSeenAtTimestamp { get; private set; }

        [JsonProperty("createdAtTimestamp")]
        [JsonConverter(typeof(UnixTimestampConverter))]
        public DateTime? CreatedAtTimestamp { get; private set; }

        public override string ToString() => Label;
    }
}