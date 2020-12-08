namespace AdventOfCode.Days._2020._8
{
    public abstract class Instruction
    {
        protected Instruction(int argument)
        {
            Argument = argument;
        }

        public int Argument { get; }

        public abstract (int Move, int Increase) Execute();
    }
}