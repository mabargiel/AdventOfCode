using System;
using System.IO;
using System.Threading.Tasks;
using AdventOfCode.Days._2020._4;

namespace AdventOfCode
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            var input = await File.ReadAllTextAsync("2020/4/input.txt");

            var d4 = new Day4(input);

            var result = d4.Part2();

            Console.WriteLine(result);
        }
    }
}