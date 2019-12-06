namespace AdventOfCode._2019.Intcode.Operations
{
    public class JumpIfTrueOperation : IOperation
    {
        private readonly Argument _arg1;
        private readonly Argument _arg2;

        public JumpIfTrueOperation(Argument arg1, Argument arg2)
        {
            _arg1 = arg1;
            _arg2 = arg2;
        }

        public void Execute(ref int position, ref int output)
        {
            var shouldJump = _arg1.Value != 0;

            if (!shouldJump)
            {
                position += 3;
            }
            else
            {
                position = _arg2.Value;
            }
        }
    }
}