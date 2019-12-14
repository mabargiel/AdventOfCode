using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdventOfCode._2019.Intcode;

namespace AdventOfCode._2019._7
{
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

        public async Task<long> ExecuteAsync()
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