using System;
using System.Linq;
using System.Reflection;

namespace DotSwashbuckle.AspNetCore.Filters.Extensions
{
    public static class TypeExtensions
    {
        public static string SchemaDefinitionName(this Type type)
        {
            string name = null;

            if (!type.GetTypeInfo().IsGenericType)
            {
                name = type.Name; // this doesn't work for generic types
            }
            else
            {
                var nullableUnderlyingType = Nullable.GetUnderlyingType(type);
                if (nullableUnderlyingType != null)
                {
                    return nullableUnderlyingType.Name;
                }

                // remove `# from the generic type name
                var friendlyName = type.Name.Remove(type.Name.IndexOf('`'));
                // for generic, Schema will be TypeName[GenericTypeName]
                var genericArguments = type.GetGenericArguments();
                name = $"{string.Concat(genericArguments.Select(a => a.Name).ToList())}{friendlyName}";
            }

            return name;
        }
    }
}
