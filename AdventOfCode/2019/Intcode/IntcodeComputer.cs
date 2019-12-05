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
            var operationFactory = new OperationFactory(input);
            var operation = operationFactory.Create(_code[0]);

            var currentPosition = 0;
            var output = 0;
            while ((OpCode) _code[currentPosition] != OpCode.HaltProgram)
            {
                if (operation == null)
                {
                    break;
                }
                
                operation.Execute(_code, ref currentPosition, ref output);

                if (output == -1)
                {
                    return -1;
                }
                
                operation = operationFactory.Create(_code[currentPosition]);
            }

            return output;
        }
    }
}