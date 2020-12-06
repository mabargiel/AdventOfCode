using System;
using System.Linq;
using System.Text.RegularExpressions;
using MoreLinq;

namespace AdventOfCode.Days._2020._6
{
    public class Day6 : IAdventDay<int, int>
    {
        private readonly string[] _groups;

        public Day6(string input)
        {
            _groups = input.Split(Environment.NewLine + Environment.NewLine);
        }
        
        public int Part1()
        {
            return _groups.Sum(group => Regex.Matches(group, @"[a-z]").DistinctBy(c => c.Value).Count());
        }

        public int Part2()
        {
            return (from @group in _groups
                let pplCount = @group.Split('\n').Length
                select Regex.Matches(@group, @"[a-z]").DistinctBy(c => c.Value)
                    .Select(c => @group.Count(c2 => c.Value[0] == c2))
                    .Count(o => o == pplCount)).Sum();
        }
    }
}