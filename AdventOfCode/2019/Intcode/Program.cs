using System.Collections.Generic;

namespace AdventOfCode._2019.Intcode
{
    public class Program
    {
        private readonly IList<int> _code;
        public IList<int> Runtime { get; private set; }
        public int Pointer { get; set; }
        public Queue<int> IO { get; } = new Queue<int>();

        public Program(IList<int> code)
        {
            Runtime = code;
            _code = code;
        }

        public Program(IList<int> code, int? input) : this(code)
        {
            if(input.HasValue)
                IO.Enqueue(input.Value);
        }

        public int CurrentInteger()
        {
            return Runtime[Pointer];
        }

        public void ResetInstructions()
        {
            Runtime = _code;
            Pointer = 0;
        }
    }
}