using System.Runtime.Serialization;
using AleRoe.HomematicIpApi.Extensions;
using AleRoe.HomematicIpApi.Model.Channels;
using Newtonsoft.Json;

namespace AleRoe.HomematicIpApi.Model.Devices
{
    [DataContract]
    public abstract class SwitchDeviceBase : DeviceBase
    {
        public bool On { get; private set; }
        
        [JsonIgnore]
        public string ProfileMode { get; private set; }
        
        [JsonIgnore]
        public string UserDesiredProfileMode { get; private set; }

        [OnDeserialized]
        internal new void OnDeserializedMethod(StreamingContext context)
        {
            this.GetFunctionalChannel<SwitchChannel>()
                .CopyTo<SwitchDeviceBase>(this);
        }
    }
}
