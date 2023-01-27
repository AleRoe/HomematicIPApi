using AleRoe.HomematicIpApi.Model.Client;
using Newtonsoft.Json;

namespace AleRoe.HomematicIpApi.Rpc
{
    public class ClientEvent
    {
        [JsonProperty("client")]
        public Client Client { get; private set; }

        public override string ToString()
        {
            return $"{Client.Label}";
        }
    }
}