using System.Collections.Generic;
using System.IO;
using SharpExtension.Generic;

namespace SharpExtension.Text
{
    public static class TextReaderExtension
    {
        public static IEnumerable<string> ReadAllLines(this TextReader reader)
        {
            return reader.Yield(x => x.ReadLine(), x => x.Peek() > -1);
        }
    }
}