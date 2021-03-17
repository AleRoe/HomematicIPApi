using System;

namespace AleRoe.HomematicIpApi
{
    internal class RequestUri 
    {
        public Uri Uri { get; }
        public RequestUri(string value)
        {
            this.Uri = new Uri(value, UriKind.Relative);
        }

        public override string ToString()
        {
            return Uri.ToString();
        }

        public static RequestUri SetDeviceState = new (@"/hmip/device/control/setSwitchState");
        public static RequestUri SetDeviceDimLevel = new (@"/hmip/device/control/setDimLevel");
        public static RequestUri SetDeviceLabel = new (@"/hmip/device/setDeviceLabel");
        public static RequestUri GetCurrentState = new (@"/hmip/home/getCurrentState");

        public static RequestUri SetGroupState = new (@"/hmip/group/switching/setState");
        public static RequestUri SetGroupLabel = new (@"/hmip/group/setGroupLabel");
    }
}