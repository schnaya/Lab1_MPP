namespace Tracer.Serialization.Abstractions.Models;

public class MethodDto
{
    public string Name { get; set; }
    public string ClassName { get; set; }
    public long Time { get; set; }
    public List<MethodDto> Methods { get; set; }

    public MethodDto(string name, string className, long time, List<MethodDto> methods)
    {
        Name = name;
        ClassName = className;
        Time = time;
        Methods = methods;
    }
    public MethodDto()
    {

    }
}