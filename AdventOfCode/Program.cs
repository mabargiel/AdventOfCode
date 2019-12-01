using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using AdventOfCode._2019;

namespace AdventOfCode
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var input = await GetInputAsync();
            var d1 = new Day1(input);
            Console.WriteLine(d1.Part2());
        }

        private static async Task<IEnumerable<int>> GetInputAsync()
        {
            var result = new List<int>();
            using var reader = new StreamReader(File.OpenRead(@"2019/input.txt"));
            string line;
            while ((line = await reader.ReadLineAsync()) != null)
            {
                result.Add(int.Parse(line));
            }

            return result;
        }
    }
}