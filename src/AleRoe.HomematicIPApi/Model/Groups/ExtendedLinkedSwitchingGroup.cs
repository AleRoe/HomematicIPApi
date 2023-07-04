using Newtonsoft.Json;

namespace AleRoe.HomematicIpApi.Model.Groups
{
    [GroupType(GroupType.EXTENDED_LINKED_SWITCHING)]
    public class ExtendedLinkedSwitchingGroup : SwitchingGroup
    {
        [JsonProperty("onTime")]
        public double OnTime { get; private set; }

        [JsonProperty("onLevel")]
        public double OnLevel { get; private set; }

        [JsonProperty("sensorSpecificParameters")]
        public object SensorSpecificParameters { get; private set; }

        [JsonProperty("groupVisibility")]
        public GroupVisibility GroupVisibility { get; private set; }

        [JsonProperty("dimStep")]
        public double DimStep { get; private set; }

        [JsonProperty("onHue")]
        public int OnHue { get; private set; }

        [JsonProperty("onSaturationLevel")]
        public double OnSaturationLevel { get; private set; }

        [JsonProperty("onColorTemperature")]
        public int OnColorTemperature { get; private set; }

        [JsonProperty("longPressBehavior")]
        public LongPressBehavior LongPressBehavior { get; private set; }

        [JsonProperty("onLightSceneId")]
        public int OnLightSceneId { get; private set; }

        
        [JsonProperty("triggered")]
        public bool Triggered { get; private set; }
    }
}