using Tracer.Core.Domain;
using Tracer.Serialization.Abstractions.Dtos;

namespace Tracer.Serialization.Abstractions.Extentions;

public static class MethodMetadataExtensions
{
    public static MethodMetadataDto ToMethodTraceDto(this MethodMetadata metadata)
    {
        return new MethodMetadataDto()
        {
            ClassName = metadata.ClassName,
            MethodName = metadata.MethodName,
        };
    }
}