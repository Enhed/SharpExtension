using System;
using System.Threading.Tasks;

namespace SharpExtension
{
    public static class ObjectsExtension
    {
        public static T Do<T>(this T obj, Action<T> action){
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
    }
}