using System;

namespace AleRoe.HomematicIpApi.Model.Channels
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
    public class FunctionalChannelTypeAttribute : Attribute
    {
        public FunctionalChannelType FunctionalChannelType { get; set; }

        public FunctionalChannelTypeAttribute(FunctionalChannelType functionalChannelType)
        {
            this.FunctionalChannelType = functionalChannelType;
        }
    }
}