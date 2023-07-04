using Newtonsoft.Json;

namespace AleRoe.HomematicIpApi.Model.Client
{
    [ClientType(ClientType.APP)]
    public class AppClient : Client
    {
        [JsonProperty("userRole")]
        public object UserRole { get; private set; }

        [JsonProperty("userRoleChangeStatus")]
        public object UserRoleChangeStatus { get; private set; }

        [JsonProperty("adminInitializationRequired")]
        public bool AdminInitializationRequired { get; private set; }
    }
}
