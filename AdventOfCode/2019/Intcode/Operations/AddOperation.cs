namespace AdventOfCode._2019.Intcode.Operations
{
    public class AddOperation : IOperation
    {
        private readonly Argument _arg1;
        private readonly Argument _arg2;
        private readonly Argument _arg3;

        public AddOperation(Argument arg1, Argument arg2, Argument arg3)
        {
            _arg1 = arg1;
            _arg2 = arg2;
            _arg3 = arg3;
        }

        public void Execute(ref int position, ref int output)
        {
            _arg3.Set(_arg1.Value + _arg2.Value);

            position += 4;
        }
    }
}