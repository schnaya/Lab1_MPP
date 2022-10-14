using System.Reflection;

namespace Tracer.Core.Domain;

public class MethodMetadata
{
    public MethodMetadata(MemberInfo methodInfo)
    {
        ClassName = methodInfo.DeclaringType?.Name ?? string.Empty;
        MethodName = methodInfo.Name;

    }
    public string ClassName { get; }
    
    public string MethodName { get; }
    
}