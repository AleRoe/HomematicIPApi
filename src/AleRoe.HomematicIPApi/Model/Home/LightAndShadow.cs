using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace AleRoe.HomematicIpApi.Model.Home
{
    public class LightAndShadow
    {
        [JsonProperty("functionalGroups")] 
        public List<Guid> FunctionalGroups { get; set; }

        [JsonProperty("extendedLinkedSwitchingGroups")]
        public List<object> ExtendedLinkedSwitchingGroups { get; set; }

        [JsonProperty("extendedLinkedShutterGroups")]
        public List<object> ExtendedLinkedShutterGroups { get; set; }

        [JsonProperty("switchingProfileGroups")]
        public List<object> SwitchingProfileGroups { get; set; }

        [JsonProperty("shutterProfileGroups")] 
        public List<object> ShutterProfileGroups { get; set; }

        [JsonProperty("solution")] 
        public string Solution { get; set; }

        [JsonProperty("active")] 
        public bool Active { get; set; }
    }
}