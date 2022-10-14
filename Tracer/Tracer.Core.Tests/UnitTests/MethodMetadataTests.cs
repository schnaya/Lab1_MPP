using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Tracer.Core.Domain;

namespace Tracer.Core.Tests.UnitTests;

[TestClass]
public class MethodMetadataTests
{
    [TestMethod]
    public void ClassName_TestClass_TestClass()
    {
        // init
        const string expectedClassName = "TestClass"; 
        var methodInfoMock = new Mock<MemberInfo>();
        methodInfoMock.Setup(x => x.DeclaringType!.Name).Returns(expectedClassName);
        
        //act
        var methodMetadata = new MethodMetadata(methodInfoMock.Object);
        var actualClassName = methodMetadata.ClassName;
        
        //assert
        Assert.AreEqual(expectedClassName, actualClassName);

    }
    
    [TestMethod]
    public void ClassName_null_EmptyString()
    {
        // init
        const string expectedClassName = "";

        var methodInfoMock = new Mock<MemberInfo>();
        methodInfoMock.Setup(x => x.DeclaringType!.Name).Returns((string) null!);
        
        //act
        var methodMetadata = new MethodMetadata(methodInfoMock.Object);
        var actualClassName = methodMetadata.ClassName;
        
        //assert
        Assert.AreEqual(expectedClassName, actualClassName);

    }
    
    [TestMethod]
    public void MethodName_TestMethod_TestMethod()
    {
        // init
        const string expectedMethodName = "TestMethod"; 
        var methodInfoMock = new Mock<MemberInfo>();
        methodInfoMock.Setup(x => x.Name).Returns(expectedMethodName);
        
        //act
        var methodMetadata = new MethodMetadata(methodInfoMock.Object);
        var actualMethodName = methodMetadata.MethodName;
        
        //assert
        Assert.AreEqual(expectedMethodName, actualMethodName);

    }
    
    
}