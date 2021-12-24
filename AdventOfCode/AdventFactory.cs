using System;
using System.Reflection;
using AdventOfCode.Days;
using AdventOfCode.Days.Common;

namespace AdventOfCode;

public static class AdventFactory
{
    public static IAdventDay CreateDay(int year, int day)
    {
        var type = Assembly.GetAssembly(typeof(StringExtensions))
            ?.GetType($"{nameof(AdventOfCode)}.{nameof(Days)}._{year}.Day{day}")
            ?? throw new InvalidOperationException("Could not create Day type from the given parameters");
        
        return (IAdventDay)Activator.CreateInstance(type);
    }
}