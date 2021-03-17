using System;
using Newtonsoft.Json;

namespace AleRoe.HomematicIpApi.Rpc
{
    /// <summary>
    /// A class containing the URLs used to communicate with HomematicIP cloud services.
    /// </summary>
    public class Hosts
    {
        /// <summary>
        /// Gets or sets the rest URL.
        /// </summary>
        /// <value>
        /// The rest URL.
        /// </value>
        [JsonProperty("urlREST")] 
        public string RestUrl { get; private set; }

        /// <summary>
        /// Gets or sets the websocket URL.
        /// </summary>
        /// <value>
        /// The web socket URL.
        /// </value>
        [JsonProperty("urlWebSocket")] 
        public string WebSocketUrl { get; private set; }

        /// <summary>
        /// Gets the websocket URI.
        /// </summary>
        /// <returns></returns>
        public Uri GetWebSocketUri() => new (WebSocketUrl);

        /// <summary>
        /// Gets the rest URI.
        /// </summary>
        /// <returns></returns>
        public Uri GetRestUri() => new (RestUrl);

    }
}