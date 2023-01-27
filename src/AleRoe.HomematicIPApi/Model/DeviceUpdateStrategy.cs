using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace AleRoe.HomematicIpApi.Model
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum DeviceUpdateStrategy
    {
        MANUALLY,
        AUTOMATICALLY_IF_POSSIBLE
    }
}