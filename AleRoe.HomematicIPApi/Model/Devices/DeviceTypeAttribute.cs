using System;

namespace AleRoe.HomematicIpApi.Model.Devices
{
    /// <summary>
    /// Specifies the type of Device. Used when deserializing devices in order to instantiate to correct target device.
    /// </summary>
    /// <remarks>
    /// This attribute must be applied to all non-abstract classes deriving from <see cref="DeviceBase"/> for deserialization to work.
    /// </remarks>
    /// <seealso cref="System.Attribute" />
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class DeviceTypeAttribute : Attribute
    {
        public DeviceType DeviceType { get; }

        public DeviceTypeAttribute(DeviceType deviceType)
        {
            this.DeviceType = deviceType;
        }
    }
}