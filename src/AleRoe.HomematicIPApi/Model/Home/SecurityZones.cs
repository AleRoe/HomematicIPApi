using System;
using Newtonsoft.Json;

namespace AleRoe.HomematicIpApi.Model.Home
{
    public class SecurityZones
    {
        [JsonProperty("EXTERNAL")] public Guid External { get; set; }

        [JsonProperty("INTERNAL")] public Guid Internal { get; set; }
    }
}