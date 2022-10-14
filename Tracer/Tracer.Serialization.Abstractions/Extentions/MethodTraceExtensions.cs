using Tracer.Core.Domain;
using Tracer.Serialization.Abstractions.Dtos;

namespace Tracer.Serialization.Abstractions.Extentions;

public static class MethodTraceExtensions
{
    public static MethodTraceDto ToMethodTraceDto(this MethodTrace trace)
    {
        return new MethodTraceDto()
        {
            Elapsed = trace.Elapsed,
            MethodMetadata = trace.MethodMetadata.ToMethodTraceDto(),
            NestedMethods = new List<MethodTraceDto>(trace.NestedMethods.Select(x => x.ToMethodTraceDto())),
        };
    }
}