using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace AleRoe.HomematicIpApi.Model
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ChannelRole
    {
        KEY_OR_SWITCH_FOR_GROUP,
        WINDOW_SENSOR,
        MOTION_SENSOR,
        SWITCH_ACTUATOR_WITH_MEASURING,
        SWITCH_ACTUATOR,
        DIMMING_ACTUATOR,
        DOUBLE_INPUT_DIMMER,
        UNIVERSAL_LIGHT_ACTUATOR
    }
}
