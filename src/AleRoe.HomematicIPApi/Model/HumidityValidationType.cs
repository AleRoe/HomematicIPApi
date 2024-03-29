﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace AleRoe.HomematicIpApi.Model
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum HumidityValidationType
    {
        LESSER_LOWER_THRESHOLD,
        GREATER_UPPER_THRESHOLD,
        GREATER_LOWER_LESSER_UPPER_THRESHOLD
    }
}