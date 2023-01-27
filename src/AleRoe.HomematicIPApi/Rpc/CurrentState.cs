using AleRoe.HomematicIpApi.Model.Client;
using AleRoe.HomematicIpApi.Model.Devices;
using AleRoe.HomematicIpApi.Model.Groups;
using AleRoe.HomematicIpApi.Model.Home;
using Newtonsoft.Json;

namespace AleRoe.HomematicIpApi.Rpc
{
    public class CurrentState
    {
        [JsonProperty("home", Order = 1)] 
        public Home Home { get; set; }

        [JsonProperty("groups", Order = 2)]
        public GroupCollection Groups { get; set; }

        [JsonProperty("devices", Order = 3)]
        public DeviceCollection Devices { get; set; }

        [JsonProperty("clients", Order = 4)]
        public ClientCollection Clients { get; set; }
    }
}