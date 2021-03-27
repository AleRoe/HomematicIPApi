using Newtonsoft.Json;

namespace AleRoe.HomematicIpApi.Model.Groups
{
    [GroupType(GroupType.EXTENDED_LINKED_SHUTTER)]
    public class ExtendedLinkedShutterGroup : Group
    {
        [JsonProperty("bottomShutterLevel")]
        public double BottomShutterLevel { get; private set; }

        [JsonProperty("bottomSlatsLevel")]
        public double BottomSlatsLevel { get; private set; }

        [JsonProperty("shutterLevel")]
        public double ShutterLevel { get; private set; }

        [JsonProperty("slatsLevel")]
        public double? SlatsLevel { get; private set; }

        [JsonProperty("topShutterLevel")]
        public double TopShutterLevel { get; private set; }

        [JsonProperty("topSlatsLevel")]
        public double TopSlatsLevel { get; private set; }

        [JsonProperty("groupVisibility")]
        public GroupVisibility GroupVisibility { get; private set; } = GroupVisibility.INVISIBLE_GROUP_AND_CONTROL;

        [JsonProperty("primaryShadingLevel")]
        public double PrimaryShadingLevel { get; private set; }

        [JsonProperty("primaryShadingStateType")]
        public ShadingStateType PrimaryShadingStateType { get; private set; }

        [JsonProperty("secondaryShadingLevel")]
        public double? SecondaryShadingLevel { get; private set; }

        [JsonProperty("secondaryShadingStateType")]
        public ShadingStateType SecondaryShadingStateType { get; private set; }

        [JsonProperty("processing")]
        public bool Processing { get; private set; }

        [JsonProperty("sensorSpecificParameters")]
        public object SensorSpecificParameters { get; private set; }

    }
}