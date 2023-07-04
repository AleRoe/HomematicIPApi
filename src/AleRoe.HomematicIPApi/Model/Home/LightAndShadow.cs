using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace AleRoe.HomematicIpApi.Model.Home
{
    public class LightAndShadow
    {
        [JsonProperty("functionalGroups")] 
        public FunctionalGroups FunctionalGroups { get; private set; }

        [JsonProperty("extendedLinkedSwitchingGroups")]
        public List<object> ExtendedLinkedSwitchingGroups { get; private set; }

        [JsonProperty("extendedLinkedShutterGroups")]
        public List<object> ExtendedLinkedShutterGroups { get; private set; }

        [JsonProperty("switchingProfileGroups")]
        public List<object> SwitchingProfileGroups { get; private set; }

        [JsonProperty("shutterProfileGroups")] 
        public List<object> ShutterProfileGroups { get; private set; }

        [JsonProperty("solution")] 
        public string Solution { get; private set; }

        [JsonProperty("active")] 
        public bool Active { get; private set; }

        [JsonProperty("lightSceneEntries")]
        public List<object> LightSceneEntries { get; private set; }
    }
}