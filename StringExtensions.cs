using System;
using System.Collections.Generic;
using System.Text;

namespace SharpExtension
{
    public static class StringExtension
    {
        public static StringBuilder AppendLine(this string source, string line)
        {
            var builder = new StringBuilder(source);
            builder.AppendLine(line);
            return builder;
        }

        public static string Join(this IEnumerable<string> strings, string separator)
        {
            return string.Join(separator, strings);
        }

        public static bool IsNullOrWhiteSpace(this string source)
        {
            return string.IsNullOrWhiteSpace(source);
        }

        public static string GetNullIfNullOrWhiteSpace(this string source)
        {
            return source.IsNullOrWhiteSpace() ? null : source;
        }
    }
}