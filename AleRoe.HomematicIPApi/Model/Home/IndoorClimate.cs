using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace AleRoe.HomematicIpApi.Model.Home
{
    public class IndoorClimate
    {
        [JsonProperty("functionalGroups")] 
        public List<object> FunctionalGroups { get; set; }

        [JsonProperty("absenceType")] 
        public AbsenceType AbsenceType { get; set; }

        [JsonProperty("absenceEndTime", NullValueHandling = NullValueHandling.Include)] 
        public DateTime? AbsenceEndTime { get; set; }

        [JsonProperty("floorHeatingSpecificGroups")]
        public FloorHeatingSpecificGroups FloorHeatingSpecificGroups { get; set; }

        [JsonProperty("ecoTemperature")] 
        public double EcoTemperature { get; set; }

        [JsonProperty("coolingEnabled")] 
        public bool CoolingEnabled { get; set; }

        [JsonProperty("ecoDuration")] 
        public EcoDuration EcoDuration { get; set; }

        [JsonProperty("optimumStartStopEnabled")]
        public bool OptimumStartStopEnabled { get; set; }

        [JsonProperty("deviceChannelSpecificFunction", NullValueHandling = NullValueHandling.Ignore)]
        public object DeviceChannelSpecificFunction { get; set; }

        [JsonProperty("solution")] 
        public string Solution { get; set; }

        [JsonProperty("active")] 
        public bool Active { get; set; }
    }
}