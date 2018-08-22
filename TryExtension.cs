using System;
using System.Threading.Tasks;

namespace SharpExtension.Try
{
    public static class TryExtension
    {
        public static TResult Try<T, TResult>(this T obj,
            Func<T, TResult> functor,
            TResult defaultResult = default(TResult),
            Action<Exception> onExn = null){
            try{
                return functor(obj);
            }
            catch(Exception exn){
                onExn?.Invoke(exn);
                return defaultResult;
            }
        }

        public static TResult Try<T, TResult>(this T obj,
            Func<T, TResult> functor,
            TResult defaultResult = default(TResult),
            Action<T, Exception> onExn = null){
            try{
                return functor(obj);
            }
            catch(Exception exn){
                onExn?.Invoke(obj, exn);
                return defaultResult;
            }
        }

        public static T Try<T>(this T obj, Action<T> action,
            Action<Exception> onExn = null){
            try{
                action(obj);
            }
            catch(Exception exn){
                onExn?.Invoke(exn);
            }

            return obj;
        }

        public static T Try<T>(this T obj, Action<T> action,
            Action<T, Exception> onExn = null){
            try{
                action(obj);
            }
            catch(Exception exn){
                onExn?.Invoke(obj, exn);
            }

            return obj;
        }

        public static async Task<T> TryAsync<T>(this T obj,
            Func<T, Task> functor,
            Action<Exception> onExn = null){
            try{
                await functor(obj);
            }
            catch(Exception exn){
                onExn?.Invoke(exn);
            }
            
            return obj;
        }

        public static async Task<TResult> TryAsync<T, TResult>(this T obj,
            Func<T, Task<TResult>> functor,
            TResult defaultResult = default(TResult),
            Action<Exception> onExn = null){
            try{
                return await functor(obj);
            }
            catch(Exception exn){
                onExn?.Invoke(exn);
                return defaultResult;
            }
        }

        public static T TryCount<T>(this T obj, Action<T> action,
            int count,
            Action<Exception> onExn = null){
            
            Exception lastExn = null;

            for(var i = 0; i < count; ++i){

                try{
                    action(obj);
                    return obj;
                }
                catch(Exception exn){
                    onExn?.Invoke(exn);
                    lastExn = exn;
                }

            }

            throw lastExn;
        }

        public static T TryTime<T>(this T obj, Action<T> action,
            TimeSpan timeOut,
            Action<Exception> onExn = null){
            
            DateTime begin = DateTime.Now;
            Exception lastExn = null;

            do{
                try{
                    action(obj);
                    return obj;
                }
                catch(Exception exn){ lastExn = exn; onExn?.Invoke(exn); }
            }while(begin - DateTime.Now < timeOut);

            throw lastExn;
        }
    }
}