using Tracer.Core.Domain;

namespace Tracer.Core.Interfaces;

public interface ITracer
{
    
        public void StartTrace();
    

        public void StopTrace();
    

        public TraceResult GetTraceResult();
}