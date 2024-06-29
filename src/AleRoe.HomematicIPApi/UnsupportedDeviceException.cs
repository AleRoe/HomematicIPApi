using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AleRoe.HomematicIpApi
{
    public class UnsupportedDeviceException : Exception
    {
        public UnsupportedDeviceException(string message) : base(message)
        {
        }
    }
}
