using System;
using System.Text;

namespace SharpExtension.Text
{
    public static class StringExtension
    {
        public static StringBuilder AppendLine(this string source, string line)
        {
            var builder = new StringBuilder(source);
            builder.AppendLine(line);
            return builder;
        }
    }
}