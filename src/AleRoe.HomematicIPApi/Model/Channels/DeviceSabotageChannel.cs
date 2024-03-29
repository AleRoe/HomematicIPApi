﻿using Newtonsoft.Json;

namespace AleRoe.HomematicIpApi.Model.Channels
{
    [FunctionalChannelType(FunctionalChannelType.DEVICE_SABOTAGE)]
    public class DeviceSabotageChannel : DeviceBaseChannel
    {
        [JsonProperty("sabotage")] 
        public bool? Sabotage { get; private set; }

    }
}