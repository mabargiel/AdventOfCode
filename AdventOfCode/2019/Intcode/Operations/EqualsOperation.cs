using System.Collections.Generic;

namespace AdventOfCode._2019.Intcode.Operations
{
    public class EqualsOperation : IOperation
    {
        private readonly bool _nounImmediate;
        private readonly bool _verbImmediate;

        public EqualsOperation(in bool nounImmediate, in bool verbImmediate)
        {
            _nounImmediate = nounImmediate;
            _verbImmediate = verbImmediate;
        }

        public void Execute(IList<int> code, ref int position, ref int output)
        {
            var shouldStoreValue = (_nounImmediate ? code[position + 1] : code[code[position + 1]]) == (_verbImmediate ? code[position + 2] : code[code[position + 2]]);

            code[code[position + 3]] = shouldStoreValue ? 1 : 0;

            position += 4;
        }
    }
}