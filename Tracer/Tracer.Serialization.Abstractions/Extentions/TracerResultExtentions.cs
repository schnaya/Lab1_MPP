using Tracer.Core.Domain;
using Tracer.Serialization.Abstractions.Dtos;

namespace Tracer.Serialization.Abstractions.Extentions;

public static class TraceResultExtentions
{
    public static TraceResultDto ToThreadDto(this TraceResult traceResult)
    {
        var threadDict = traceResult.ThreadTraces;
        var listOfThread = threadDict.Select(threadTrace => new ThreadDto() {ThreadId = threadTrace.Key, ThreadTrace = threadTrace.Value.ToThreadDto()}).ToList();

        return new TraceResultDto()
        {
            ThreadTraces = listOfThread,
        };
    }
}