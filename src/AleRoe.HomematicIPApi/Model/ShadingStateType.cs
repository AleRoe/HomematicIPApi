using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace AleRoe.HomematicIpApi.Model
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ShadingStateType
    {
        NOT_POSSIBLE,
        NOT_EXISTENT,
        POSITION_USED,
        TILT_USED,
        NOT_USED,
        MIXED
    }
}