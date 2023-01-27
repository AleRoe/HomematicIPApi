using AleRoe.HomematicIpApi.Json;
using Newtonsoft.Json;

namespace AleRoe.HomematicIpApi.Model.Home
{
    [JsonConverter(typeof(CollectionConverter<RuleMetaDatasCollection, RuleMetaData>))]
    public class RuleMetaDatasCollection : ModelCollection<RuleMetaData>
    {
        public override string GetKeyValue(RuleMetaData item)
        {
            return item.Id;
        }
    }
}