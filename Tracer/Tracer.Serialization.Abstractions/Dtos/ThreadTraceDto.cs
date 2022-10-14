namespace Tracer.Serialization.Abstractions.Dtos;

public class ThreadTraceDto
{
    public double ElapsedTime => Methods.Select(item => item.Elapsed.TotalMilliseconds).Sum();

    public List<MethodTraceDto> Methods { get; set; }

    public ThreadTraceDto()
    {
    }
}