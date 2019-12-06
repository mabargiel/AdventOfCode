namespace AdventOfCode._2019.Intcode.Operations
{
    public class OutputOperation : IOperation
    {
        private readonly Argument _arg1;

        public OutputOperation(Argument arg1)
        {
            _arg1 = arg1;
        }

        public void Execute(ref int position, ref int output)
        {
            output = _arg1.Value;
            position += 2;
        }
    }
}