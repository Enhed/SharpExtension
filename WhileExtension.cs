using System;
using System.Threading.Tasks;
using SharpExtension.Try;

namespace SharpExtension.While
{
    public static class WhileExtension
    {
        public static T WhileDo<T>(this T obj, Action<T> action, Predicate<T> predicate)
        {
            while(predicate(obj)){
                action(obj);
            }

            return obj;
        }

        public static T WhileDo<T>(this T obj, Func<T, T> functor, Predicate<T> predicate)
        {
            var local = obj;

            while(predicate(local)){
                local = functor(obj);
            }

            return local;
        }

        public static T WhileTry<T>(this T obj, Action<T> action, Predicate<T> predicate,
            Action<Exception> onExn = null)
        {
            while(predicate(obj)){
                obj.Try(action, onExn);
            }

            return obj;
        }
    }
}