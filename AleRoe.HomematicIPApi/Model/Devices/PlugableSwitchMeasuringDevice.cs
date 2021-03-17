using AleRoe.HomematicIpApi.Model.Channels;

namespace AleRoe.HomematicIpApi.Model.Devices
{

    [DeviceType(DeviceType.PLUGABLE_SWITCH_MEASURING)]
    [FunctionalChannelType(FunctionalChannelType.SWITCH_MEASURING_CHANNEL)]
    public class PlugableSwitchMeasuringDevice : SwitchMeasuringDevice {}
}