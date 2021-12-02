using System;
using System.Reflection;
using AdventOfCode.Days;
using AdventOfCode.Days.Common;

namespace AdventOfCode
{
    public static class AdventFactory
    {
        public static IAdventDay CreateDay(int year, int day)
        {
            var type = Assembly.GetAssembly(typeof(StringExtensions))
                ?.GetType($"{nameof(AdventOfCode)}.{nameof(Days)}._{year}.Day{day}");
            return (IAdventDay)Activator.CreateInstance(type);
        }
    }
}