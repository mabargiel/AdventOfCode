namespace AdventOfCode._2019.Intcode.Operations
{
    public class JumpIfFalseOperation : BaseOperation
    {
        private readonly Program _program;
        private readonly Argument _arg1;
        private readonly Argument _arg2;

        public JumpIfFalseOperation(Program program, Argument arg1, Argument arg2) : base(program, 3)
        {
            _program = program;
            _arg1 = arg1;
            _arg2 = arg2;
        }

        public override void Execute()
        {
            var shouldJump = _arg1.Value == 0;

            if (!shouldJump)
            {
                base.Execute();
            }
            else
            {
                _program.Pointer = _arg2.Value;
            }
        }
    }
}