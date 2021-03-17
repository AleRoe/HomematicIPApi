using Newtonsoft.Json;

namespace AleRoe.HomematicIpApi.Rpc
{
    public class Origin
    {
        [JsonProperty("originType")] public string OriginType { get; set; }

        [JsonProperty("id")] public string Id { get; set; }
    }
}