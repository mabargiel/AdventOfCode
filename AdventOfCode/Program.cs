using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AdventOfCode._2019._10;
using AdventOfCode._2019._11;
using AdventOfCode._2019._12;
using AdventOfCode._2019._8;
using AdventOfCode._2019._9;
using MoreLinq.Extensions;

namespace AdventOfCode
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            var input = @"<x=-9, y=10, z=-1>
<x=-14, y=-8, z=14>
<x=1, y=5, z=6>
<x=-19, y=7, z=8>";
            
            var d9 = new Day12(input, 1000);

            var result = d9.Part2();
            
            Console.WriteLine(result);
        }
    }
}