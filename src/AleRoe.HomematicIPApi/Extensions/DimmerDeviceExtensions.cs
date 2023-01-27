using System;
using System.Threading;
using System.Threading.Tasks;
using AleRoe.HomematicIpApi.Model.Devices;

namespace AleRoe.HomematicIpApi.Extensions
{
    public static class DimmerDeviceExtensions
    {
        public static async Task SetDimLevelAsync(this DimmerDeviceBase device, double level = 0.0,
            CancellationToken cancellationToken = default)
        {
            if (device == null)
                throw new ArgumentNullException(nameof(device));

            await device.Service.SetDeviceDimLevelAsync(device.Id, level, cancellationToken).ConfigureAwait(false);
        }
    }
}