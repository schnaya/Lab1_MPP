using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tracer.Core.Tests.UnitTests;

[TestClass]
public class TracerTests
{
    [TestMethod]
    public void StartTrace_NoExceptions()
    {
        //init 
        var tracer = new Domain.Services.Tracer();
        
        //act
        tracer.StartTrace();
        
        //assert
        //no exceptions
        
    }
    
    [TestMethod]
    public void StopTrace_NoExceptions()
    {
        //init 
        var tracer = new Domain.Services.Tracer();
        
        //act
        tracer.StopTrace();
        
        //assert
        //no exceptions
        
    }

    [TestMethod]
    public void TraceResult_EnvThreadId_EnvThreadId()
    {
        //init 
        var tracer = new Domain.Services.Tracer();

        //act
        tracer.StartTrace();

        TestMethod();

        void TestMethod()
        {
            Thread.Sleep(100);

        }

        tracer.StopTrace();
        var result = tracer.GetTraceResult();

        //assert
        foreach (var resultThreadTrace in result.ThreadTraces)
        {
            var actualThreadId = resultThreadTrace.Key;
            Assert.AreEqual(Environment.CurrentManagedThreadId, actualThreadId);
        }

    }

}