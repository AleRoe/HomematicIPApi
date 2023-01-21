using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace AleRoe.HomematicIpApi.Rpc
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ClientDeviceType
    {
        Computer
    }
}
