using System;
using AleRoe.HomematicIpApi.Json;
using Newtonsoft.Json;

namespace AleRoe.HomematicIpApi.Model.Client
{
    public class Client
    {
        [JsonProperty("clientType")] 
        public ClientType ClientType { get; private set; }

        [JsonProperty("id")] 
        public Guid Id { get; private set; }

        [JsonProperty("label")] 
        public string Label { get; private set; }

        [JsonProperty("homeId")] 
        public Guid HomeId { get; private set; }

        [JsonProperty("lastSeenAtTimestamp", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(UnixTimestampConverter))]
        public DateTime? LastSeenAtTimestamp { get; private set; }

        [JsonProperty("createdAtTimestamp", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(UnixTimestampConverter))]
        public DateTime? CreatedAtTimestamp { get; private set; }

        [JsonProperty("inactive", NullValueHandling = NullValueHandling.Include)]
        public bool? Inactive { get; private set; }

        [JsonProperty("c2cServiceIdentifier", NullValueHandling = NullValueHandling.Ignore)]
        public string C2CServiceIdentifier { get; private set; }

        [JsonProperty("userRole", NullValueHandling = NullValueHandling.Ignore)]
        public object UserRole { get; private set; }

        [JsonProperty("userRoleChangeStatus", NullValueHandling = NullValueHandling.Ignore)]
        public object UserRoleChangeStatus { get; private set; }

        [JsonProperty("adminInitializationRequired")]
        public bool? AdminInitializationRequired { get; private set; }

        [JsonProperty("hasC2cServiceToken")]
        public bool? HasC2cServiceToken { get; private set; }

        public override string ToString()
        {
            return Label;
        }

        public bool ShouldSerializeInactive()
        {
            // don't serialize the Inactive property if C2CServiceIdentifier is set
            return !string.IsNullOrWhiteSpace(C2CServiceIdentifier);
        }

    }
}