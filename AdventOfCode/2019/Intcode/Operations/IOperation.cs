using System.Collections.Generic;

namespace AdventOfCode._2019.Intcode.Operations
{
    public interface IOperation
    {
        void Execute(IList<int> code, ref int position, ref int output);
    }
}