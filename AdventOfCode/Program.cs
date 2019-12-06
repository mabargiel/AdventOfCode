using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AdventOfCode._2019._5;
using AdventOfCode._2019._6;

namespace AdventOfCode
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            //var input = await GetInputAsync();

            var input = await File.ReadAllTextAsync(@"2019/6/input.txt");

            var split = input.Split(Environment.NewLine);

            var d1 = new Day6(split);
            Console.WriteLine(d1.Part2());
        }
    }
}