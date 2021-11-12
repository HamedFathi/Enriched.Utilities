using System;
using System.Collections.Generic;
using System.Linq;

namespace Enriched.Utilities
{
    public static class EnumUtility
    {
        public static bool ContainsName<TEnum>(string name, bool ignoreCase = false) where TEnum : Enum
        {
            var stringComparison = ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal;
            foreach (var item in GetNames<TEnum>())
            {
                if (item.Contains(name, stringComparison))
                {
                    return true;
                }
            }
            return false;
        }

        public static bool ContainsValue<TEnum>(string value, bool ignoreCase = false) where TEnum : Enum
        {
            var stringComparison = ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal;
            foreach (var item in GetValuesAsString<TEnum>())
            {
                if (item.Contains(value, stringComparison))
                {
                    return true;
                }
            }
            return false;
        }

        public static bool ContainsValue<TEnum>(TEnum value) where TEnum : Enum
        {
            return GetValues<TEnum>().Contains(value);
        }

        public static IEnumerable<string> GetDescriptions<TEnum>(bool replaceNullWithEnumName = false) where TEnum : Enum
        {
            return GetValues<TEnum>().Select(e => e.GetDescription(replaceNullWithEnumName)).Where(e => e != null);
        }

        public static IEnumerable<string> GetNames<TEnum>() where TEnum : Enum
        {
            return Enum.GetNames(typeof(TEnum));
        }

        public static IEnumerable<TEnum> GetValues<TEnum>() where TEnum : Enum
        {
            return (TEnum[])Enum.GetValues(typeof(TEnum));
        }

        public static IEnumerable<string> GetValuesAsString<TEnum>() where TEnum : Enum
        {
            return GetValues<TEnum>().Select(e => e.ToString());
        }

        public static bool IsDefined<TEnum>(this string name) where TEnum : Enum
        {
            return Enum.IsDefined(typeof(TEnum), name);
        }

        public static bool IsDefined<TEnum>(this TEnum value) where TEnum : Enum
        {
            return Enum.IsDefined(typeof(TEnum), value);
        }

        public static bool IsInEnum<TEnum>(this string value, bool ignoreCase = false) where TEnum : Enum
        {
            var enums = GetValuesAsString<TEnum>().Select(e => ignoreCase ? e.ToLower() : e);
            return enums.Contains(ignoreCase ? value.ToLower() : value);
        }

        public static bool IsInEnumDescription<TEnum>(this string value, bool ignoreCase = false) where TEnum : Enum
        {
            var enums = GetDescriptions<TEnum>().Select(e => ignoreCase ? e.ToLower() : e);
            return enums.Contains(ignoreCase ? value.ToLower() : value);
        }
    }
}