using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace AleRoe.HomematicIpApi.Model
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ApExchangeState
    {
        NONE,
        REQUESTED,
        IN_PROGRESS,
        DONE,
        REJECTED
    }
}