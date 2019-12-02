using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2019._1
{
    public class Day1 : IAdventDay<int, int>
    {
        private readonly IEnumerable<int> _input;

        public Day1(IEnumerable<int> input)
        {
            _input = input;
        }

        public int Part1()
        {
            return _input.Sum(CalculateFuel);
        }

        public int Part2()
        {
            return _input.Sum(mass =>
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
            return (int) Math.Floor(mass / 3d) - 2;
        }
    }
}