using System.Runtime.Serialization;
using AleRoe.HomematicIpApi.Extensions;
using AleRoe.HomematicIpApi.Model.Channels;
using Newtonsoft.Json;

namespace AleRoe.HomematicIpApi.Model.Devices
{
    [DeviceType(DeviceType.MOTION_DETECTOR_INDOOR)]
    [FunctionalChannelType(FunctionalChannelType.MOTION_DETECTION_CHANNEL)]
    public class MotionDetectorIndoor : SabotageDeviceBase
    {
        [JsonIgnore]
        public double? CurrentIllumination { get; private set; }

        [JsonIgnore]
        public bool? MotionDetected { get; private set; }

        [JsonIgnore]
        public double? Illumination { get; private set; }

        [JsonIgnore]
        public bool MotionBufferActive { get; private set; }

        [JsonIgnore]
        public MotionDetectionSendInterval MotionDetectionSendInterval { get; private set; } = MotionDetectionSendInterval.SECONDS_30;

        [JsonIgnore]
        public int NumberOfBrightnessMeasurements { get; private set; }

        [OnDeserialized]
        internal new void OnDeserializedMethod(StreamingContext context)
        {
            this.GetFunctionalChannel<MotionDetectionChannel>()
                .CopyTo(this);
        }
    }
}