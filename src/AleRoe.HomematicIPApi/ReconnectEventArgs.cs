using System;
using Websocket.Client;
using Websocket.Client.Models;

namespace AleRoe.HomematicIpApi
{
    public class ReconnectEventArgs : EventArgs
    {
        public ReconnectionInfo ReconnectionInfo { get; }
        public ReconnectEventArgs(ReconnectionInfo info)
        {
            this.ReconnectionInfo = info;   
        }
    }
}
