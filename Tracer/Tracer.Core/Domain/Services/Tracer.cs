using System.Diagnostics;
using Tracer.Core.Interfaces;

namespace Tracer.Core.Domain.Services;

public class Tracer : ITracer
{
    private readonly IThreadTracer _threadTracer;

    public Tracer()
    {
        _threadTracer = new ThreadTracer();
    }
    
    public Tracer(IThreadTracer threadTracer)
    {
        _threadTracer = threadTracer;
    }
    
    public void StartTrace()
    {
        var method = new StackTrace(1).GetFrame(0)?.GetMethod();
        var threadId = Environment.CurrentManagedThreadId;
        if (method is null)
        {
            throw new ApplicationException("Can not recognize method info");
        }
        
        _threadTracer.StartTrace(threadId, method);
    }

    public void StopTrace()
    {
        var threadId = Environment.CurrentManagedThreadId;
        _threadTracer.StopTrace(threadId);
    }

    public TraceResult GetTraceResult()
    {
        return new TraceResult(_threadTracer.ThreadTraces);
    }
}