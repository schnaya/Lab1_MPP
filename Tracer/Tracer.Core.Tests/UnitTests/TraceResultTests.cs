using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Tracer.Core.Domain;

namespace Tracer.Core.Tests.UnitTests;

[TestClass]
public class TraceResultTests
{
    

    [TestMethod]
    public void ThreadTraces_MockTraces_SameMockTraces()
    {
        //init
        IDictionary<int, ThreadTrace> threadTraces = new ConcurrentDictionary<int, ThreadTrace>();
        for (var i = 0; i < 100; i++)
        {
            var threadMock = new Mock<ThreadTrace>();
            
            threadTraces.Add(i, threadMock.Object);
        }

        ICollection expectedTraces = new ReadOnlyDictionary<int, ThreadTrace>(threadTraces);
        
        //act
        var traceResult = new TraceResult(threadTraces);

        var actualTraces = traceResult.ThreadTraces;
        
        //assert
        CollectionAssert.AreEqual(expectedTraces, new Dictionary<int, ThreadTrace>(actualTraces));

    }
}