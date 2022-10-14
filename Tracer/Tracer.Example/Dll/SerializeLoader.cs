using System.Reflection;
using Tracer.Serialization.Abstractions.Interfaces;

namespace Tracer.Example.Dll;

public static class SerializeLoader
{
    public static ITraceResultSerializer GetSerializer(string dllPath)
    {
        var dllSerializer = Assembly.LoadFile(dllPath);
        foreach (var type in dllSerializer.ExportedTypes)
        {
            if (typeof(ITraceResultSerializer).IsAssignableFrom(type))
            {
                return Activator.CreateInstance(type) as ITraceResultSerializer ?? throw  new ArgumentException("Can not create instance of a type");
            }
        }

        throw new ArgumentException("No types that implements needed interface.");
    }
}