using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SharpExtension.Generic
{
    public static class YieldExtension
    {
        public static IEnumerable<TResult> Yield<T, TResult>(this T obj,
            Func<T, TResult> functor,
            Predicate<T> predicate,
            Action<T> addAction = null)
        {
            while(predicate(obj)){
                yield return functor(obj);
                addAction?.Invoke(obj);
            }
        }

        public static IEnumerable<TResult> Yield<T, TResult>(this T obj,
            Func<T, TResult> functor,
            Func<T, T> functorLocal,
            Predicate<T> predicate)
        {
            var local = obj;

            while(predicate(local)){
                yield return functor(obj);
                local = functorLocal(obj);
            }
        }
    }
}