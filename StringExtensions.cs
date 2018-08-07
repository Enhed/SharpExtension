using System;
using System.Collections.Generic;
using System.Linq;
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

        public static bool ContainsAny(this string target, params string[] options)
            => options.Any(opt => target.Contains(opt));

        public static bool ContainsAny(this string target, bool ignoreCase = false, params string[] options)
        {
            if(!ignoreCase) return target.ContainsAny(options);
            else return target.ToLower().ContainsAny( options.Select(x => x.ToLower()).ToArray() );
        }
    }
}