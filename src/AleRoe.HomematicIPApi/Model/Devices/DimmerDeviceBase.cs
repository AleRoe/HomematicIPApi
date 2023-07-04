using AleRoe.HomematicIpApi.Extensions;
using AleRoe.HomematicIpApi.Model.Channels;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace AleRoe.HomematicIpApi.Model.Devices
{
    [FunctionalChannelType(FunctionalChannelType.DIMMER_CHANNEL)]
    public abstract class DimmerDeviceBase : Device
    {
        [JsonIgnore]
        public double DimLevel { get; private set; }
        
        [OnDeserialized]
        internal new void OnDeserializedMethod(StreamingContext context)
        {
            this.GetFunctionalChannel<DimmerChannel>().CopyTo(this);
            
        }
    }
}