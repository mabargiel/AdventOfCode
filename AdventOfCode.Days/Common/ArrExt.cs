using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

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
        
        public static IEnumerable<T> GetRow<T>(this T[,] array, int row)
        {
            if (!typeof(T).IsPrimitive)
            {
                throw new InvalidOperationException("Not supported for managed types.");
            }

            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            var cols = array.GetUpperBound(1) + 1;
            var result = new T[cols];

            int size;

            if (typeof(T) == typeof(bool))
            {
                size = 1;
            }
            else if (typeof(T) == typeof(char))
            {
                size = 2;
            }
            else
            {
                size = Marshal.SizeOf<T>();
            }

            Buffer.BlockCopy(array, row * cols * size, result, 0, cols * size);

            return result;
        }
    }
}