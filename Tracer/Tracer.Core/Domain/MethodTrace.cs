using System.Diagnostics;
using System.Reflection;

namespace Tracer.Core.Domain;

public class MethodTrace
{
    private readonly List<MethodTrace> _nestedMethods;
    
    private readonly Stopwatch _stopwatch;

    public MethodTrace(MethodBase methodBase)
    {
        _nestedMethods = new List<MethodTrace>();
        _stopwatch = Stopwatch.StartNew();
        MethodMetadata = new MethodMetadata(methodBase);
    }

    public MethodMetadata MethodMetadata { get; }

    public IEnumerable<MethodTrace> NestedMethods => _nestedMethods;

    public void AddNestedMethod(MethodTrace methodTrace)
    {
        _nestedMethods.Add(methodTrace);
    }

    public void StopTrackTime()
    {
        _stopwatch.Stop();
    }

    public virtual TimeSpan Elapsed => _stopwatch.Elapsed;


}