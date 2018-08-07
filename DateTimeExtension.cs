using System;
using System.Text;

namespace SharpExtension
{
    public static class DateTimeExtension
    {
        public static readonly DateTime EpochZeroTime = new DateTime(1970, 1, 1);

        public static TimeSpan ToNow(this DateTime time)
        {
            return DateTime.Now - time;
        }

        public static bool Greater(this DateTime time, DateTime greatCheck)
        {
            return time > greatCheck;
        }

        public static bool Less(this DateTime time, DateTime greatCheck)
        {
            return time < greatCheck;
        }

        public static DateTime GetDay(this DateTime t)
            => new DateTime(t.Year, t.Month, t.Day);

        public static long ToEpoch(this DateTime t)
            => (long) (t - EpochZeroTime).TotalSeconds;

        // public static DateTime ToDateTime(this double seconds) => EpochZeroTime.AddSeconds(seconds);
        public static DateTime ToDateTime(this long seconds) => EpochZeroTime.AddSeconds(seconds);
    }
}