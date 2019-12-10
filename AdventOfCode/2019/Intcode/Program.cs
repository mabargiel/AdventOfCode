using System.Collections.Generic;

namespace AdventOfCode._2019.Intcode
{
    public class Program
    {
        public IList<int> Code { get; }
        public int Pointer { get; set; }
        public Queue<int> IO { get; } = new Queue<int>();

        public Program(IList<int> code)
        {
            Code = code;
        }

        public Program(IList<int> code, int? input) : this(code)
        {
            if(input.HasValue)
                IO.Enqueue(input.Value);
        }

        public int CurrentInteger()
        {
            return Code[Pointer];
        }
    }
}