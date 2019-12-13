namespace AdventOfCode._2019.Intcode.Arguments
{
    public class ImmediateMode : ArgumentMode
    {
        public ImmediateMode(ProgramMemory memory, long relativePosition) 
            : base(memory, relativePosition)
        {
        }

        public override long Value => Memory[RelativePosition];
    }
}