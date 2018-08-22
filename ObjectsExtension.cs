using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SharpExtension.For;

namespace SharpExtension
{
    public static class ObjectsExtension
    {
        public static T Do<T>(this T obj, Action<T> action)
        {
            action(obj);
            return obj;
        }

        public static async Task<T> DoAsync<T>(this T obj, Func<T, Task> functor){
            await functor(obj).ConfigureAwait(false);
            return obj;
        }

        public static TResult Get<T, TResult>(this T obj, Func<T, TResult> functor)
            => functor(obj);

        public static Task<TResult> GetAsync<T, TResult>(this T obj, Func<T, Task<TResult>> functor)
            => functor(obj);

        public static TResult Cast<TResult>(this object source)
        {
            return source is TResult result ? result : (TResult) source;
        }

        public static TValue[] Repeat<TValue>(this TValue target, int count)
        {
            return count.ForGet(x => target).ToArray();
        }

        public static string CreateString<TValue>(this IEnumerable<TValue> array, string separator = null)
        {
            return array?.Select(v => v.ToString()).Join(separator);
        }
    }
}