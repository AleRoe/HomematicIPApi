using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System;
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
            var builder = new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .AddUserSecrets<HomematicClientTestsBase>();
            var config = builder.Build();

            this.AccessPoint = config["accessPoint"] ?? throw new ArgumentNullException("AccessPoint","Please check UserSecrets.");
            this.AuthToken = config["authToken"] ?? throw new ArgumentNullException("AuthToken", "Please check UserSecrets.");

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
