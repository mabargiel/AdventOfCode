using System;
using System.Linq;

namespace AdventOfCode.Days._2022
{
    public class Day4 : AdventDay<Range[][],int,int>
    {
        public override Range[][] ParseRawInput(string rawInput)
        {
            return rawInput.Trim().Split(Environment.NewLine).Select(info =>
            {
                var pair = info.Split(',');
                return pair
                    .Select(elf => elf.Split('-'))
                    .Select(elf => new Range(int.Parse(elf[0]), int.Parse(elf[1]))).ToArray();
            }).ToArray();
        }

        public override int Part1(Range[][] input)
        {
            var count = 0;
            foreach (var pair in input)
            {
                var (start1, end1) = (pair[0].Start.Value, pair[0].End.Value);
                var (start2, end2) = (pair[1].Start.Value, pair[1].End.Value);
                
                if ((start1 >= start2 && end1 <= end2) || (start2 >= start1 && end2 <= end1))
                {
                    count++;
                }
            }

            return count;
        }

        public override int Part2(Range[][] input)
        {
            var count = 0;
            foreach (var pair in input)
            {
                var (start1, end1) = (pair[0].Start.Value, pair[0].End.Value);
                var (start2, end2) = (pair[1].Start.Value, pair[1].End.Value);
                
                if (!(end1 < start2 || start1 > end2))
                {
                    count++;
                }
            }

            return count;
        }
    }
}