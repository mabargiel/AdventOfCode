using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace AdventOfCode._2019.Intcode
{
    public class Program : ICloneable
    {
        public IList<long> Instructions { get; }
        public int Pointer { get; set; }
        public BlockingCollection<long> IO { get; } = new BlockingCollection<long>();
        public Queue<long> Output { get; } = new Queue<long>();

        public Program(IList<long> instructions)
        {
            Instructions = instructions;
        }

        public Program(IList<long> instructions, long? input) : this(instructions)
        {
            if(input.HasValue)
                IO.Add(input.Value);
        }

        public long CurrentInteger()
        {
            return Instructions[Pointer];
        }

        public object Clone()
        {
            return new Program(new List<long>(Instructions));
        }
    }
}