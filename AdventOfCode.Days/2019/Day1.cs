using System.Linq;

namespace AdventOfCode.Days._2019;

public class Day1 : AdventDay<int[], int, int>
{
    public override int[] ParseRawInput(string rawInput)
    {
        return rawInput.Trim().Select(c => (int)char.GetNumericValue(c)).ToArray();
    }

    public override int Part1(int[] input)
    {
        return input.Sum(CalculateFuel);
    }

    public override int Part2(int[] input)
    {
        return input.Sum(mass =>
        {
            var totalFuel = CalculateFuel(mass);
            var fuel = totalFuel;

            while ((fuel = CalculateFuel(fuel)) > 0)
            {
                totalFuel += fuel;
            }

            return totalFuel;
        });
    }

    private static int CalculateFuel(int mass)
    {
        return mass / 3 - 2;
    }
}
