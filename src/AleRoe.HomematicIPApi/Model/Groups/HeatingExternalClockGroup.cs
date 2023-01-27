using Newtonsoft.Json;

namespace AleRoe.HomematicIpApi.Model.Groups
{
    [GroupType(GroupType.HEATING_EXTERNAL_CLOCK)]
    public class HeatingExternalClockGroup : Group
    {
        [JsonProperty("externalClockActive")]
        public object ExternalClockActive { get; private set; }
    }
}