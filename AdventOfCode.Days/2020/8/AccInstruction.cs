namespace AdventOfCode.Days._2020._8;

public class AccInstruction : Instruction
{
    public AccInstruction(int argument)
        : base(argument) { }

    public override (int Move, int Increase) Execute()
    {
        return (1, Argument);
    }
}
