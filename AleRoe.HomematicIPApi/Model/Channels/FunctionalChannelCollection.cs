using AleRoe.HomematicIpApi.Json;
using Newtonsoft.Json;

namespace AleRoe.HomematicIpApi.Model.Channels
{
    [JsonConverter(typeof(CollectionConverter<FunctionalChannelCollection, IFunctionalChannel>))]
    public class FunctionalChannelCollection : ModelCollection<IFunctionalChannel>
    {
        public override string GetKeyValue(IFunctionalChannel item)
        {
            return item.Index.ToString();
        }
    }
}