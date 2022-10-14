
using Newtonsoft.Json;
using Tracer.Core.Domain;
using Tracer.Serialization.Abstractions.Extentions;
using Tracer.Serialization.Abstractions.Interfaces;

namespace Tracer.Serialization.Json;

public class JsonProcessor : ITraceResultSerializer
{
    public async Task Serialize(TraceResult traceResult, Stream to)
    {
        var json = JsonConvert.SerializeObject(traceResult.ToThreadDto());
        Console.WriteLine("json");
        //Console.WriteLine(json);
        await using var writer = new StreamWriter(to);
        await writer.WriteAsync(json);
    }
}