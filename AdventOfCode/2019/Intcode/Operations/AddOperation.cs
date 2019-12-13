using AdventOfCode._2019.Intcode.Arguments;

namespace AdventOfCode._2019.Intcode.Operations
{
    public class AddOperation : BaseOperation
    {
        private readonly ArgumentMode _arg1;
        private readonly ArgumentMode _arg2;
        private readonly ArgumentMode _arg3;

        public AddOperation(Program program, ArgumentMode arg1, ArgumentMode arg2, ArgumentMode arg3) : base(program, 4)
        {
            _arg1 = arg1;
            _arg2 = arg2;
            _arg3 = arg3;
        }

        public override void Execute()
        {
            _arg3.Set(_arg1.Value + _arg2.Value);
            base.Execute();
        }
    }
}