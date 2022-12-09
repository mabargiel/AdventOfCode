using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode.Days._2022;

public class Day7 : AdventDay<string[], int, int>
{
    public override string[] ParseRawInput(string rawInput)
    {
        return rawInput.Trim().Split(Environment.NewLine);
    }

    public override int Part1(string[] input)
    {
        var fileSystem = BuildFileSystem(input);
        return fileSystem.Values.Where(v => v <= 100_000).Sum();
    }

    public override int Part2(string[] input)
    {
        const int totalDiskSpace = 70000000;
        const int requiredFreeSpace = 30000000;

        var fileSystem = BuildFileSystem(input);
        var currentFreeSpace = totalDiskSpace - fileSystem["/"];
        return fileSystem.Values.Where(size => currentFreeSpace + size >= requiredFreeSpace).Min();
    }

    private static Dictionary<string, int> BuildFileSystem(string[] input)
    {
        var trace = new Stack<string>(new[] { "/" });
        var fileSystem = new Dictionary<string, int> { ["/"] = 0 };

        foreach (var line in input[1..])
        {
            if (line.StartsWith("$ ls") || line.StartsWith("dir"))
            {
                continue;
            }

            if (line.StartsWith("$"))
            {
                var value = line[5..]; // "$ cd *"

                if (value == "..")
                {
                    trace.Pop();
                }
                else
                {
                    var path = Path.Combine(trace.Peek(), value);
                    trace.Push(path);
                    fileSystem[path] = 0;
                }
            }
            else
            {
                foreach (var dir in trace)
                {
                    fileSystem[dir] += int.Parse(line[..line.IndexOf(' ')]);
                }
            }
        }

        return fileSystem;
    }
}