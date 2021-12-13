using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Days.Common
{
    public static class ArrExt
    {
        public static int Count<T>(this T[,] array, Func<T, bool> predicate)
        {
            var result = 0;
            for (var y = 0; y < array.GetLength(0); y++)
            {
                for (var x = 0; x < array.GetLength(1); x++)
                {
                    if (predicate.Invoke(array[y, x]))
                    {
                        result++;
                    }
                }
            }
            
            return result;
        }
        
        public static bool Any<T>(this T[,] array, Func<T, bool> predicate)
        {
            for (var y = 0; y < array.GetLength(0); y++)
            {
                for (var x = 0; x < array.GetLength(1); x++)
                {
                    if (predicate.Invoke(array[y, x]))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
        
        public static IEnumerable<(int Y, int X)> Where<T>(this T[,] array, Func<T, bool> predicate)
        {
            for (var y = 0; y < array.GetLength(0); y++)
            {
                for (var x = 0; x < array.GetLength(1); x++)
                {
                    if (predicate.Invoke(array[y, x]))
                    {
                        yield return (y, x);
                    }
                }
            }
        }
    }
}