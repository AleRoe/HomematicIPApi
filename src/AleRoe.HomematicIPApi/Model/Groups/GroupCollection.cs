using AleRoe.HomematicIpApi.Json;
using Newtonsoft.Json;

namespace AleRoe.HomematicIpApi.Model.Groups
{
    [JsonConverter(typeof(CollectionConverter<GroupCollection, IGroup>))]
    public class GroupCollection : ModelCollection<IGroup>
    {
        public override string GetKeyValue(IGroup item)
        {
            return item.Id.ToString();
        }
    }
}
