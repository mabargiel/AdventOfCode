using System.Collections.Generic;

namespace AdventOfCode._2019.Intcode.Operations
{
    public class MultiplyOperation : IOperation
    {
        private readonly bool _nounImmediateMode;
        private readonly bool _verbImmediateMode;

        public MultiplyOperation(bool nounImmediateMode, bool verbImmediateMode)
        {
            _nounImmediateMode = nounImmediateMode;
            _verbImmediateMode = verbImmediateMode;
        }

        public void Execute(IList<int> code, ref int position, ref int output)
        {
            var nounPos = code[position + 1];
            var verbPos = code[position + 2];
            var targetPos = code[position + 3];

            var noun = _nounImmediateMode ? nounPos : code[nounPos];
            var verb = _verbImmediateMode ? verbPos : code[verbPos];
            code[targetPos] = noun * verb;

            position += 4;
        }
    }
}