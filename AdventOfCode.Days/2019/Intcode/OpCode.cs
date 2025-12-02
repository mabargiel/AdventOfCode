namespace AdventOfCode.Days._2019.Intcode;

public enum OpCode
{
    Add = 1,
    Multiply,
    Input,
    Output,
    JumpIfTrue,
    JumpIfFalse,
    LessThan,
    Equals,
    IncrementRelativeBase,
    HaltProgram = 99,
}
