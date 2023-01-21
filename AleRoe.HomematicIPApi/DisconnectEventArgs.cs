using System;
using Websocket.Client;

namespace AleRoe.HomematicIpApi
{
    public class DisconnectEventArgs : EventArgs
    {
        public DisconnectionInfo DisconnectionInfo { get; }
        public DisconnectEventArgs(DisconnectionInfo info)
        {
            this.DisconnectionInfo = info;
        }
    }
}