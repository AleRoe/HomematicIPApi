using AleRoe.HomematicIpApi.Json;
using AleRoe.HomematicIpApi.Model.Channels;
using Newtonsoft.Json;
using System;

namespace AleRoe.HomematicIpApi.Model.Devices
{
    /// <summary>
    /// Defines a device
    /// </summary>
    [JsonConverter(typeof(DeviceConverter))]
    public interface IDevice 
    {
        string Id { get; }
        Guid HomeId { get; }
        string Label { get;}
        DateTime LastStatusUpdate { get; }
        DeviceType Type { get; }
        FunctionalChannelCollection FunctionalChannels { get; }
        long? ManufacturerCode { get; }
        string Oem { get; }
        ConnectionType ConnectionType { get; }
        DeviceUpdateState? UpdateState { get; }
        string FirmwareVersion { get; }
        long? FirmwareVersionInteger { get; }
        LiveUpdateState? LiveUpdateState { get; }
        string AvailableFirmwareVersion { get; }
        string SerializedGlobalTradeItemNumber { get; }
        string ModelType { get; }
        long? ModelId { get; }
        bool PermanentlyReachable { get; }

        IHomematicRpcService Service { get; }
    }
}