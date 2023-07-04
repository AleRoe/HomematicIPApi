using System;
using System.Collections.Generic;
using AleRoe.HomematicIpApi.Json;
using Newtonsoft.Json;

namespace AleRoe.HomematicIpApi.Model.Channels
{
    [JsonConverter(typeof(FunctionalChannelConverter))]
    [DictionaryToListConverterKey(nameof(Index))]
    public interface IFunctionalChannel
    {
        int Index { get; }
        int GroupIndex { get; }
        string Label { get; }
        string DeviceId { get; }
        FunctionalChannelType FunctionalChannelType { get; }
        List<Guid> Groups { get; }

    }
}