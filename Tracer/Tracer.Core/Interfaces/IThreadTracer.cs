using System.Reflection;
using Tracer.Core.Domain;

namespace Tracer.Core.Interfaces;

public interface IThreadTracer
{
    public void StartTrace(int threadId, MethodBase methodBase);

    public void StopTrace(int threadId);
    
    public IDictionary<int, ThreadTrace> ThreadTraces { get; }
    
    
}