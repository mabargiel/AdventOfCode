using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdventOfCode._2019.Intcode;
using Combinatorics.Collections;

namespace AdventOfCode._2019._7
{
    public class Day7 : IAdventDay<long, long>
    {
        private readonly int _input;
        private readonly Intcode.Program _program;

        public Day7(Dictionary<long, long> code, int input)
        {
            _input = input;
            _program = new Intcode.Program(code);
        }


        public long Part1()
        {
            long GetOutput(IList<int> phases)
            {
                var pipe = new AmplifiersPipe(_program, phases.ToArray(), _input);
                return pipe.Execute();
            }

            return new Permutations<int>(Enumerable.Range(0, 5).ToArray()).Select(GetOutput).Max();
        }

        public long Part2()
        {
            async Task<long> GetOutput(IEnumerable<int> phases)
            {
                var pipe = new FeedbackAmplifiersPipe(_program, phases.ToArray(), _input);
                return await pipe.ExecuteAsync();
            }

            var permutations = new Permutations<int>(Enumerable.Range(5, 5).ToArray());
            var result = permutations.Select(x => GetOutput(x).Result).ToArray();
            return result.Any() ? result.Max() : -1;
        }
    }
    
    public class AmplifiersPipe
    {
        private readonly Intcode.Program _program;
        private readonly int[] _phases;
        private readonly int _input;

        public AmplifiersPipe(Intcode.Program program, int[] phases, int input)
        {
            _program = program;
            _phases = phases;
            _input = input;
        }

        public long Execute()
        {
            long currentOutput = _input;
            
            foreach (var phase in _phases)
            {
                var program = (Intcode.Program) _program.Clone();
                var intCode = new IntcodeComputer(program);
                
                program.Buffer.Add(phase);
                program.Buffer.Add(currentOutput);
                currentOutput = intCode.Run().First();
            }

            return currentOutput;
        }
    }

    public class FeedbackAmplifiersPipe
    {
        private readonly Intcode.Program _program;
        private readonly int[] _phases;
        private readonly int _input;

        public FeedbackAmplifiersPipe(Intcode.Program program, int[] phases, int input)
        {
            _program = program;
            _phases = phases;
            _input = input;
        }

        public virtual async Task<long> ExecuteAsync()
        {
            var amplifiers = ConfigureAmplifiers();

            var amplifierThreads = amplifiers.Select(amplifier => Task.Run(amplifier.Run));
            var results = await Task.WhenAll(amplifierThreads);

            return results[^1].FirstOrDefault();
        }

        private IEnumerable<IntcodeComputer> ConfigureAmplifiers()
        {
            var amplifiers = new LinkedList<IntcodeComputer>(_phases.Select(phase =>
            {
                var program = (Intcode.Program) _program.Clone();
                program.Buffer.Add(phase);
                return new IntcodeComputer(program);
            }));

            foreach (var amplifier in amplifiers)
            {
                var current = amplifiers.Find(amplifier);
                var next = current?.Next ?? amplifiers.First;
                if(current != null)
                    current.Value.Program.OnOutput += output =>
                    {
                        if (next.Value.Program.Memory != null)
                            next.Value.Program.Buffer.Add(output);
                        else current.Value.Program.Buffer.Add(output);
                    };
            }

            amplifiers.First.Value.Program.Buffer.Add(_input);
            return amplifiers;
        }
    }
}