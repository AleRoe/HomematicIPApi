using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AleRoe.HomematicIpApi.Model.Devices;
using AleRoe.HomematicIpApi.Model.Groups;
using AleRoe.HomematicIpApi.Rpc;

namespace AleRoe.HomematicIpApi
{
    public interface IHomematicRpcService
    {
        /// <summary>
        /// Asynchronously gets the current state.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<CurrentState> GetCurrentStateAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Asynchronously gets all devices.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<IEnumerable<IDevice>> GetDevicesAsync(CancellationToken cancellationToken = default);
        
        Task<IDevice> GetDeviceAsync(string id, CancellationToken cancellationToken = default);
        Task<T> GetDeviceAsync<T>(string id, CancellationToken cancellationToken = default) where T : IDevice;
        Task<IEnumerable<IGroup>> GetGroupsAsync(CancellationToken cancellationToken = default);
        Task<IGroup> GetGroupAsync(string id, CancellationToken cancellationToken = default);
        Task<T> GetGroupAsync<T>(string id, CancellationToken cancellationToken = default) where T : IGroup;
        
        Task SetDeviceLabelAsync(string id, string label, CancellationToken cancellationToken = default);
        Task SetDeviceStateAsync(string id, bool state, int channelIndex = 1, CancellationToken cancellationToken = default);
        Task SetDeviceDimLevelAsync(string id, double dimLevel, CancellationToken cancellationToken = default);

        Task SetGroupStateAsync(Guid id, bool state, CancellationToken cancellationToken = default);
    }
}