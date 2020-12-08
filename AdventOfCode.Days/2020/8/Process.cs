using System.Collections.Generic;

namespace AdventOfCode.Days._2020._8
{
    public class Process
    {
        public Process(List<Instruction> loadedProgram)
        {
            LoadedProgram = loadedProgram;
        }

        public List<Instruction> LoadedProgram { get; }
        private int Accumulator { get; set; }
        private int Position { get; set; }

        public Instruction CurrentInstruction => LoadedProgram[Position];
        public bool RanToCompletion { get; private set; }

        public int ExecuteNext()
        {
            var (move, increase) = CurrentInstruction.Execute();
            Position += move;
            Accumulator += increase;

            if (Position > LoadedProgram.Count - 1)
                RanToCompletion = true;

            return Accumulator;
        }
    }
}