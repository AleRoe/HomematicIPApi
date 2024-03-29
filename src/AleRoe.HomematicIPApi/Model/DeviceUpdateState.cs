﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace AleRoe.HomematicIpApi.Model
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum DeviceUpdateState
    {
        UP_TO_DATE,
        TRANSFERING_UPDATE,
        UPDATE_AVAILABLE,
        UPDATE_AUTHORIZED,
        BACKGROUND_UPDATE_NOT_SUPPORTED
    }
}