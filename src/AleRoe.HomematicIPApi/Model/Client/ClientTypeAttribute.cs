using System;

namespace AleRoe.HomematicIpApi.Model.Client
{
    /// <summary>
    /// Specifies the type of Client. Used when deserializing client in order to instantiate to correct target client.
    /// </summary>
    /// <remarks>
    /// This attribute must be applied to all non-abstract classes deriving from <see cref="Client"/> for deserialization to work.
    /// </remarks>
    /// <seealso cref="System.Attribute" />
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    internal class ClientTypeAttribute : Attribute
    {
        public ClientType ClientType { get; }

        public ClientTypeAttribute(ClientType clientType)
        {
            ClientType = clientType;
        }
    }
}
