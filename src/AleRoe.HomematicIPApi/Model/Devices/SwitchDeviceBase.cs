using System.Runtime.Serialization;
using AleRoe.HomematicIpApi.Extensions;
using AleRoe.HomematicIpApi.Model.Channels;
using Newtonsoft.Json;

namespace AleRoe.HomematicIpApi.Model.Devices
{
    public abstract class SwitchDeviceBase : Device
    {
        [JsonIgnore]
        public bool On { get; private set; }

        [OnDeserialized]
        internal new void OnDeserializedMethod(StreamingContext context)
        {
            this.GetFunctionalChannel<SwitchChannel>().CopyTo(this);
        }
    }
}
