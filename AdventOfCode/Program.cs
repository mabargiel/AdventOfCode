using System;
using System.IO;
using System.Threading.Tasks;
using AdventOfCode.Days._2020._7;
using AdventOfCode.Days._2020._8;

namespace AdventOfCode
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            var input = await File.ReadAllTextAsync("2020/8/input.txt");

            var d8 = new Day8(input);

            var result = d8.Part2();

            Console.WriteLine(result);
        }
    }
}