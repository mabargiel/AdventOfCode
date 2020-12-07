using System;
using System.IO;
using System.Threading.Tasks;
using AdventOfCode.Days._2020._7;

namespace AdventOfCode
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            var input = await File.ReadAllTextAsync("2020/7/input.txt");

            var d7 = new Day7(input);

            var result = d7.Part2();

            Console.WriteLine(result);
        }
    }
}