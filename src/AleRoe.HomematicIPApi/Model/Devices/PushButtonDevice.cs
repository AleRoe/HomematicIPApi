using AleRoe.HomematicIpApi.Model.Channels;

namespace AleRoe.HomematicIpApi.Model.Devices
{
    [DeviceType(DeviceType.PUSH_BUTTON)]
    [FunctionalChannelType(FunctionalChannelType.SINGLE_KEY_CHANNEL)]
    public class PushButtonDevice : Device
    {
        //""" HMIP-WRC2 (Wall-mount Remote Control - 2-button) """
    }
}