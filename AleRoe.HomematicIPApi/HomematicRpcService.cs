using AleRoe.HomematicIpApi.Model.Devices;
using AleRoe.HomematicIpApi.Model.Groups;
using AleRoe.HomematicIpApi.Rpc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AleRoe.HomematicIpApi
{
    internal class HomematicRpcService : IHomematicRpcService
    {
        private readonly JsonClient client;
        public HomematicRpcService(JsonClient client)
        {
            this.client = client;
        }

        public async Task<IEnumerable<IDevice>> GetDevicesAsync(CancellationToken cancellationToken)
        {
            var result = await GetCurrentStateAsync(cancellationToken).ConfigureAwait(false);
            return result.Devices;
        }

        public async Task<CurrentState> GetCurrentStateAsync(CancellationToken cancellationToken)
        {
            var content = new ClientCharacteristicsRoot(client.AccessPoint);
            return await client.PostRequestAsync<CurrentState, ClientCharacteristicsRoot>(RequestUri.GetCurrentState, content, cancellationToken).ConfigureAwait(false);
        }

        public async Task<IDevice> GetDeviceAsync(string id, CancellationToken cancellationToken = default)
        {
            var result = await GetDevicesAsync(cancellationToken).ConfigureAwait(false);
            return result.SingleOrDefault(x => x.Id.Equals(id));
        }

        public async Task<T> GetDeviceAsync<T>(string id, CancellationToken cancellationToken = default) where T : IDevice
        {
            var result = await GetDevicesAsync(cancellationToken).ConfigureAwait(false);
            return result.OfType<T>().SingleOrDefault(x => x.Id.Equals(id));
        }

        public async Task<IEnumerable<IGroup>> GetGroupsAsync(CancellationToken cancellationToken)
        {
            var result = await GetCurrentStateAsync(cancellationToken).ConfigureAwait(false);
            return result.Groups;
        }

        public async Task<IGroup> GetGroupAsync(string id, CancellationToken cancellationToken = default)
        {
            var result = await GetGroupsAsync(cancellationToken).ConfigureAwait(false);
            return result.SingleOrDefault(x => x.Id.ToString().Equals(id));
        }

        public async Task<T> GetGroupAsync<T>(string id, CancellationToken cancellationToken = default) where T : IGroup
        {
            var result = await GetGroupsAsync(cancellationToken).ConfigureAwait(false);
            return result.OfType<T>().SingleOrDefault(x => x.Id.ToString().Equals(id));
        }

        public async Task SetDeviceLabelAsync(string id, string label, CancellationToken cancellationToken = default)
        {
            var content = new SetDeviceLabel(id, label);
            await client.PostRequestAsync(RequestUri.SetDeviceLabel, content, cancellationToken).ConfigureAwait(false);
        }

        public async Task SetDeviceStateAsync(string id, bool state, int channelIndex = 1, CancellationToken cancellationToken = default)
        {
            var content = new SetDeviceState(id, state, channelIndex);
            await client.PostRequestAsync(RequestUri.SetDeviceState, content, cancellationToken).ConfigureAwait(false);
        }

        public async Task SetDeviceDimLevelAsync(string id, double dimLevel, CancellationToken cancellationToken = default)
        {
            var content = new SetDimmerLevel(id, dimLevel);
            await client.PostRequestAsync(RequestUri.SetDeviceDimLevel, content, cancellationToken).ConfigureAwait(false);
        }

        public async Task SetGroupStateAsync(Guid id, bool state, CancellationToken cancellationToken = default)
        {
            var content = new SetGroupState(id, state);
            await client.PostRequestAsync(RequestUri.SetGroupState, content, cancellationToken).ConfigureAwait(false);
        }
    }
}