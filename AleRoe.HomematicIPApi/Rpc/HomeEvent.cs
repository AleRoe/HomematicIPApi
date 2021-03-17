using AleRoe.HomematicIpApi.Model.Home;
using Newtonsoft.Json;

namespace AleRoe.HomematicIpApi.Rpc
{
    public class HomeEvent : Event
    {
        [JsonProperty("home")] 
        public Home Home { get; set; }

        public override string ToString()
        {
            return $"{Home}";
        }
    }
}