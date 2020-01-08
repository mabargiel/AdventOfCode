using System;
using AdventOfCode._2019.Intcode.Arguments;

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
            var arg1Mode = instruction / 100 % 10;
            var arg2Mode = instruction / 1000 % 10;
            var arg3Mode = instruction / 10000 % 10;

            var arg1 = GetArgumentMode((ArgModes) arg1Mode, _program.Pointer + 1);
            var arg2 = GetArgumentMode((ArgModes) arg2Mode, _program.Pointer + 2);
            var arg3 = GetArgumentMode((ArgModes) arg3Mode, _program.Pointer + 3);

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
                OpCode.IncrementRelativeBase => new IncrementRelativeBaseOperation(_program, arg1),
                OpCode.HaltProgram => null,
                _ => throw new ArgumentOutOfRangeException($"Could not process opcode: {opCode}")
            };
        }

        private ArgumentMode GetArgumentMode(ArgModes argMode, int relativePosition)
        {
            return argMode switch
            {
                ArgModes.Position => (ArgumentMode) new PositionMode(_program.Memory, relativePosition),
                ArgModes.Immediate => new ImmediateMode(_program.Memory, relativePosition),
                ArgModes.Relative => new RelativeMode(_program.Memory, relativePosition, _program.RelativeBase),
                _ => throw new ArgumentOutOfRangeException(nameof(argMode), argMode, null)
            };
        }
    }
}