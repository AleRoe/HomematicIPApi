using System;

namespace AleRoe.HomematicIpApi.Model.Groups
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class GroupTypeAttribute : Attribute
    {
        public GroupType GroupType { get; }

        public GroupTypeAttribute(GroupType groupType)
        {
            this.GroupType = groupType;
        }
    }
}