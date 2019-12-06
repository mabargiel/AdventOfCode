using System.Collections.Generic;

namespace AdventOfCode._2019.Intcode
{
    public class Argument
    {
        private readonly IList<int> _code;
        private readonly bool _immediate;
        private readonly int _position;

        public Argument(IList<int> code, bool immediate, int position)
        {
            _code = code;
            _immediate = immediate;
            _position = position;
        }

        public int Value => _immediate ? _code[_position] : _code[_code[_position]];

        public void Set(int value)
        {
            _code[_code[_position]] = value;
        }
    }
}