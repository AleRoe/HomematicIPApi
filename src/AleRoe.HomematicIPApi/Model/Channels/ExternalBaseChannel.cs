using Newtonsoft.Json;
using System;

namespace AleRoe.HomematicIpApi.Model.Channels
{
    [FunctionalChannelType(FunctionalChannelType.EXTERNAL_BASE_CHANNEL)]
    public class ExternalBaseChannel : FunctionalChannel
    {
        [JsonProperty("unreach")]
        public bool UnReach { get; private set; }

        [JsonProperty("lowBat")]
        public bool? LowBat { get; private set; }

        [JsonProperty("channelId")]
        public Guid ChannelId { get; private set; }

        [JsonProperty("sabotage")]
        public bool? Sabotage { get; private set; }
    }
}
