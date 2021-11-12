using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Enriched.Utilities
{
   internal static class Extensions
    {
        internal static bool Contains(this string @this, string value, StringComparison comparisonType)
        {
            return @this?.IndexOf(value, comparisonType) != -1;
        }
        internal static string GetDescription(this Enum @enum, bool replaceNullWithEnumName = false)
        {
            return
                @enum
                    .GetType()
                    .GetMember(@enum.ToString())
                    .FirstOrDefault()
                    ?.GetCustomAttribute<DescriptionAttribute>()
                    ?.Description
                ?? (replaceNullWithEnumName ? null : @enum.ToString());
        }
        internal static void ForEach<T>(this IEnumerable<T> collection, Action<T> action)
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }
            foreach (var item in collection)
            {
                action(item);
            }
        }
    }
}
