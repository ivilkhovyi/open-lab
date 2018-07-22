using System;
using System.Linq;

namespace UI.Extensions
{
    public static class ReflectionExtensions
    {
        public static bool ImplementGenericInterface(this Type type, Type genericInterface)
        {
            return type.GetInterfaces()
                    .Where(i => i.IsGenericType)
                    .Any(i => i.GetGenericTypeDefinition() == genericInterface);
        }
    }
}
