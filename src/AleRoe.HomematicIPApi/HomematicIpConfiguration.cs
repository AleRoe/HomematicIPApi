using System;
using System.Security.Cryptography;
using System.Text;

namespace AleRoe.HomematicIpApi
{
    public class HomematicIpConfiguration
    {

        private string accessPointId;
        private string clientAuthToken;

        /// <summary>
        /// Also called SGTIN on the back of your access point
        /// </summary>
        public string AccessPointId
        {
            get => accessPointId;
            set => accessPointId = GetAccessPointIdWithoutDashes(value);
        }

        private string GetAccessPointIdWithoutDashes(string accessPointId)
        {
            var accessPointIdWithoutDashes = accessPointId.Replace("-", "");
            if (accessPointIdWithoutDashes.Length != 24)
                throw new ArgumentException($"The accesspoint id (SGTIN) {accessPointId} is invalid. It needs to have exactly 24 digits without the dashes.");
            return accessPointIdWithoutDashes;
        }

        /// <summary>
        /// Your PIN (if any)
        /// </summary>
        public string Pin { get; set; }
        /// <summary>
        /// The name of this very application
        /// </summary>
        public string ApplicationName { get; set; }
        /// <summary>
        /// The AuthToken you received via HomematicAuthService
        /// </summary>
        public string AuthToken { get; set; }

        public string ClientAuthToken
        {
            get
            {
                if (clientAuthToken == null)
                {
                    using SHA512 shaM = SHA512.Create();
                    var data = Encoding.UTF8.GetBytes($"{AccessPointId}jiLpVitHvWnIGD1yo7MA");
                    var hash = shaM.ComputeHash(data);
                    clientAuthToken = BitConverter.ToString(hash).Replace("-", "").ToUpper();
                }
                return clientAuthToken;
            }
        }
    }
}
