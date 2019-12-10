using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode._2019.Intcode;
using Combinatorics.Collections;

namespace AdventOfCode._2019._7
{
    public class Day7 : IAdventDay<int?, int?>
    {
        private readonly Intcode.Program _program;

        public Day7(int[] code)
        {
            _program = new Intcode.Program(code);
        }


        public int? Part1()
        {
            int GetOutput(IList<int> phases)
            {
                var pipe = new AmplifiersPipe(_program, phases.ToArray());
                return pipe.Execute();
            }

            return new Permutations<int>(Enumerable.Range(0, 5).ToArray()).Select(GetOutput).Max();
        }

        public int? Part2()
        {
            throw new System.NotImplementedException();
        }
    }

    public class AmplifiersPipe
    {
        private readonly Intcode.Program _program;
        private readonly int[] _phases;

        public AmplifiersPipe(Intcode.Program program, int[] phases)
        {
            _program = program;
            _phases = phases;
        }

        public int Execute()
        {
            var intCode = new IntcodeComputer(_program);

            int? currentOutput = 0;
            
            foreach (var phase in _phases)
            {
                if(!currentOutput.HasValue)
                    throw new InvalidProgramException("Broken pipeline");
                
                _program.IO.Enqueue(phase);
                _program.IO.Enqueue(currentOutput.Value);
                currentOutput = intCode.Run();
            }

            return currentOutput ?? throw new InvalidProgramException("Broken pipeline");
        }
    }
}