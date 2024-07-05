using System.Reflection;
using data.domain.Mappings;

namespace data;

public static class RegisterDocumentMapping
{
    public static void RegisterDocumentsMapping()
    {
        var assembly = Assembly.GetAssembly(typeof(RegisterDocumentMapping));

        var classMaps = assembly.GetTypes()
              .Where(t => t.BaseType != null && t.BaseType.IsGenericType &&
                t.BaseType.GetGenericTypeDefinition() == typeof(DocumentMapping<>));

        foreach (var classMap in classMaps)
            Activator.CreateInstance(classMap);
    }
}