using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Combinatorics.Collections;

namespace AdventOfCode._2019._7
{
    public class Day7 : IAdventDay<long, long>
    {
        private readonly long[] _code;
        private readonly int _input;

        public Day7(long[] code, int input)
        {
            _code = code;
            _input = input;
        }

        public long Part1()
        {
            Task<long> GetOutput(IEnumerable<int> phases)
            {
                var pipe = new AmplifiersPipe(_code, phases.ToArray(), _input);
                return pipe.ExecuteAsync();
            }

            return new Permutations<int>(Enumerable.Range(0, 5).ToArray()).Select(x => GetOutput(x).Result).Max();
        }

        public long Part2()
        {
            async Task<long> GetOutput(IEnumerable<int> phases)
            {
                var pipe = new AmplifiersPipe(_code, phases.ToArray(), _input);
                return await pipe.ExecuteAsync();
            }

            var permutations = new Permutations<int>(Enumerable.Range(5, 5).ToArray());
            var result = permutations.Select(x => GetOutput(x).Result).ToArray();
            return result.Any() ? result.Max() : -1;
        }
    }
}