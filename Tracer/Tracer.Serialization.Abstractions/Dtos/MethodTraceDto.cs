namespace Tracer.Serialization.Abstractions.Dtos;

public class MethodTraceDto
{

    public MethodMetadataDto MethodMetadata { get; set; }

    public List<MethodTraceDto> NestedMethods { get; set; }

    public virtual TimeSpan Elapsed { get; set; }


}