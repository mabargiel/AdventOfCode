using System.Collections.Generic;
using AdventOfCode._2019.Intcode.Operations;

namespace AdventOfCode._2019.Intcode
{
    public class IntcodeComputer
    {
        private readonly IList<int> _code;

        public IntcodeComputer(IList<int> code)
        {
            _code = code;
        }

        public int Run(int input)
        {
            var positionPointer = new PositionPointer();
            var operationFactory = new OperationFactory(input, _code, positionPointer);
            var operation = operationFactory.Create();

            var output = 0;
            while ((OpCode) _code[positionPointer.Position] != OpCode.HaltProgram)
            {
                if (operation == null)
                {
                    break;
                }

                var position = positionPointer.Position;
                operation.Execute(ref position, ref output);
                positionPointer.Position = position;

                if (output == -1)
                {
                    return -1;
                }

                operation = operationFactory.Create();
            }

            return output;
        }
    }
}