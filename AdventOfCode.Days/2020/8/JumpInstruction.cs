namespace AdventOfCode.Days._2020._8
{
    public class JumpInstruction : Instruction
    {
        public JumpInstruction(int argument) : base(argument)
        {
        }

        public override (int Move, int Increase) Execute()
        {
            return (Argument, 0);
        }
    }
}