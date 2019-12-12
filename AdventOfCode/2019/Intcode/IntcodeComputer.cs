using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdventOfCode._2019.Intcode.Operations;

namespace AdventOfCode._2019.Intcode
{
    public class IntcodeComputer
    {
        public Program Program { get; }

        public IntcodeComputer(Program program)
        {
            Program = program;
        }

        public long Run()
        {
            var operationFactory = new OperationFactory(Program);
            var operation = operationFactory.Next();

            while (Program.CurrentInteger() != (int) OpCode.HaltProgram)
            {
                operation.Execute();
                operation = operationFactory.Next();
            }

            return Program.CurrentOutput;
        }
    }
}