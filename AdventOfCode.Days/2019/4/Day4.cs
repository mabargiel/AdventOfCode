using System.Linq;

namespace AdventOfCode.Days._2019._4;

public class Day4 : IAdventDay<int, int>
{
    private readonly int[] _digits;
    private readonly int _end;

    public Day4(in int start, in int end)
    {
        _digits = start.ToString().Select(c => (int)char.GetNumericValue(c)).ToArray();
        ;
        _end = end;
    }

    public int Part1()
    {
        var password = new Part1Password(_digits);
        return CountPasswordPossibilities(password);
    }

    public int Part2()
    {
        var password = new Part2Password(_digits);
        return CountPasswordPossibilities(password);
    }

    private int CountPasswordPossibilities(Password password)
    {
        var possibilities = 0;

        while (password.Value <= _end)
        {
            if (password.IsValid())
            {
                possibilities++;
            }

            password.Increment();
        }

        return possibilities;
    }
}
