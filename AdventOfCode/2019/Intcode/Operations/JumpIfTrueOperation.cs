using System.Collections.Generic;

namespace AdventOfCode._2019.Intcode.Operations
{
    public class JumpIfTrueOperation : IOperation
    {
        private readonly bool _nounImmediate;
        private readonly bool _verbImmediate;

        public JumpIfTrueOperation(in bool nounImmediate, bool verbImmediate)
        {
            _nounImmediate = nounImmediate;
            _verbImmediate = verbImmediate;
        }

        public void Execute(IList<int> code, ref int position, ref int output)
        {
            var shouldJump = (_nounImmediate ? code[position + 1] : code[code[position + 1]]) != 0;

            if (!shouldJump)
                position += 3; 
            else if (_verbImmediate) 
                position = code[position + 2]; 
            else position = code[code[position + 2]];
        }
    }
}