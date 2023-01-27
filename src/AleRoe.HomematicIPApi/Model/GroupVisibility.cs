using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace AleRoe.HomematicIpApi.Model
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum GroupVisibility
    {
        VISIBLE,
        INVISIBLE_GROUP_AND_CONTROL
    }
}