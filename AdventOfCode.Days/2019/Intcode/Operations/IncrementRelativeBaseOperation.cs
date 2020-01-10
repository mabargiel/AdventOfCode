using AdventOfCode.Days._2019.Intcode.Arguments;

namespace AdventOfCode.Days._2019.Intcode.Operations
{
    public class IncrementRelativeBaseOperation : BaseOperation
    {
        private readonly ArgumentMode _arg1;
        private readonly Program _program;

        public IncrementRelativeBaseOperation(Program program, ArgumentMode arg1) : base(program, 2)
        {
            _program = program;
            _arg1 = arg1;
        }

        public override void Execute()
        {
            _program.IncrementRelativeBase(_arg1.Value);
            base.Execute();
        }
    }
}