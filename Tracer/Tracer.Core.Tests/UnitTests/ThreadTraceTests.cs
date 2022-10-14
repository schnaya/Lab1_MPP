using System;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Tracer.Core.Domain;

namespace Tracer.Core.Tests.UnitTests;

[TestClass]
public class ThreadTraceTests
{
    [TestMethod]
    public void StartTrackThread_OnlyOneMethod_NoExceptions()
    {
        // init 
        var methodBaseMock = new Mock<MethodBase>();
        var methodTraceMock = new Mock<MethodTrace>(methodBaseMock.Object);
        
        // act
        var threadTrace = new ThreadTrace();
        threadTrace.StartTrackMethod(methodTraceMock.Object);
        
        // assert
        // no exceptions
    }
    
    [TestMethod]
    public void StartTrackThread_TwoMethods_NoExceptions()
    {
        // init 
        var methodBaseMock = new Mock<MethodBase>();
        var methodTraceMockOne = new Mock<MethodTrace>(methodBaseMock.Object);
        var methodTraceMockTwo = new Mock<MethodTrace>(methodBaseMock.Object);
        
        // act
        var threadTrace = new ThreadTrace();
        threadTrace.StartTrackMethod(methodTraceMockOne.Object);
        threadTrace.StartTrackMethod(methodTraceMockTwo.Object);
        
        // assert
        // no exceptions
    }

    [TestMethod]
    public void StopTrackThread_UsualOneMethod_NoExceptions()
    {
        // init 
        var methodBaseMock = new Mock<MethodBase>();
        var methodTraceMockOne = new Mock<MethodTrace>(methodBaseMock.Object);
        var threadTrace = new ThreadTrace();
        threadTrace.StartTrackMethod(methodTraceMockOne.Object);
        
        // act
        threadTrace.StopTrackMethod();
        
        // assert
        // no exceptions
    }
    
    [TestMethod]
    public void StopTrackThread_UsualTwoMethods_NoExceptions()
    {
        // init 
        var methodBaseMock = new Mock<MethodBase>();
        var methodTraceMockOne = new Mock<MethodTrace>(methodBaseMock.Object);
        var methodTraceMockTwo = new Mock<MethodTrace>(methodBaseMock.Object);
        var threadTrace = new ThreadTrace();
        threadTrace.StartTrackMethod(methodTraceMockOne.Object);
        threadTrace.StartTrackMethod(methodTraceMockTwo.Object);
        
        // act
        threadTrace.StopTrackMethod();
        
        // assert
        // no exceptions
    }
    
    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void StopTrackThread_NoMethods_InvalidOperationException()
    {
        // init 
        var threadTrace = new ThreadTrace();

        // act
        threadTrace.StopTrackMethod();
        
        // assert
        // exception
    }

    [TestMethod]
    public void ElapsedTime_16ms_16ms()
    {
        //init
        var methodBaseMock = new Mock<MethodBase>();
        const long expectedMilliseconds = 16;
        var mockMethod = new Mock<MethodTrace>(methodBaseMock.Object);
        mockMethod.Setup(x => x.Elapsed).Returns( TimeSpan.FromMilliseconds(expectedMilliseconds));
        var threadTrace = new ThreadTrace();
        threadTrace.StartTrackMethod(mockMethod.Object);
        threadTrace.StopTrackMethod();
        
        //act
        var actualElapsedTime = threadTrace.ElapsedTime;
        
        //assert
        Assert.AreEqual(expectedMilliseconds, actualElapsedTime);

    }
}