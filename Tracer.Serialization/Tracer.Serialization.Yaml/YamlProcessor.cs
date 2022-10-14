using System.Text;
using Tracer.Core.Domain;
using Tracer.Serialization.Abstractions.Extentions;
using Tracer.Serialization.Abstractions.Interfaces;
using YamlDotNet.Serialization.NamingConventions;
using YamlDotNet.Serialization;

namespace Tracer.Serialization.Yaml;

public class YamlProcessor : ITraceResultSerializer
{
    public async Task Serialize(TraceResult traceResult, Stream to)
    {
        var serializer = new SerializerBuilder().WithNamingConvention(CamelCaseNamingConvention.Instance).Build();
        var yaml = serializer.Serialize(traceResult.ToThreadDto());
        Console.WriteLine("yaml");
        //Console.WriteLine(yaml);

        await using var writer = new StreamWriter(to);
        await writer.WriteAsync(yaml);
    }
}
