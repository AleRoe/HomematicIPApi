using System;

namespace AleRoe.HomematicIpApi.Model.Home
{
    [Flags]
    public enum FunctionalHomesType
    {
        None = 0x0,
        WeatherAndEnvironment = 0x1,
        SecurityAndAlarm = 0x2,
        LightAndShadow = 0x4,
        IndoorClimate = 0x8
    }
}