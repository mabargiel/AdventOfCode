using System;
using System.IO;
using System.Threading.Tasks;
using AdventOfCode.Days._2020._6;

namespace AdventOfCode
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            var input = await File.ReadAllTextAsync("2020/6/input.txt");

            var d6 = new Day6(input);

            var result = d6.Part2();

            Console.WriteLine(result);
        }
    }
}