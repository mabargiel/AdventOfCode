using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Days._2021;

public class Day6 : AdventDay<(int[] School, int Days), int, long>
{
    private const int NormalCycle = 7;
    private const int NewCycle = NormalCycle + 2;

    public override (int[], int) ParseRawInput(string rawInput)
    {
        return (rawInput.Trim().Split(',').Select(int.Parse).ToArray(), 0);
    }

    public override int Part1((int[] School, int Days) input)
    {
        var (school, days) = input;
        return (int)SimulateFishGrowth(school, days == 0 ? 80 : days);
    }

    public override long Part2((int[] School, int Days) input)
    {
        var (school, days) = input;
        return SimulateFishGrowth(school, days == 0 ? 256 : days);
    }

    private static long SimulateFishGrowth(IReadOnlyCollection<int> school, int days)
    {
        Dictionary<int, long> birthdayMap = new();

        var group = school.GroupBy(x => x).ToList();

        for (var i = 1; i <= days; i++)
        {
            birthdayMap[i] = group.FirstOrDefault(x => x.Key == i)?.Count() ?? 0;
        }

        var totalFishBorn = 0L;

        for (var i = 1; i <= days; i++)
        {
            var amountOfFishBorn = birthdayMap[i];

            if (amountOfFishBorn == 0)
            {
                continue;
            }

            var nextBirthday = i + NormalCycle;
            var nextChildBirthday = i + NewCycle;

            if (nextBirthday < days)
            {
                birthdayMap[nextBirthday] += amountOfFishBorn;
            }

            if (nextChildBirthday < days)
            {
                birthdayMap[nextChildBirthday] += amountOfFishBorn;
            }

            birthdayMap.Remove(i);
            totalFishBorn += amountOfFishBorn;
        }

        return totalFishBorn + school.Count;
    }
}