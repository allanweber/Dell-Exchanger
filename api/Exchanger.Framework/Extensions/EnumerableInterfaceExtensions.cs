using System;
using System.Collections.Generic;

namespace Exchanger.Framework.Extensions
{
    public static class EnumerableInterfaceExtensions
    {
        public static IEnumerable<TSource> ForEach<TSource>(this IEnumerable<TSource> source, Action<TSource> action)
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action));

            foreach (var item in source)
                action(item);

            return source;
        }
    }
}
