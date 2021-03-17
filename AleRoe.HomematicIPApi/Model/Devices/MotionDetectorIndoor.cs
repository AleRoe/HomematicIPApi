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
        [JsonProperty("currentIllumination")]
        public double? CurrentIllumination { get; private set; }

        [JsonProperty("motionDetected")]
        public bool? MotionDetected { get; private set; }

        [JsonProperty("illumination")]
        public double? Illumination { get; private set; }

        [JsonProperty("motionBufferActive")]
        public bool MotionBufferActive { get; private set; }

        [JsonProperty("motionDetectionSendInterval")]
        public MotionDetectionSendInterval MotionDetectionSendInterval { get; private set; } = MotionDetectionSendInterval.SECONDS_30;

        [JsonProperty("numberOfBrightnessMeasurements")]
        public int NumberOfBrightnessMeasurements { get; private set; }

        [OnDeserialized]
        internal new void OnDeserializedMethod(StreamingContext context)
        {
            this.GetFunctionalChannel<MotionDetectionChannel>()
                .CopyTo<MotionDetectorIndoor>(this);
        }
    }
}