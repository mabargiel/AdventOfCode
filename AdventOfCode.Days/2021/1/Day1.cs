using System.Linq;

namespace AdventOfCode.Days._2021._1
{
    public class Day1 : IAdventDay<int, int>
    {
        private readonly int[] _input;

        public Day1(int[] input)
        {
            _input = input;
        }
        
        public int Part1()
        {
            var result = 0;
            for (var i = 0; i < _input.Length - 1; i++)
            {
                if (_input[i + 1] > _input[i])
                {
                    result++;
                }
            }

            return result;
        }

        public int Part2()
        {
            var result = 0;
            for (var i = 3; i < _input.Length; i++)
            {
                if (_input[i - 3] < _input[i])
                {
                    result++;
                }
            }

            return result;
        }
    }
}