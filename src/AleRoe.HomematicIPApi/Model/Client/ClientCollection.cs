using AleRoe.HomematicIpApi.Json;
using Newtonsoft.Json;

namespace AleRoe.HomematicIpApi.Model.Client
{
    [JsonConverter(typeof(CollectionConverter<ClientCollection, IClient>))]
    public class ClientCollection : ModelCollection<IClient>
    {
        public override string GetKeyValue(IClient item)
        {
            return item.Id.ToString();
        }
    }
}
