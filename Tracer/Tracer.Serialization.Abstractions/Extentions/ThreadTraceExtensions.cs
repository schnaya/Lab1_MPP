using Tracer.Core.Domain;
using Tracer.Serialization.Abstractions.Dtos;

namespace Tracer.Serialization.Abstractions.Extentions;

public static class ThreadTraceExtensions
{
    public  static ThreadTraceDto ToThreadDto(this ThreadTrace trace)
    {
        return new ThreadTraceDto()
        {
            Methods = new List<MethodTraceDto>(trace.Methods.Select(x => x.ToMethodTraceDto()))
        };
    }
}