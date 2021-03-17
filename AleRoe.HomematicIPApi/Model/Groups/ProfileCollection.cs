using AleRoe.HomematicIpApi.Json;
using Newtonsoft.Json;

namespace AleRoe.HomematicIpApi.Model.Groups
{
    [JsonConverter(typeof(CollectionConverter<ProfileCollection, Profile>))]
    public class ProfileCollection : ModelCollection<Profile>
    {
        public override string GetKeyValue(Profile item)
        {
            return item.Index;
        }
    }
}