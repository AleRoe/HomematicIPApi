using Newtonsoft.Json;

namespace AleRoe.HomematicIpApi.Model.Channels
{
    [FunctionalChannelType(FunctionalChannelType.MOTION_DETECTION_CHANNEL)]
    public class MotionDetectionChannel : FunctionalChannel
    {
        [JsonProperty("currentIllumination")]
        public double? CurrentIllumination { get; private set; }

        [JsonProperty("motionDetected")]
        public bool? MotionDetected { get; private set; }

        [JsonProperty("motionDetectionActive")]
        public bool motionDetectionActive { get; private set; }

        [JsonProperty("illumination")]
        public double? Illumination { get; private set; }

        [JsonProperty("motionBufferActive")]
        public bool MotionBufferActive { get; private set; }

        [JsonProperty("motionDetectionSendInterval")]
        public MotionDetectionSendInterval MotionDetectionSendInterval { get; private set; } = MotionDetectionSendInterval.SECONDS_30;

        [JsonProperty("numberOfBrightnessMeasurements")]
        public int NumberOfBrightnessMeasurements { get; private set; }

        [JsonProperty("blockingPeriod")]
        public double BlockingPeriod { get; private set; }

        [JsonProperty("motionSensorSensitivity")]
        public int MotionSensorSensitivity { get; private set; }

        [JsonProperty("motionSensorZones")]
        public object MotionSensorZones { get; private set; }

        [JsonProperty("channelRole")]
        public ChannelRole? ChannelRole { get; private set; }

        [JsonProperty("motionSensorZoneSensitivityMap")]
        public object MotionSensorZoneSensitivityMap { get; private set; }
    }
}