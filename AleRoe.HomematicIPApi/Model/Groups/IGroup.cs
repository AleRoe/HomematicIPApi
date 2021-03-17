using System;
using System.Collections.Generic;
using AleRoe.HomematicIpApi.Json;
using Newtonsoft.Json;

namespace AleRoe.HomematicIpApi.Model.Groups
{
    [JsonConverter(typeof(GroupConverter))]
    public interface IGroup
    {
        Guid Id { get; set; }
        Guid HomeId { get; set; }
        Guid? MetaGroupId { get; set; }
        string Label { get; set; }
        DateTime LastStatusUpdate { get; set; }
        bool? UnReach { get; set; }
        bool? LowBat { get; set; }
        bool? DutyCycle { get; set; }
        GroupType Type { get; set; }
        List<Channel> Channels { get; set; }

        IHomematicRpcService Service { get; }
    }
}