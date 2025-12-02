using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdventOfCode.Days._2019.Intcode;

namespace AdventOfCode.Days._2019._7;

public class AmplifiersPipe
{
    private readonly long[] _code;
    private readonly int _input;
    private readonly int[] _phases;

    public AmplifiersPipe(long[] code, int[] phases, int input)
    {
        _code = code;
        _phases = phases;
        _input = input;
    }

    public async Task<long> ExecuteAsync()
    {
        var amplifiers = new LinkedList<IntcodeComputer>(
            _phases.Select(phase =>
            {
                var intcodeComputer = new IntcodeComputer(_code);
                intcodeComputer.Input(phase);
                return intcodeComputer;
            })
        );

        var currentOutput = 0L;

        foreach (var amplifier in amplifiers)
        {
            var current = amplifiers.Find(amplifier);
            var next = current?.Next ?? amplifiers.First;
            if (current != null)
            {
                current.Value.OnOutput += output =>
                {
                    if (next.Value.Program.Memory != null)
                    {
                        next.Value.Input(output);
                    }

                    currentOutput = output;
                };
            }
        }

        amplifiers.First.Value.Input(_input);
        await Task.WhenAll(amplifiers.Select(amplifier => amplifier.StartAsync()));

        return currentOutput;
    }
}
