namespace AdventOfCode.Days._2019.Intcode.Arguments
{
    public class PositionMode : ArgumentMode
    {
        public PositionMode(ProgramMemory memory, long relativePosition) : base(memory, relativePosition)
        {
        }

        public override long Value => Memory[Memory[RelativePosition]];
    }
}