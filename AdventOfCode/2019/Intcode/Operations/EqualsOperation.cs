namespace AdventOfCode._2019.Intcode.Operations
{
    public class EqualsOperation : IOperation
    {
        private readonly Argument _arg1;
        private readonly Argument _arg2;
        private readonly Argument _arg3;

        public EqualsOperation(Argument arg1, Argument arg2, Argument arg3)
        {
            _arg1 = arg1;
            _arg2 = arg2;
            _arg3 = arg3;
        }

        public void Execute(ref int position, ref int output)
        {
            var shouldStoreValue = _arg1.Value == _arg2.Value;

            _arg3.Set(shouldStoreValue ? 1 : 0);

            position += 4;
        }
    }
}