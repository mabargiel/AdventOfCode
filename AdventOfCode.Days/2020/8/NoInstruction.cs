namespace AdventOfCode.Days._2020._8
{
    public class NoInstruction : Instruction
    {
        public NoInstruction(int argument)
            : base(argument)
        {
        }

        public override (int Move, int Increase) Execute()
        {
            return (1, 0);
        }
    }
}