using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CommandLine;
using CommandLine.Text;

namespace AdventOfCode;

public class Options
{
    public Options(string inputFile, string input, int year, int day, bool part1, bool part2)
    {
        InputFile = inputFile;
        Input = input;
        Year = year;
        Day = day;
        Part1 = part1;
        Part2 = part2;
    }

    [Option("file")]
    public string InputFile { get; }

    [Option("input")]
    public string Input { get; }

    [Option("year", Required = true)]
    public int Year { get; }

    [Option("day", Required = true)]
    public int Day { get; }

    [Option("part1")]
    public bool Part1 { get; }

    [Option("part2")]
    public bool Part2 { get; }

    [Usage(ApplicationAlias = "AdventOfCode")]
    public static IEnumerable<Example> Examples =>
        new List<Example>
        {
            new(
                "Run Part 1 of Day 1 2018",
                new Options("/path/to/file.txt", string.Empty, 2018, 1, true, false)
            ),
            new(
                "Run Both Parts of Day 10 2021",
                new Options("/path/to/file.txt", string.Empty, 2021, 10, true, true)
            ),
            new(
                "Run Both Parts of Day 10 2021 with input instead of file",
                new Options(string.Empty, "100", 2021, 10, true, true)
            ),
        };
}

internal class Program
{
    private static async Task Main(string[] args)
    {
        await new Parser(with => with.EnableDashDash = true)
            .ParseArguments<Options>(args)
            .MapResult(
                RunTask,
                errors =>
                {
                    foreach (
                        var error in errors.Where(e =>
                            e.Tag
                                is not ErrorType.HelpRequestedError
                                    or ErrorType.VersionRequestedError
                        )
                    )
                    {
                        Console.WriteLine(error.ToString());
                    }

                    return Task.FromResult(1);
                }
            );
    }

    private static async Task<int> RunTask(Options options)
    {
        if (!options.Part1 && !options.Part2)
        {
            Console.WriteLine("Select at least one part to be executed");
            return 1;
        }

        if (string.IsNullOrEmpty(options.Input) && string.IsNullOrEmpty(options.InputFile))
        {
            Console.WriteLine("No input or input file provided");
        }

        if (!string.IsNullOrEmpty(options.Input) && !string.IsNullOrEmpty(options.InputFile))
        {
            Console.WriteLine("Provide either input or input file. Not both.");
        }

        var text = string.IsNullOrEmpty(options.Input)
            ? await File.ReadAllTextAsync(options.InputFile)
            : options.Input;

        var adventDay = AdventFactory.CreateDay(options.Year, options.Day);

        if (options.Part1)
        {
            string result;
            try
            {
                result = adventDay.ExecutePart1(text);
            }
            catch (NotImplementedException)
            {
                result = "Part 1 >\n>>> Not yet implemented";
            }

            Console.WriteLine(result);
        }

        if (options.Part2)
        {
            string result;
            try
            {
                result = adventDay.ExecutePart2(text);
            }
            catch (NotImplementedException)
            {
                result = "Part 2 >\n>>> Not yet implemented";
            }

            Console.WriteLine(result);
        }

        return 0;
    }
}
