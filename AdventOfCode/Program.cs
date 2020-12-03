using System;
using System.IO;
using System.Threading.Tasks;
using AdventOfCode.Days._2020._3;

namespace AdventOfCode
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            var input = await File.ReadAllTextAsync("2020/3/input.txt");

            var d3 = new Day3(input);

            var result = d3.Part2();

            Console.WriteLine(result);
        }
    }
}