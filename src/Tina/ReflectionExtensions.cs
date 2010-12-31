namespace Tina
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Collections.Generic;

    public static class ReflectionExtensions
    {
        public static IEnumerable<TAttribute> GetCustomAttributes<TAttribute>(this ICustomAttributeProvider provider) where TAttribute : Attribute
        {
            foreach (var att in provider.GetCustomAttributes(typeof(TAttribute), true))
            {
                yield return att as TAttribute;
            }
        }
    }
}
