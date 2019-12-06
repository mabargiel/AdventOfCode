using System.Collections.Generic;

namespace AdventOfCode._2019.Intcode.Operations
{
    public class OperationFactory
    {
        private readonly IList<int> _code;
        private readonly int _positionPointer;
        private readonly int _input;

        public OperationFactory(in int input, IList<int> code, ref int positionPointer)
        {
            _input = input;
            _code = code;
            _positionPointer = positionPointer;
        }

        public IOperation Create()
        {
            var instruction = _code[_positionPointer];
            var opCode = instruction % 100;
            var nounImmediateModeCode = instruction / 100 % 10;
            var verbImmediateModeCode = instruction / 1000 % 10;

            var nounImmediate = nounImmediateModeCode == 1;
            var verbImmediate = verbImmediateModeCode == 1;

            var arg1 = new Argument(_code, nounImmediate, _positionPointer + 1);
            var arg2 = new Argument(_code, verbImmediate, _positionPointer + 2);
            var arg3 = new Argument(_code, false, _positionPointer + 3);

            return (OpCode) opCode switch
            {
                OpCode.Add => (IOperation) new AddOperation(arg1, arg2, arg3),
                OpCode.Multiply => new MultiplyOperation(arg1, arg2, arg3),
                OpCode.Input => new InputOperation(arg1, _input),
                OpCode.Output => new OutputOperation(arg1),
                OpCode.JumpIfTrue => new JumpIfTrueOperation(arg1, arg2),
                OpCode.JumpIfFalse => new JumpIfFalseOperation(arg1, arg2),
                OpCode.LessThan => new LessThanOperation(arg1, arg2, arg3),
                OpCode.Equals => new EqualsOperation(arg1, arg2, arg3),
                _ => null
            };
        }
    }
}