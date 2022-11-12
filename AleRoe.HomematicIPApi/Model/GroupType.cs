﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace AleRoe.HomematicIpApi.Model
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum GroupType
    {
        GROUP,
        ALARM_SWITCHING,
        ENVIRONMENT,
        EXTENDED_LINKED_SHUTTER,
        EXTENDED_LINKED_SWITCHING,
        HEATING,
        HEATING_CHANGEOVER,
        HEATING_COOLING_DEMAND,
        HEATING_COOLING_DEMAND_BOILER,
        HEATING_COOLING_DEMAND_PUMP,
        HEATING_DEHUMIDIFIER,
        HEATING_EXTERNAL_CLOCK,
        HEATING_FAILURE_ALERT_RULE_GROUP,
        HEATING_HUMIDITY_LIMITER,
        HEATING_TEMPERATURE_LIMITER,
        HOT_WATER,
        HUMIDITY_WARNING_RULE_GROUP,
        INBOX,
        LINKED_SWITCHING,
        LOCK_OUT_PROTECTION_RULE,
        META,
        OVER_HEAT_PROTECTION_RULE,
        SECURITY,
        SECURITY_BACKUP_ALARM_SWITCHING,
        SECURITY_ZONE,
        SHUTTER_PROFILE,
        SHUTTER_WIND_PROTECTION_RULE,
        SMOKE_ALARM_DETECTION_RULE,
        SWITCHING,
        SWITCHING_PROFILE,
        INDOOR_CLIMATE
    }
}