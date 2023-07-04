using System.Collections.Generic;
using Newtonsoft.Json;

namespace AleRoe.HomematicIpApi.Model.Home
{
    public class AccessControl
    {
        [JsonProperty("functionalGroups")]
        public FunctionalGroups FunctionalGroups { get; private set; }

        [JsonProperty("accessAuthorizationProfileGroups")]
        public List<object> AccessAuthorizationProfileGroups { get; private set; }
        
        [JsonProperty("lockProfileGroups")]
        public List<object> LockProfileGroups { get; private set; }

        [JsonProperty("autoRelockProfileGroups")]
        public List<object> AutoRelockProfileGroups { get; private set; }

        [JsonProperty("extendedLinkedGarageDoorGroups")]
        public List<object> ExtendedLinkedGarageDoorGroups { get; private set; }

        [JsonProperty("extendedLinkedNotificationGroups")]
        public List<object> ExtendedLinkedNotificationGroups { get; private set; }

        [JsonProperty("solution")]
        public string Solution { get; private set; }

        [JsonProperty("active")]
        public bool Active { get; private set; }
    }
}