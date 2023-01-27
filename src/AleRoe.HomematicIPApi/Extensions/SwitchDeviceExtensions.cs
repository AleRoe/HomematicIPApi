using System;
using System.Threading.Tasks;
using AleRoe.HomematicIpApi.Model.Devices;

namespace AleRoe.HomematicIpApi.Extensions
{
    public static class SwitchDeviceExtensions
    {
        public static async Task SetStateAsync(this SwitchDeviceBase device, bool state, int channelIndex = 1)
        {
            if (device == null)
                throw new ArgumentNullException(nameof(device));

            await device.Service.SetDeviceStateAsync(device.Id, state, channelIndex).ConfigureAwait(false);
        }

        public static async Task ToggleStateAsync(this SwitchDeviceBase device, int channelIndex = 1)
        {
            await device.SetStateAsync(!device.On, channelIndex).ConfigureAwait(false);
        }

        public static async Task TurnOnAsync(this SwitchDeviceBase device, int channelIndex = 1)
        {
            await device.SetStateAsync(true, channelIndex).ConfigureAwait(false);
        }

        public static async Task TurnOffAsync(this SwitchDeviceBase device, int channelIndex = 1)
        {
            await device.SetStateAsync(false, channelIndex).ConfigureAwait(false);
        }

    }
}