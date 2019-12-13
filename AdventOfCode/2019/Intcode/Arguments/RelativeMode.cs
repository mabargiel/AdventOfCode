namespace AdventOfCode._2019.Intcode.Arguments
{
    public class RelativeMode : ArgumentMode
    {
        private readonly long _relativeBase;

        public RelativeMode(ProgramMemory memory, long relativePosition, long relativeBase) : base(memory, relativePosition)
        {
            _relativeBase = relativeBase;
        }

        public override long Value => Memory[Memory[RelativePosition]  + _relativeBase];

        public override void Set(long value)
        {
            Memory[Memory[RelativePosition] + _relativeBase] = value;
        }
    }
}