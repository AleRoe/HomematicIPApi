using System;
using System.Threading.Tasks;
using AleRoe.HomematicIpApi.Model.Groups;

namespace AleRoe.HomematicIpApi.Extensions
{
    public static class GroupExtensions
    {
        public static bool IsSwitchingGroup(this IGroup group)
        {
            return (group is SwitchingGroup | group is ExtendedLinkedSwitchingGroup);
        }

        public static async Task SetStateAsync(this SwitchGroupBase group, bool state)
        {
            if (group == null)
                throw new ArgumentNullException(nameof(group));

            await group.Service.SetGroupStateAsync(group.Id, state).ConfigureAwait(false);
        }

    }
}