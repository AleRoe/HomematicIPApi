using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Newtonsoft.Json.Serialization;
using NUnit.Framework;

namespace AleRoe.HomematicIpApi.Tests
{
    internal class TestContextTraceWriter : ITraceWriter
    {
        public TraceLevel LevelFilter => TraceLevel.Error;

        public void Trace(TraceLevel level, string message, Exception ex)
        {
            TestContext.Out.WriteLine(message);
            TestContext.Out.WriteLine(ex?.ToString());
            TestContext.Out.WriteLine();
        }
    }
}
