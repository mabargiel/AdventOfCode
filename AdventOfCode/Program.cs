using System;
using System.IO;
using System.Threading.Tasks;
using AdventOfCode.Days._2020._2;

namespace AdventOfCode
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            var input = await File.ReadAllTextAsync("2020/2/input.txt");

            var d2 = new Day2(input);

            var result = d2.Part2();

            Console.WriteLine(result);
        }
    }
}