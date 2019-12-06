namespace AdventOfCode._2019.Intcode.Operations
{
    public interface IOperation
    {
        void Execute(ref int position, ref int output);
    }
}