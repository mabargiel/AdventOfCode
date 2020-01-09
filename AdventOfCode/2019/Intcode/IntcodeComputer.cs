using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdventOfCode._2019.Intcode.Operations;

namespace AdventOfCode._2019.Intcode
{
    public class IntcodeComputer : IIntcodeComputer
    {
        public Program Program { get; }

        public IntcodeComputer(Program program)
        {
            Program = program;
        }

        public long[] Run()
        {
            var operationFactory = new OperationFactory(Program);
            var operation = operationFactory.Next();

            while (Program.CurrentInteger() != (int) OpCode.HaltProgram)
            {
                operation.Execute();
                operation = operationFactory.Next();
            }

            return Program.Buffer.ToArray();
        }

        public void Input(long value)
        {
            this.Program.Buffer.Add(value);
        }

        public async Task<long[]> RunAsync()
        {
            return await Task.Run(Run);
        }
    }
}