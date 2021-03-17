using AleRoe.HomematicIpApi.Model.Channels;
using System.Runtime.Serialization;

namespace AleRoe.HomematicIpApi.Model.Devices
{
    [DeviceType(DeviceType.OPEN_COLLECTOR_8_MODULE)]
    [FunctionalChannelType(FunctionalChannelType.SWITCH_CHANNEL)]
    public class OpenCollector8ModuleDevice : DeviceBase
    {
        // """ HmIP-MOD-OC8 ( Open Collector Module ) """
        [OnDeserialized]
        internal new void OnDeserializedMethod(StreamingContext context)
        {
            
        }
    }
}