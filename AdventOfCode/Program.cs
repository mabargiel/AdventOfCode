using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AdventOfCode.Days._2021._1;

namespace AdventOfCode
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            var text = await File.ReadAllTextAsync("2021/1/input.txt");

            var input = text.Split(Environment.NewLine).Select(int.Parse).ToArray();

            var d1 = new Day1(input);

            var result = d1.Part2();

            Console.WriteLine(result);
        }
    }
}