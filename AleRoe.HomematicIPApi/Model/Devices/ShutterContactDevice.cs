using System.Runtime.Serialization;
using AleRoe.HomematicIpApi.Extensions;
using AleRoe.HomematicIpApi.Model.Channels;

namespace AleRoe.HomematicIpApi.Model.Devices
{
    [DeviceType(DeviceType.SHUTTER_CONTACT)]
    [FunctionalChannelType(FunctionalChannelType.SHUTTER_CONTACT_CHANNEL)]
    [DataContract]
    public class ShutterContactDevice : SabotageDeviceBase
    {
        public WindowState? WindowState { get; private set; } = Model.WindowState.CLOSED;

        public long EventDelay { get; private set; }

        [OnDeserialized]
        internal new void OnDeserializedMethod(StreamingContext context)
        {
            this.GetFunctionalChannel<ShutterContactChannel>()
                .CopyTo<ShutterContactDevice>(this);
        }
    }
}