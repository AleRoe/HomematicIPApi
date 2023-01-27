using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace AleRoe.HomematicIpApi.Model
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum AlarmSignalType
    {
        NO_ALARM,
        SILENT_ALARM,
        FULL_ALARM
    }
}