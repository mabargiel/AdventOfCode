using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using CommandLine;
using CommandLine.Text;

namespace AdventOfCode
{
    public class Options
    {
        private readonly string _inputFile;
        private readonly int _year;
        private readonly int _day;
        private readonly bool _part1;
        private readonly bool _part2;

        public Options(string inputFile, int year, int day, bool part1, bool part2)
        {
            _inputFile = inputFile;
            _year = year;
            _day = day;
            _part1 = part1;
            _part2 = part2;
        }

        [Option("file", Required = true)]
        public string InputFile => _inputFile;

        [Option("year", Required = true)]
        public int Year => _year;
        
        [Option("day", Required = true)]
        public int Day => _day;

        [Option("part1")]
        public bool Part1 => _part1;

        [Option("part2")]
        public bool Part2 => _part2;
        
        [Usage(ApplicationAlias = "AdventOfCode")]
        public static IEnumerable<Example> Examples =>
            new List<Example>() {
                new("Run Part 1 of Day 1 2018", new Options("/path/to/file.txt", 2018, 1, true, false)),
                new("Run Both Parts of Day 10 2021", new Options("/path/to/file.txt", 2021, 10, true, true))
            };
    }
    
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            await new Parser(with => with.EnableDashDash = true).ParseArguments<Options>(args)
                .MapResult(RunTask, errors =>
                {
                    foreach (var error in errors)
                    {
                        Console.WriteLine(error.ToString());
                    }

                    return Task.FromResult(1);
                });
        }

        private static async Task<int> RunTask(Options options)
        {
            if (!options.Part1 && !options.Part2)
            {
                Console.WriteLine("Select at least one part to be executed");
                return 1;
            }
            
            var text = await File.ReadAllTextAsync(options.InputFile);
            var adventDay = AdventFactory.CreateDay(options.Year, options.Day);

            if (options.Part1)
            {
                string result;
                try
                {
                    result = adventDay.Part1(text);
                }
                catch (NotImplementedException)
                {
                    result = "Not yet implemented";
                }
                
                Console.WriteLine($"PART1= {result}");
            }
            
            if (options.Part2)
            {
                string result;
                try
                {
                    result = adventDay.Part2(text);
                }
                catch (NotImplementedException)
                {
                    result = "Not yet implemented";
                }
                
                Console.WriteLine($"PART2= {result}");
            }

            return 0;
        }
    }
}