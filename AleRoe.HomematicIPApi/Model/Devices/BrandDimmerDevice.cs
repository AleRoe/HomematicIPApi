using AleRoe.HomematicIpApi.Model.Channels;

namespace AleRoe.HomematicIpApi.Model.Devices
{
    /// <summary>
    /// 
    /// </summary>
    [DeviceType(DeviceType.BRAND_DIMMER)]
    [FunctionalChannelType(FunctionalChannelType.DIMMER_CHANNEL)]
    public class BrandDimmerDevice : DimmerDeviceBase
    {
        //"""HmIP-BDT Brand Dimmer"""
    }
}