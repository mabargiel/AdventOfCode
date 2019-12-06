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
            var positionPointer = 0;
            var operationFactory = new OperationFactory(input, _code, ref positionPointer);
            var operation = operationFactory.Create();

            var output = 0;
            while ((OpCode) _code[positionPointer] != OpCode.HaltProgram)
            {
                if (operation == null)
                {
                    break;
                }

                operation.Execute(ref positionPointer, ref output);

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