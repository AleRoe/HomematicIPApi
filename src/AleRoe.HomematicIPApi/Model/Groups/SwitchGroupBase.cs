﻿using Newtonsoft.Json;

namespace AleRoe.HomematicIpApi.Model.Groups
{
    public abstract class SwitchGroupBase : Group
    {
        [JsonProperty("on")] 
        public bool? On { get; private set; }

        [JsonProperty("dimLevel")] 
        public double? DimLevel { get; private set; }
    }
}