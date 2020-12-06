using System;
using System.IO;
using System.Threading.Tasks;
using AdventOfCode.Days._2020._5;

namespace AdventOfCode
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            var input = await File.ReadAllTextAsync("2020/5/input.txt");

            var d5 = new Day5(input);

            var result = d5.Part2();

            Console.WriteLine(result);
        }
    }
}