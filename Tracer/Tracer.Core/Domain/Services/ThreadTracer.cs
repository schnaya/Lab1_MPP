using System.Collections.Concurrent;
using System.Reflection;
using Tracer.Core.Interfaces;

namespace Tracer.Core.Domain.Services;

public class ThreadTracer : IThreadTracer
{
    private readonly ConcurrentDictionary<int, ThreadTrace> _threadsData;

    public ThreadTracer()
    {
        _threadsData = new ConcurrentDictionary<int, ThreadTrace>();
    }

    public IDictionary<int, ThreadTrace> ThreadTraces => _threadsData;
    
    public void StartTrace(int threadId, MethodBase methodBase)
    {
        var threadTrace = _threadsData.GetOrAdd(threadId, new ThreadTrace());
        threadTrace.StartTrackMethod(new MethodTrace(methodBase));

    }

    public void StopTrace(int threadId)
    {
        if (_threadsData.TryGetValue(threadId, out var threadTrace))
        {
            threadTrace.StopTrackMethod();
        }
    }
}