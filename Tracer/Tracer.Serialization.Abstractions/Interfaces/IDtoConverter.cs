using Tracer.Core.Domain;

namespace Tracer.Serialization.Abstractions.Interfaces;

public interface IDtoConverter
{
    public List<Thread> Convert(TraceResult traceResult);
}