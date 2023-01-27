using System.Runtime.Serialization;
using AleRoe.HomematicIpApi.Extensions;
using AleRoe.HomematicIpApi.Model.Channels;
using Newtonsoft.Json;

namespace AleRoe.HomematicIpApi.Model.Devices
{
    [FunctionalChannelType(FunctionalChannelType.DEVICE_SABOTAGE)]
    public abstract class SabotageDeviceBase : DeviceBase
    {
        [JsonIgnore]
        public bool? Sabotage { get; set; }

        [OnDeserialized]
        internal new void OnDeserializedMethod(StreamingContext context)
        {
            this.GetFunctionalChannel<DeviceSabotageChannel>()
                .CopyTo<SabotageDeviceBase>(this);
        }
    }
}