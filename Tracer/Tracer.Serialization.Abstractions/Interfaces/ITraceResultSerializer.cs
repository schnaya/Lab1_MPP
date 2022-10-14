using Tracer.Core.Domain;

namespace Tracer.Serialization.Abstractions.Interfaces;

public interface ITraceResultSerializer
{
    public Task Serialize(TraceResult traceResult, Stream to);
}