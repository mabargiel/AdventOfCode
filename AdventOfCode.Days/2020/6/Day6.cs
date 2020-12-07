using System;
using System.Linq;
using System.Text.RegularExpressions;

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
            return _groups.Sum(group => TrimWhiteCharacters(group).GroupBy(c => c).Count());
        }

        public int Part2()
        {
            return _groups.Sum(s => s.GroupBy(c => c).Count(c => c.Count() == s.Split(Environment.NewLine).Length));
        }

        private static string TrimWhiteCharacters(string s)
        {
            return Regex.Replace(s, @"\s", string.Empty);
        }
    }
}