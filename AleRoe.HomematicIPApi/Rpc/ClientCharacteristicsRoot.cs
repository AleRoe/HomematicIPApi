using Newtonsoft.Json;

namespace AleRoe.HomematicIpApi.Rpc
{
    public class ClientCharacteristicsRoot
    {
        public ClientCharacteristicsRoot(string id)
        {
            Id = id;
            ClientCharacteristics = new ClientCharacteristics();
        }

        [JsonProperty("clientCharacteristics")]
        public ClientCharacteristics ClientCharacteristics { get; set; }

        [JsonProperty("id")] public string Id { get; set; }
    }
}