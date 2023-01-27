using AleRoe.HomematicIpApi.Json;
using Newtonsoft.Json;

namespace AleRoe.HomematicIpApi.Model.Devices
{
    [JsonConverter(typeof(CollectionConverter<DeviceCollection, IDevice>))]
    public class DeviceCollection : ModelCollection<IDevice>
    {
        public override string GetKeyValue(IDevice item)
        {
            return item.Id;
        }
    }
}
