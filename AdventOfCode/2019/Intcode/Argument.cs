using System.Collections.Generic;

namespace AdventOfCode._2019.Intcode
{
    public class Argument
    {
        private readonly IList<long> _code;
        private readonly bool _immediate;
        private readonly int _position;

        public Argument(IList<long> code, bool immediate, int position)
        {
            _code = code;
            _immediate = immediate;
            _position = position;
        }

        public long Value => _immediate ? _code[_position] : _code[(int) _code[_position]];

        public void Set(long value)
        {
            _code[(int) _code[_position]] = value;
        }
    }
}