using System;
using SharpExtension.Try;

namespace SharpExtension.Using
{
    public static class UsingExtension
    {
        public static void Using<T>(this T disposable, Action<T> action)
            where T : IDisposable
        {
            using(disposable)
            {
                action(disposable);
            }
        }

        public static TResult Using<T, TResult>(this T disposable, Func<T, TResult> functor)
            where T : IDisposable
        {
            using(disposable)
            {
                return functor(disposable);
            }
        }

        public static void TryUsing<T>(this T disposable, Action<T> action,
            Action<Exception> onExn = null)
            where T : IDisposable
        {
            using(disposable)
            {
                disposable.Try(action, onExn);
            }
        }

        public static TResult TryUsing<TResult, T>(this T disposable, Func<T, TResult> functor,
            TResult defaultResult = default(TResult), Action<Exception> onExn = null)
            where T : IDisposable
        {
            using(disposable)
            {
                return disposable.Try(functor, defaultResult, onExn);
            }
        }
    }
}