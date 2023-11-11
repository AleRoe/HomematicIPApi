using Microsoft.Extensions.Logging.Abstractions;
using NUnit.Framework;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace AleRoe.HomematicIpApi.Tests
{
    [TestFixture()]
    public class HomematicClientCtorTests : HomematicClientTestsBase
    {

        [Test()]
        public async Task CtorTest()
        {
            Assert.DoesNotThrow(() =>
            {
                var config = new HomematicIpConfiguration() { AccessPointId = AccessPoint, AuthToken = AuthToken };
                using var client = new HomematicIpClient(config);
            });
            await Task.CompletedTask;
        }

        [Test()]
        public async Task CtorArgumentNullTest()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                using var client = new HomematicIpClient(null);
            });
            await Task.CompletedTask;
        }

        [Test()]
        public async Task CtorWithHttpClientTest()
        {
            Assert.DoesNotThrow(() =>
            {
                using var httpClient = new HttpClient();
                var config = new HomematicIpConfiguration() { AccessPointId = AccessPoint, AuthToken = AuthToken };
                using var client = new HomematicIpClient(config, httpClient);
                Assert.AreSame(httpClient, client.httpClient);
            });
            await Task.CompletedTask;
        }

        [Test()]
        public async Task CtorWithLoggerTest()
        {
            Assert.DoesNotThrow(() =>
            {
                using var loggerFactory = new NullLoggerFactory();
                var config = new HomematicIpConfiguration() { AccessPointId = AccessPoint, AuthToken = AuthToken };
                using var client = new HomematicIpClient(config, loggerFactory);
                Assert.AreSame(loggerFactory, client.loggerFactory);
            });
            await Task.CompletedTask;
        }

        [Test()]
        public async Task CtorWithHttpClientAndLoggerTest()
        {
            Assert.DoesNotThrow(() =>
            {
                using var loggerFactory = new NullLoggerFactory();
                using var httpClient = new HttpClient();
                var config = new HomematicIpConfiguration() { AccessPointId = AccessPoint, AuthToken = AuthToken };
                using var client = new HomematicIpClient(config, httpClient, loggerFactory);
                Assert.AreSame(loggerFactory, client.loggerFactory);
                Assert.AreSame(httpClient, client.httpClient);
            });
            await Task.CompletedTask;
        }
    }
}
