using AleRoe.HomematicIpApi.Json;
using AleRoe.HomematicIpApi.Rpc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AleRoe.HomematicIpApi
{
    internal class JsonClient : IDisposable
    {
        private const string GetHostsUri = @"https://lookup.homematic.com:48335/getHost";
        private bool disposedValue;
        private readonly Lazy<HttpClient> lazyClient;
        private readonly Lazy<Hosts> lazyHosts;

        public JsonSerializerSettings Settings { get; }
        public string AccessPoint { get; }
        public string AuthToken { get; }
        public string ClientAuth { get; }
        public HttpClient Client => lazyClient.Value ?? throw new InvalidOperationException();
        public Hosts Hosts => lazyHosts.Value ?? throw new InvalidOperationException();

        public JsonClient(string accessPoint, string authToken) 
            : this(accessPoint, authToken, new JsonSerializerSettings()) {}

        public JsonClient(string accessPoint, string authToken, JsonSerializerSettings settings)
        {
            this.AccessPoint = accessPoint;
            this.AuthToken = authToken;
            this.ClientAuth = GetClientAuth(accessPoint);
            this.Settings = settings ?? throw new ArgumentNullException(nameof(settings));
            this.lazyClient = new Lazy<HttpClient>(() => GetClient(accessPoint, authToken));
            this.lazyHosts = new Lazy<Hosts>(() => GetHosts(accessPoint));
            
        }

        public async Task<TResponse> PostRequestAsync<TResponse, T>(RequestUri requestUri, T value, CancellationToken cancellationToken)
        {
            try
            {
                var uri = new Uri(Hosts.GetRestUri(), requestUri.ToString());
                var response = await Client.PostAsJsonAsync(uri, value, cancellationToken).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();

                var formatters = new List<MediaTypeFormatter>
                {
                    new DefaultJsonMediaTypeFormatter(Settings)
                };

                return await response.Content.ReadAsAsync<TResponse>(formatters, cancellationToken).ConfigureAwait(false);
                
            }
            catch (Exception e)
            {
                Trace.TraceError(e.Message);
                throw;
            }
        }

        public async Task PostRequestAsync<T>(RequestUri requestUri, T value, CancellationToken cancellationToken)
            => await PostRequestAsync<HttpResponseMessage, T>(requestUri, value, cancellationToken).ConfigureAwait(false);

        private Hosts GetHosts(string accessPoint)
        {
            var task = Task.Run(async () =>
            {
                try
                {
                    var uri = new Uri(GetHostsUri);
                    var content = new ClientCharacteristicsRoot(accessPoint);

                    var response = await Client.PostAsJsonAsync(uri, content).ConfigureAwait(false);
                    response.EnsureSuccessStatusCode();
                    return await response.Content.ReadAsAsync<Hosts>().ConfigureAwait(false);
                }
                catch (Exception e)
                {
                    Trace.TraceError(e.Message);
                    throw;
                }
            });

            return task.Result;
        }

        private static HttpClient GetClient(string accessPoint, string authToken)
        {
            var instance = new HttpClient();
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            instance.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            instance.DefaultRequestHeaders.Add("AUTHTOKEN", authToken);
            instance.DefaultRequestHeaders.Add("CLIENTAUTH", GetClientAuth(accessPoint));
            instance.DefaultRequestHeaders.Add("VERSION", "12");
            return instance;
        }

        private static string GetClientAuth(string accessPoint)
        {
            var data = Encoding.UTF8.GetBytes(accessPoint + "jiLpVitHvWnIGD1yo7MA");
            var sha = SHA512.Create();
            var result = ToHexString(sha.ComputeHash(data)).ToUpper();
            return result;
        }

        private static string ToHexString(byte[] hex)
        {
            if (hex == null) return null;
            if (hex.Length == 0) return string.Empty;

            var s = new StringBuilder();
            foreach (byte b in hex)
            {
                s.Append(b.ToString("x2"));
            }
            return s.ToString();
        }

        #region IDisposable Support
        void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    Client?.CancelPendingRequests();
                    Client?.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
        #endregion

    }
}