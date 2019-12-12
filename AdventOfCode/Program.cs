using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AdventOfCode._2019._8;
using MoreLinq.Extensions;

namespace AdventOfCode
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            var input = await File.ReadAllTextAsync("2019/8/input.txt");

            var d8 = new Day8(input, 25, 6);

            var message = d8.Part2().Batch(25);

            foreach (var row in message)
            {
                Console.WriteLine(new string(row.Select(x => x == '1' ? '@' : ' ').ToArray()));
            }
        }
    }
}