using AleRoe.HomematicIpApi.Json;
using Newtonsoft.Json;

namespace AleRoe.HomematicIpApi.Model.Client
{
    [JsonConverter(typeof(CollectionConverter<ClientCollection, Client>))]
    public class ClientCollection : ModelCollection<Client>
    {
        public override string GetKeyValue(Client item)
        {
            return item.Id.ToString();
        }
    }
}
