using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace AleRoe.HomematicIpApi.Model.Home
{
    public class IndoorClimate
    {
        [JsonProperty("functionalGroups")] 
        public FunctionalGroups FunctionalGroups { get; set; }

        [JsonProperty("absenceType")] 
        public AbsenceType AbsenceType { get; set; }

        [JsonProperty("absenceEndTime")] 
        public DateTime? AbsenceEndTime { get; private set; }

        [JsonProperty("floorHeatingSpecificGroups")]
        public FloorHeatingSpecificGroups FloorHeatingSpecificGroups { get; private set; }

        [JsonProperty("ecoTemperature")] 
        public double EcoTemperature { get; private set; }

        [JsonProperty("coolingEnabled")] 
        public bool CoolingEnabled { get; private set; }

        [JsonProperty("ecoDuration")] 
        public EcoDuration EcoDuration { get; private set; }

        [JsonProperty("optimumStartStopEnabled")]
        public bool OptimumStartStopEnabled { get; private set; }

        [JsonProperty("deviceChannelSpecificFunction")]
        public object DeviceChannelSpecificFunction { get; private set; }

        [JsonProperty("solution")] 
        public string Solution { get; private set; }

        [JsonProperty("active")] 
        public bool Active { get; private set; }

        [JsonProperty("extendedLinkedVentilationGroups")]
        public object ExtendedLinkedVentilationGroups { get; private set; }

        [JsonProperty("ventilationProfileGroups")]
        public object VentilationProfileGroups { get; private set; }

        [JsonProperty("cooling")]
        public object Cooling { get; private set; }
    }
}