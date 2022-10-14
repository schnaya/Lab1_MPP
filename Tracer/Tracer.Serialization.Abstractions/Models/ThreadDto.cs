namespace Tracer.Serialization.Abstractions.Models;

public class ThreadDto
{
    public int Id { get; set; }
    public long Time { get; set; }
    public List<MethodDto> Methods { get; set; }

    public ThreadDto(int id, long time, List<MethodDto> methods)
    {
        Id = id;
        Time = time;
        Methods = methods;
    }

    public ThreadDto()
    {
    }
}