namespace Tracer.Core.Domain;

public class ThreadTrace
{
    private readonly Stack<MethodTrace> _stackOfMethods;

    public ThreadTrace()
    {
        _stackOfMethods = new Stack<MethodTrace>();
        Methods = new List<MethodTrace>();
    }

    public double ElapsedTime => Methods.Select(item => item.Elapsed.TotalMilliseconds).Sum();

    public List<MethodTrace> Methods { get; }

    public void StartTrackMethod(MethodTrace methodTrace)
    {
        if (_stackOfMethods.Count == 0)
        {
            Methods.Add(methodTrace);
        }
        else
        {
            _stackOfMethods.Peek().AddNestedMethod(methodTrace);
        }
        _stackOfMethods.Push(methodTrace);
    }

    public void StopTrackMethod()
    {
        _stackOfMethods.Pop().StopTrackTime();
    }

}