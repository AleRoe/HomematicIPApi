using AleRoe.HomematicIpApi.Extensions;
using AleRoe.HomematicIpApi.Model.Channels;
using System.Runtime.Serialization;

namespace AleRoe.HomematicIpApi.Model.Devices
{
    [FunctionalChannelType(FunctionalChannelType.DIMMER_CHANNEL)]
    public abstract class DimmerDeviceBase : Device
    {
               
        [OnDeserialized]
        internal new void OnDeserializedMethod(StreamingContext context)
        {
            this.GetFunctionalChannel<DimmerChannel>().CopyTo(this);
            
        }
    }
}