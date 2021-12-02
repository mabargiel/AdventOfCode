using AdventOfCode.Days._2019.Intcode.Arguments;

namespace AdventOfCode.Days._2019.Intcode.Operations
{
    public class LessThanOperation : BaseOperation
    {
        private readonly ArgumentMode _arg1;
        private readonly ArgumentMode _arg2;
        private readonly ArgumentMode _arg3;

        public LessThanOperation(Program program, ArgumentMode arg1, ArgumentMode arg2, ArgumentMode arg3) :
            base(program, 4)
        {
            _arg1 = arg1;
            _arg2 = arg2;
            _arg3 = arg3;
        }

        public override void Execute()
        {
            var shouldStoreValue = _arg1.Value < _arg2.Value;

            _arg3.Set(shouldStoreValue ? 1 : 0);
            base.Execute();
        }
    }
}