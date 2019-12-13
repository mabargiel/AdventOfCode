using AdventOfCode._2019.Intcode.Arguments;

namespace AdventOfCode._2019.Intcode.Operations
{
    public class JumpIfTrueOperation : BaseOperation
    {
        private readonly Program _program;
        private readonly ArgumentMode _arg1;
        private readonly ArgumentMode _arg2;

        public JumpIfTrueOperation(Program program, ArgumentMode arg1, ArgumentMode arg2) : base(program, 3)
        {
            _program = program;
            _arg1 = arg1;
            _arg2 = arg2;
        }

        public override void Execute()
        {
            var shouldJump = _arg1.Value != 0;

            if (!shouldJump)
            {
                base.Execute();
            }
            else
            {
                _program.Pointer = (int) _arg2.Value;
            }
        }
    }
}