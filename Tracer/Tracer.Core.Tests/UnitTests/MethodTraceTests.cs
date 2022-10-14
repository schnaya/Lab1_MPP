using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Tracer.Core.Domain;

namespace Tracer.Core.Tests.UnitTests;

[TestClass]
public class MethodTraceTests
{
    [TestMethod]
    public void Elapsed_1s_1s()
    {
        //init 
        var methodMock = new Mock<MethodBase>();
        const int timeExpected = 1000;
        const int allowedDelta = 100;
        var methodTrace = new MethodTrace(methodMock.Object);
        
        //act
        Thread.Sleep(timeExpected);
        methodTrace.StopTrackTime();
        var actualTime = methodTrace.Elapsed.TotalMilliseconds;
        
        //assert
        Assert.IsTrue(((actualTime - allowedDelta) >= timeExpected) || timeExpected <= actualTime + allowedDelta);
    }
    
    [TestMethod]
    public void NestedMethods_OneNestedMethod1s_OneNestedMethod1s()
    {
        //init 
        var rootMethodMock = new Mock<MethodBase>();
        var nestedMethod = new Mock<MethodBase>();
        const int timeExpected = 1000;
        const int allowedDelta = 100;
        var rootMethodTrace = new MethodTrace(rootMethodMock.Object);
        var expectedNested = new MethodTrace(nestedMethod.Object);
        var expectedNestedCollection = new MethodTrace[] {expectedNested};
        //act
        rootMethodTrace.AddNestedMethod(expectedNested);
        Thread.Sleep(timeExpected);
        rootMethodTrace.StopTrackTime();
        var actualTimeRoot = rootMethodTrace.Elapsed.TotalMilliseconds;
        var actualNested = rootMethodTrace.NestedMethods.ToArray();
        var nestedTime = actualNested.Select(t => t.Elapsed.TotalMilliseconds).Sum();

        //assert
        Assert.IsTrue(((actualTimeRoot - allowedDelta) >= timeExpected) || timeExpected <= actualTimeRoot + allowedDelta);
        CollectionAssert.AreEqual(expectedNestedCollection, actualNested);
        Assert.IsTrue(((nestedTime - allowedDelta) >= timeExpected) || timeExpected <= nestedTime + allowedDelta);
        
    }
    
    [TestMethod]
    public void MethodMetadata_TestMethod_TestMethod()
    {
        //init 
        const string expectedClassName = "TestClass";
        const string expectedMethodName = "TestMethod";
        
        var methodBaseMock = new Mock<MethodBase>();
        methodBaseMock.Setup(x => x.DeclaringType!.Name).Returns(expectedClassName);
        methodBaseMock.Setup(x => x.Name).Returns(expectedMethodName);
        var methodTrace = new MethodTrace(methodBaseMock.Object);
        
        //act
        var actualMetadata = methodTrace.MethodMetadata;

        //assert
        Assert.AreEqual(expectedClassName, actualMetadata.ClassName);
        Assert.AreEqual(expectedMethodName, actualMetadata.MethodName);

    }
}