using System;
using System.Threading.Tasks;

namespace AdventOfCode.Days._2019.Intcode
{
    public interface IIntcodeComputer
    {
        Program Program { get; }
        Task StartAsync();
        event Action<long> OnOutput;
        public void Input(in long value);
    }
}