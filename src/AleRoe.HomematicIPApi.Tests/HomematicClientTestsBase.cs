using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using AleRoe.Extensions.Logging.NUnit;

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
        protected IServiceProvider ServiceProvider;

        [OneTimeSetUp]
        protected virtual void FixtureSetup()
        {
            var builder = new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .AddUserSecrets<HomematicClientTestsBase>();
            var config = builder.Build();

            ServiceProvider = new ServiceCollection()
                .AddLogging(builder => 
                    { 
                        //builder.AddNUnit();
                    })
                .BuildServiceProvider();

            this.AccessPoint = config["accessPoint"] ?? throw new ArgumentNullException("AccessPoint","Please check UserSecrets.");
            this.AuthToken = config["authToken"] ?? throw new ArgumentNullException("AuthToken", "Please check UserSecrets.");
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
