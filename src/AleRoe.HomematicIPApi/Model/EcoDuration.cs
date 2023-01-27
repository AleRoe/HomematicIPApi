using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace AleRoe.HomematicIpApi.Model
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum EcoDuration
    {
        ONE,
        TWO,
        FOUR,
        SIX,
        PERMANENT }
}