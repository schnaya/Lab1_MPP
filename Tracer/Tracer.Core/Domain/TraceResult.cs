using System.Collections.ObjectModel;

namespace Tracer.Core.Domain;

public class TraceResult
{
    public IReadOnlyDictionary<int, ThreadTrace> ThreadTraces { get; set; }
    
    public TraceResult(IDictionary<int, ThreadTrace> threadsTraces)
    {
        ThreadTraces = new ReadOnlyDictionary<int, ThreadTrace>(threadsTraces);
    }

    public TraceResult()
    {
        
    }
    
}