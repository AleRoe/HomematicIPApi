using AleRoe.HomematicIpApi.Json;
using Newtonsoft.Json;
using System;

namespace AleRoe.HomematicIpApi.Model.Client
{
    [JsonConverter(typeof(ClientConverter))]
    public interface IClient
    {
        ClientType ClientType { get; }
        DateTime? CreatedAtTimestamp { get; }
        Guid HomeId { get; }
        Guid Id { get; }
        string Label { get; }
        DateTime? LastSeenAtTimestamp { get; }
    }
}