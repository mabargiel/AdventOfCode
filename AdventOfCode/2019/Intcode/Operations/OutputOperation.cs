using System.Collections.Generic;

namespace AdventOfCode._2019.Intcode.Operations
{
    public class OutputOperation : IOperation
    {
        private readonly bool _nounImmediate;

        public OutputOperation(bool nounImmediate)
        {
            _nounImmediate = nounImmediate;
        }
        
        public void Execute(IList<int> code, ref int position, ref int output)
        {
            output = _nounImmediate ? code[position + 1] : code[code[position + 1]];
            position += 2;
        }
    }
}