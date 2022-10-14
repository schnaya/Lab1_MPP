using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Tracer.Core.Domain.Services;

namespace Tracer.Core.Tests.UnitTests;

[TestClass]
public class ThreadTracerTests
{
    [TestMethod]
    public void StartTrace_OneThread_SameThreadId()
    {
        //init
        var methodBaseMock = new Mock<MethodBase>();
        var threadTracer = new ThreadTracer();
        var threadId = Environment.CurrentManagedThreadId;
        
        //act
        threadTracer.StartTrace(threadId, methodBaseMock.Object);
        threadTracer.StopTrace(threadId);
        
        //assert
        Assert.IsTrue(threadTracer.ThreadTraces.ContainsKey(threadId));
    }
    
    [TestMethod]
    public void StartTrace_TwoTasks_SameThreadId()
    {
        var threadTracer = new ThreadTracer();

        var tasks = new List<Task<int>>
        {
            new Task<int>(() =>
            {
                var methodBaseMock = new Mock<MethodBase>();
                
                var threadId = Environment.CurrentManagedThreadId;

                //act
                threadTracer.StartTrace(threadId, methodBaseMock.Object);
                threadTracer.StopTrace(threadId);
                return threadId;
            }),

            new Task<int>(() =>
            {
                var methodBaseMock = new Mock<MethodBase>();
                var threadId = Environment.CurrentManagedThreadId;

                //act
                threadTracer.StartTrace(threadId, methodBaseMock.Object);
                threadTracer.StopTrace(threadId);
                return threadId;
            }),
        };

        tasks[0].Start();
        var firstThreadId = tasks[0].Result;
        tasks[1].Start();
        var secondThreadId = tasks[1].Result;

        var actualThreadTraces = threadTracer.ThreadTraces;

        //assert
        Assert.IsTrue(actualThreadTraces.ContainsKey(firstThreadId));
        Assert.IsTrue(actualThreadTraces.ContainsKey(secondThreadId));
        

    }
}