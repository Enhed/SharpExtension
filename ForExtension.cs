using System;
using System.Collections.Generic;

namespace SharpExtension.For
{
    public static class ForExtension
    {
        public static void ForDo( this (int begin, int end) source, Action<int> action,
            bool includeEnd = false )
        {
            var end = source.end;

            for(var i = source.begin; includeEnd ? i <= end : i < end ; i++)
            {
                action(i);
            }
        }

        public static void ForDo<TSource>( this (int begin, int end, TSource obj) source,
            Action<int, TSource> action, bool includeEnd = false )
        {
            var end = source.end;

            for(var i = source.begin; includeEnd ? i <= end : i < end; i++)
            {
                action(i, source.obj);
            }
        }

        public static void ForDo<TSource>( this (int end, TSource obj) source,
            Action<int, TSource> action, bool includeEnd = false )
        {
            (0, source.end, source.obj).ForDo(action, includeEnd);
        }

        public static void ForDo( this int end, Action<int> action,
            bool includeEnd = false )
        {
            (0, end).ForDo(action, includeEnd);
        }

        public static IEnumerable<TResult> ForGet<TResult>( this (int begin, int end) source,
            Func<int, TResult> func, bool includeEnd = false )
        {
            var end = source.end;

            for(var i = source.begin; includeEnd ? i <= end : i < end; i++)
            {
                yield return func(i);
            }
        }

        public static IEnumerable<TResult> ForGet<TResult>( this int end,
            Func<int, TResult> func, bool includeEnd = false  )
        {
            return (0, end).ForGet(func, includeEnd);
        }

        public static IEnumerable<TResult> ForGet<TSource, TResult>
            ( this (int begin, int end, TSource obj) source,
                Func<int, TSource, TResult> func, bool includeEnd = false )
        {
            var end = source.end;

            for(var i = source.begin; includeEnd ? i <= end : i < end; i++)
            {
                yield return func(i, source.obj);
            }
        }

        public static IEnumerable<TResult> ForGet<TSource, TResult>( this (int end, TSource obj) source,
            Func<int, TSource, TResult> func, bool includeEnd = false  )
        {
            return (0, source.end, source.obj).ForGet(func, includeEnd);
        }
    }
}