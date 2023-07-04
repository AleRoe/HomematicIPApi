using Newtonsoft.Json;

namespace AleRoe.HomematicIpApi.Model.Client
{
    [ClientType(ClientType.C2C)]
    internal class C2cClient : Client
    {
        [JsonProperty("inactive")]
        public bool? Inactive { get; private set; }

        [JsonProperty("c2cServiceIdentifier")]
        public string C2CServiceIdentifier { get; private set; }

        [JsonProperty("hasC2cServiceToken")]
        public bool HasC2cServiceToken { get; private set; }
    }
}
