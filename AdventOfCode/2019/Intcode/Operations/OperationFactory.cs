using System;

namespace AdventOfCode._2019.Intcode.Operations
{
    public class OperationFactory
    {
        private readonly Program _program;

        public OperationFactory(Program program)
        {
            _program = program;
        }

        public BaseOperation Next()
        {
            var instruction = _program.CurrentInteger();
            var opCode = instruction % 100;
            var nounImmediateModeCode = instruction / 100 % 10;
            var verbImmediateModeCode = instruction / 1000 % 10;

            var nounImmediate = nounImmediateModeCode == 1;
            var verbImmediate = verbImmediateModeCode == 1;

            var arg1 = new Argument(_program.Instructions, nounImmediate, _program.Pointer + 1);
            var arg2 = new Argument(_program.Instructions, verbImmediate, _program.Pointer + 2);
            var arg3 = new Argument(_program.Instructions, false, _program.Pointer + 3);

            return (OpCode) opCode switch
            {
                OpCode.Add => (BaseOperation) new AddOperation(_program, arg1, arg2, arg3),
                OpCode.Multiply => new MultiplyOperation(_program, arg1, arg2, arg3),
                OpCode.Input => new InputOperation(_program, arg1),
                OpCode.Output => new OutputOperation(_program, arg1),
                OpCode.JumpIfTrue => new JumpIfTrueOperation(_program, arg1, arg2),
                OpCode.JumpIfFalse => new JumpIfFalseOperation(_program, arg1, arg2),
                OpCode.LessThan => new LessThanOperation(_program, arg1, arg2, arg3),
                OpCode.Equals => new EqualsOperation(_program, arg1, arg2, arg3),
                OpCode.HaltProgram => null,
                _ => throw new ArgumentOutOfRangeException($"Could not process opcode: {opCode}")
            };
        }
    }
}