using Newtonsoft.Json;
using System;

namespace AleRoe.HomematicIpApi.Model.Groups
{
    public class Profile
    {
        [JsonProperty("profileId")]
        public string ProfileId { get; set; }

        [JsonProperty("groupId")]
        public Guid GroupId { get; set; }

        [JsonProperty("index")]
        public string Index { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("visible")]
        public bool Visible { get; set; }

        [JsonProperty("enabled")]
        public bool Enabled { get; set; }
    }
}