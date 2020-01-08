using System.Threading.Tasks;

namespace AdventOfCode._2019.Intcode
{
    public interface IIntcodeComputer
    {
        Program Program { get; }
        long[] Run();
        void Input(long value);
        Task RunAsync();
    }
}