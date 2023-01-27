using AleRoe.HomematicIpApi.Extensions;
using AleRoe.HomematicIpApi.Model.Channels;
using System.Runtime.Serialization;

namespace AleRoe.HomematicIpApi.Model.Devices
{
    [FunctionalChannelType(FunctionalChannelType.DIMMER_CHANNEL)]
    [DataContract]
    public abstract class DimmerDeviceBase : DeviceBase
    {
        public double DimLevel { get; private set; }
        public ProfileMode ProfileMode { get; private set; }
        public ProfileMode UserDesiredProfileMode { get; private set; }

        [OnDeserialized]
        internal new void OnDeserializedMethod(StreamingContext context)
        {
            var channel = this.GetFunctionalChannel<DimmerChannel>();
            if (channel != null)
            {
                this.DimLevel = channel.DimLevel;
                this.ProfileMode = channel.ProfileMode;
                this.UserDesiredProfileMode = channel.UserDesiredProfileMode;
            }
        }
    }
}