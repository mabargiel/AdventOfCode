namespace AdventOfCode._2019.Intcode.Operations
{
    public abstract class BaseOperation
    {
        private readonly Program _program;
        private readonly int _length;

        protected BaseOperation(Program program, int length)
        {
            _program = program;
            _length = length;
        }

        public virtual void Execute()
        {
            _program.Pointer += _length;
        }
    }
}