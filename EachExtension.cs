using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SharpExtension;
using SharpExtension.Try;

namespace SharpExtension.Generic
{
    public static class EnumerableExtension
    {
        public static IEnumerable<T> Each<T>(this IEnumerable<T> enumerable, Action<T> action){
            foreach(var item in enumerable){
                action(item);
            }

            return enumerable;
        }

        public static IEnumerable<T> TryEach<T>(this IEnumerable<T> enumerable, Action<T> action,
            Action<Exception> onExn = null){

            foreach(var item in enumerable){
                item.Try(action, onExn);
            }

            return enumerable;
        }

        public static IEnumerable<T> TryEach<T>(this IEnumerable<T> enumerable, Action<T> action,
            Action<T, Exception> onExn = null){

            foreach(var item in enumerable){
                item.Try(action, onExn);
            }

            return enumerable;
        }

        public static TEnumerable Each<TEnumerable, T>(this TEnumerable enumerable, Action<T> action)
            where TEnumerable : IEnumerable<T>
        {
            enumerable.Each(action);
            return enumerable;
        }

        public static async Task<IEnumerable<T>> EachAsync<T>(this IEnumerable<T> enumerable,
            Func<T, Task> functor)
        {
            await Task.WhenAll(enumerable.Select(functor)).ConfigureAwait(false);
            return enumerable;
        }
    }
}