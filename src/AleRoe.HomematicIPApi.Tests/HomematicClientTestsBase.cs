using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System.Diagnostics;
using System.Threading.Tasks;

namespace AleRoe.HomematicIpApi.Tests
{
    /// <summary>
    /// A base class for creating tests that target <see cref="HomematicIpClient"/>
    /// Provides AccessPoint and AuthToken from secrets.json and imposes a delay between tests to prevent call-blocking
    /// </summary>
    public abstract class HomematicClientTestsBase
    {
        protected string AccessPoint;
        protected string AuthToken;

        [OneTimeSetUp]
        protected virtual void FixtureSetup()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .AddUserSecrets<HomematicClientTestsBase>()
                .Build();

            this.AccessPoint = configuration["accessPoint"];
            this.AuthToken = configuration["authToken"];

            Trace.Listeners.Add(new ConsoleTraceListener());
        }

        [SetUp]
        protected virtual async Task TestSetup()
        {
            await Task.Delay(1000);
        }

        [OneTimeTearDown]
        protected virtual void FixtureTearDown()
        {
            Trace.Flush();
        }
    }
}
