using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode._2019._12
{
    public class Day12 : IAdventDay<int, long>
    {
        private readonly JupiterSpace _jupiterSpace;
        private readonly int _timesteps;

        public Day12(string input, int timesteps = 0)
        {
            _timesteps = timesteps;
            _jupiterSpace = new JupiterSpace(ParseMoons(input).ToArray());
        }

        public int Part1()
        {
            for (var i = 0; i < _timesteps; i++)
            {
                _jupiterSpace.MoveTime(new[] { "X", "Y", "Z" });
            }

            return _jupiterSpace.TotalEnergy();
        }

        public long Part2()
        {
            return _jupiterSpace.MoveTimeUntilRepeat();
        }

        private static IEnumerable<Moon> ParseMoons(string input)
        {
            var regex = new Regex(@"\<x=(?<x>(-)?\d+), y=(?<y>(-)?\d+), z=(?<z>(-)?\d+)\>");

            var matches = regex.Matches(input);

            foreach (Match match in matches)
            {
                var x = int.Parse(match.Groups["x"].ToString());
                var y = int.Parse(match.Groups["y"].ToString());
                var z = int.Parse(match.Groups["z"].ToString());

                yield return new Moon(new Point3(x, y, z));
            }
        }
    }
}