using Tracer.Core.Interfaces;

namespace Tracer.Example.Domain;

public class TestClassOne
{
    private readonly ITracer _tracer;

    public TestClassOne(ITracer tracer)
    {
        _tracer = tracer;
    }
    
    public void TestMethodOne()
    {
        _tracer.StartTrace();
        Console.WriteLine($"I am first test method of class {this.GetType().Name}.");
        TestMethodOneOne();

        
        
        _tracer.StopTrace();
    }

    public void TestMethodTwo()
    {
        _tracer.StartTrace();
        Console.WriteLine($"I am second test method of class {this.GetType().Name}.");
        _tracer.StopTrace();
    }

    private void TestMethodOneOne()
    {
        _tracer.StartTrace();
        Console.WriteLine($"I am nested of the first test method of class {this.GetType().Name}.");
        _tracer.StopTrace();
    }

}