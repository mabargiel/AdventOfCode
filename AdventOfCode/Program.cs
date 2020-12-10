using System;
using System.IO;
using System.Threading.Tasks;
using AdventOfCode.Days._2020._10;

namespace AdventOfCode
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            var input = await File.ReadAllTextAsync("2020/10/input.txt");

            var d10 = new Day10(input);

            var result = d10.Part2();

            Console.WriteLine(result);
        }
    }
}