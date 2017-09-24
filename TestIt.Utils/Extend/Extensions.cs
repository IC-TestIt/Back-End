using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace TestIt.Utils.Extend
{
    public static class Extensions
    {
        public static int Count(this string value, IEnumerable<string> subStrings)
        {
            var result = subStrings.Select(x =>
                               new
                               {
                                   word = x,
                                   exists = Regex.IsMatch(value, @"\b" + x + @"\b")
                               }
                            );

            return result.Count(x => x.exists);
        }

        public static void ForEachWithIndex<T>(this IEnumerable<T> enumerable, Action<T, int> handler)
        {
            int idx = 0;
            foreach (T item in enumerable)
                handler(item, idx++);
        }
    }
}
