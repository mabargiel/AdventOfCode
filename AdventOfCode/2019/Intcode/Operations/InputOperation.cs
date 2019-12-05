using System.Collections.Generic;

namespace AdventOfCode._2019.Intcode.Operations
{
    public class InputOperation : IOperation
    {
        private readonly int _input;

        public InputOperation(in int input)
        {
            _input = input;
        }

        public void Execute(IList<int> code, ref int position, ref int output)
        {
            var targetPosition = code[position + 1];

            code[targetPosition] = _input;

            position += 2;
        }
    }
}