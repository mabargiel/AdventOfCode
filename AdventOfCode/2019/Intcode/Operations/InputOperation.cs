namespace AdventOfCode._2019.Intcode.Operations
{
    public class InputOperation : BaseOperation
    {
        private readonly Program _program;
        private readonly Argument _arg1;

        public InputOperation(Program program, Argument arg1) : base(program, 2)
        {
            _program = program;
            _arg1 = arg1;
        }

        public override void Execute()
        {
            _arg1.Set(_program.IO.Take());
            base.Execute();
        }
    }
}