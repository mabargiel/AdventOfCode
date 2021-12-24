namespace AdventOfCode.Days._2019.Intcode.Arguments;

public abstract class ArgumentMode
{
    protected readonly ProgramMemory Memory;
    protected readonly long RelativePosition;

    public ArgumentMode(ProgramMemory memory, long relativePosition)
    {
        Memory = memory;
        RelativePosition = relativePosition;
    }

    public abstract long Value { get; }

    public virtual void Set(long value)
    {
        //always in position mode
        Memory[Memory[RelativePosition]] = value;
    }
}