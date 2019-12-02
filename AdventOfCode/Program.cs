using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AdventOfCode._2019;
using AdventOfCode._2019._1;
using AdventOfCode._2019._2;

namespace AdventOfCode
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var input = await GetInputAsync();
            var d1 = new Day2(input, 19690720);
            Console.WriteLine(d1.Part2());
        }

        private static async Task<IEnumerable<int>> GetInputAsync()
        {
            var text = await File.ReadAllTextAsync(@"2019/2/input.txt");

            var result = text.Split(",").Select(int.Parse).ToList();
            
            return result;
        }
    }
}