using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.Days._2022
{
    public class Day5 : AdventDay<(Stack<char>[] Containers, ContainerCraneAction[] Actions), string, string>
    {
        public override (Stack<char>[] Containers, ContainerCraneAction[] Actions) ParseRawInput(string rawInput)
        {
            var configs = rawInput.Split(Environment.NewLine + Environment.NewLine);
            var stacksLines = configs[0].Split(Environment.NewLine);
            var stacksCount = int.Parse(stacksLines.Last().Substring(stacksLines.Last().Length - 2, 1));
            var stacks = new Stack<char>[stacksCount];

            for (var i = 0; i < stacksCount; i++)
            {
                stacks[i] = new Stack<char>();
            }

            for (var i = stacksLines.Length - 2; i >= 0; i--)
            {
                for (var j = 1; j < stacksCount * 4; j += 4)
                {
                    var containerName = stacksLines[i][j];
                    if(containerName == ' ')
                        continue;
                    
                    stacks[j / 4].Push(containerName);
                }
            }

            var actionRegex = new Regex(@"move (?<count>\d+) from (?<from>\d) to (?<to>\d)");
            var actions = configs[1].Trim().Split(Environment.NewLine).Select(action =>
            {
                var match = actionRegex.Match(action);
                return new ContainerCraneAction(int.Parse(match.Groups["count"].Value),
                    int.Parse(match.Groups["from"].Value), int.Parse(match.Groups["to"].Value));
            }).ToArray();

            return (stacks, actions);
        }

        public override string Part1((Stack<char>[] Containers, ContainerCraneAction[] Actions) input)
        {
            var (containers, actions) = input;
            
            foreach (var action in actions)
            {
                for (var i = 0; i < action.Count; i++)
                {
                    containers[action.To - 1].Push(containers[action.From - 1].Pop());
                }
            }

            return new string(containers.Select(x => x.Pop()).ToArray());
        }

        public override string Part2((Stack<char>[] Containers, ContainerCraneAction[] Actions) input)
        {
            var (containers, actions) = input;
            
            var buffer = new Stack<char>();
            
            foreach (var action in actions)
            {
                for (var i = 0; i < action.Count; i++)
                {
                    buffer.Push(containers[action.From - 1].Pop());
                }

                while (buffer.Any())
                {
                    containers[action.To - 1].Push(buffer.Pop());
                }
            }

            return new string(containers.Select(x => x.Pop()).ToArray());
        }
    }

    public record ContainerCraneAction(int Count, int From, int To);
}