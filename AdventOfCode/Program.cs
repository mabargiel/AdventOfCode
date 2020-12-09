using System;
using System.IO;
using System.Threading.Tasks;
using AdventOfCode.Days._2020._9;

namespace AdventOfCode
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            var input = await File.ReadAllTextAsync("2020/9/input.txt");

            var d9 = new Day9(input, 25);

            var result = d9.Part2();

            Console.WriteLine(result);
        }
    }
}