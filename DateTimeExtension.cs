using System;
using System.Text;

namespace SharpExtension
{
    public static class DateTimeExtension
    {
        public static TimeSpan FromNow(this DateTime time)
        {
            return DateTime.Now - time;
        }
    }
}