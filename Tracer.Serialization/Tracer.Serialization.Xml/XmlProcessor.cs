using System.Xml.Serialization;
using Tracer.Core.Domain;
using Tracer.Serialization.Abstractions.Extentions;
using Tracer.Serialization.Abstractions.Interfaces;

namespace Tracer.Serialization.Xml;

public class XmlProcessor : ITraceResultSerializer
{
    public async Task Serialize(TraceResult traceResult, Stream to)
    {
        var resDto = traceResult.ToThreadDto();
        var serializer = new XmlSerializer(resDto.ThreadTraces.GetType());
        await Task.Factory.StartNew(() => serializer.Serialize(to, resDto.ThreadTraces));
    }
}