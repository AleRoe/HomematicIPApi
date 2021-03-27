using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace AleRoe.HomematicIpApi.Model
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum HeatingFailureValidationType
    {
        NO_HEATING_FAILURE,
        HEATING_FAILURE_WARNING,
        HEATING_FAILURE_ALARM
    }
}