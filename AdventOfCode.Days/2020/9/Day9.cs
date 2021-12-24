using System;
using System.Linq;
using Combinatorics.Collections;

namespace AdventOfCode.Days._2020._9;

public class Day9 : IAdventDay<long, long>
{
    private readonly long[] _nums;
    private readonly int _preambleLength;

    public Day9(string input, int preambleLength)
    {
        _preambleLength = preambleLength;
        _nums = input.Split(Environment.NewLine).Select(long.Parse).ToArray();
    }

    public long Part1()
    {
        for (var i = _preambleLength; i < _nums.Length; i++)
        {
            var sums = new Combinations<long>(_nums[(i - _preambleLength)..i], 2).Select(it => it.Sum());

            if (sums.All(sum => sum != _nums[i]))
            {
                return _nums[i];
            }
        }

        throw new InvalidOperationException("Unable to find invalid number");
    }

    public long Part2()
    {
        var invalidNumber = Part1();

        for (var i = 0; i < _nums.Length; i++)
        {
            if (_nums[i] == invalidNumber)
            {
                continue;
            }

            var sum = 0L;

            for (var j = i; j < _nums.Length - 1; j++)
            {
                sum += _nums[j];
                if (sum == invalidNumber)
                {
                    var set = _nums[i..(j + 1)];
                    return set.Min() + set.Max();
                }

                if (sum > invalidNumber)
                {
                    break;
                }
            }
        }

        throw new InvalidOperationException("Unable to find weakness");
    }
}