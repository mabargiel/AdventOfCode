using AdventOfCode.Days._2019.Intcode.Arguments;

namespace AdventOfCode.Days._2019.Intcode.Operations;

public class InputOperation : BaseOperation
{
    private readonly ArgumentMode _arg1;
    private readonly Program _program;

    public InputOperation(Program program, ArgumentMode arg1) : base(program, 2)
    {
        _program = program;
        _arg1 = arg1;
    }

    public override void Execute()
    {
        _arg1.Set(_program.OnInput());
        base.Execute();
    }
}