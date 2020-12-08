using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.Days._2020._8
{
    public class Day8 : IAdventDay<int, int>
    {
        private readonly Process _process;

        public Day8(string input)
        {
            var operations = new List<Instruction>();

            foreach (var instr in input.Split(Environment.NewLine))
            {
                var match = Regex.Match(instr, @"^(?<operation>.{3}) (?<argument>(\+|\-)\d+)$");

                var operation = match.Groups["operation"].ToString();
                var argumentString = match.Groups["argument"].ToString();
                var argument = int.Parse(argumentString.Substring(1, argumentString.Length - 1));

                argument *= argumentString[0] == '+' ? 1 : -1;

                switch (operation)
                {
                    case "nop":
                        operations.Add(new NoInstruction(argument));
                        break;
                    case "jmp":
                        operations.Add(new JumpInstruction(argument));
                        break;
                    case "acc":
                        operations.Add(new AccInstruction(argument));
                        break;
                }
            }

            _process = new Process(operations);
        }

        public int Part1()
        {
            var visitedInstructions = new HashSet<Instruction>();
            var acc = 0;

            while (!visitedInstructions.Contains(_process.CurrentInstruction))
            {
                visitedInstructions.Add(_process.CurrentInstruction);
                acc = _process.ExecuteNext();
            }

            return acc;
        }

        public int Part2()
        {
            var visitedInstructions = new HashSet<Instruction>();
            var process = _process;
            var operationsToTest =
                new Queue<Instruction>(
                    _process.LoadedProgram.Where(instr => instr is JumpInstruction or NoInstruction));

            while (true)
            {
                visitedInstructions.Add(process.CurrentInstruction);
                var acc = process.ExecuteNext();

                if (process.RanToCompletion)
                    return acc;

                if (!visitedInstructions.Contains(process.CurrentInstruction)) continue;

                var newProgram = new List<Instruction>(_process.LoadedProgram);
                var opToReplace = operationsToTest.Dequeue();
                newProgram[newProgram.IndexOf(opToReplace)] =
                    opToReplace is NoInstruction
                        ? new JumpInstruction(process.CurrentInstruction.Argument)
                        : new NoInstruction(process.CurrentInstruction.Argument);
                process = new Process(newProgram);
                visitedInstructions = new HashSet<Instruction>();
            }
        }
    }
}