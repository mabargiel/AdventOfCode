using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AdventOfCode.Days._2020._1;

namespace AdventOfCode
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            var input = await File.ReadAllTextAsync("2020/1/input.txt");

            var inputValues = input.Split(Environment.NewLine).Select(int.Parse);

            var d1 = new Day1(inputValues);

            var result = d1.Part2();

            Console.WriteLine(result);
        }
    }
}