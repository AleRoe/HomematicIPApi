using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace AleRoe.HomematicIpApi.Model
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum InternalLinkConfigurationType
    {
        SINGLE_INPUT_SWITCH,
        DOUBLE_INPUT_DIMMER
    }
}