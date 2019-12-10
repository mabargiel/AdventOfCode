using System.Collections.Generic;
using System.Linq;
using AdventOfCode._2019.Intcode.Operations;

namespace AdventOfCode._2019.Intcode
{
    public class IntcodeComputer
    {
        private readonly Program _program;

        public IntcodeComputer(Program program)
        {
            _program = program;
        }

        public int? Run()
        {
            var operationFactory = new OperationFactory(_program);
            var operation = operationFactory.Create();

            while ((OpCode) _program.CurrentInteger() != OpCode.HaltProgram)
            {
                operation.Execute();
                operation = operationFactory.Create();
            }

            return _program.IO.Any() ? (int?) _program.IO.Dequeue() : null;
        }
    }
}