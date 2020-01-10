using AdventOfCode._2019.Intcode.Arguments;

namespace AdventOfCode._2019.Intcode.Operations
{
    public class OutputOperation : BaseOperation
    {
        private readonly Program _program;
        private readonly ArgumentMode _arg1;

        public OutputOperation(Program program, ArgumentMode arg1) : base(program, 2)
        {
            _program = program;
            _arg1 = arg1;
        }

        public override void Execute()
        {
            _program.OnOutput?.Invoke(_arg1.Value);
            base.Execute();
        }
    }
}