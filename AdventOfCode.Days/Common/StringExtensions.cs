using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Days.Common
{
    public static class StringExtensions
    {
        public static IEnumerable<string> Batch(this string s, int size)
        {
            return Enumerable.Range(0, s.Length / size)
                .Select(i => s.Substring(i * size, i * size + size <= s.Length ? size : s.Length - i * size));
        }
    }
}