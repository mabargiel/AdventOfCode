namespace AdventOfCode._2019.Intcode.Operations
{
    public class AddOperation : BaseOperation
    {
        private readonly Argument _arg1;
        private readonly Argument _arg2;
        private readonly Argument _arg3;

        public AddOperation(Program program, Argument arg1, Argument arg2, Argument arg3) : base(program, 4)
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