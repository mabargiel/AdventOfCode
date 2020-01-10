using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdventOfCode._2019.Intcode.Operations;

namespace AdventOfCode._2019.Intcode
{
    public class IntcodeComputer : IIntcodeComputer
    {
        private readonly BlockingCollection<long> _input = new BlockingCollection<long>();
        public Program Program { get; }
        public event Action<long> OnOutput; 

        public IntcodeComputer(IEnumerable<long> code)
        {
            var instructions = code.Select((x, i) => (x, (long) i)).ToDictionary(x => x.Item2, x => x.x);
            Program = new Program(instructions, _input);
            Program.OnOutput += l =>
            {
                OnOutput?.Invoke(l);
            };
        }

        public async Task StartAsync()
        {
            var operationFactory = new OperationFactory(Program);
            var operation = operationFactory.Next();

            await Task.Run(() =>
            {
                while (Program.CurrentInteger() != (int) OpCode.HaltProgram)
                {
                    operation.Execute();
                    operation = operationFactory.Next();
                }
            });
        }

        public void Input(in long value)
        {
            _input.Add(value);
        }
    }
}