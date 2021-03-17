using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace AleRoe.HomematicIpApi.Model
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum LiveUpdateState
    {
        UP_TO_DATE,
        UPDATE_AVAILABLE,
        UPDATE_INCOMPLETE,
        LIVE_UPDATE_NOT_SUPPORTED
    }
}