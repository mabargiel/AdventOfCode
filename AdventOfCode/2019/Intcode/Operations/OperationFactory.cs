namespace AdventOfCode._2019.Intcode.Operations
{
    public class OperationFactory
    {
        private readonly int _input;

        public OperationFactory(in int input)
        {
            _input = input;
        }

        public IOperation Create(in int instruction)
        {
            var opCode = instruction % 100;
            var nounImmediateModeCode = instruction / 100 % 10; 
            var verbImmediateModeCode = instruction / 1000 % 10;

            var nounImmediate = nounImmediateModeCode == 1;
            var verbImmediate = verbImmediateModeCode == 1;

            return (OpCode) opCode switch
            {
                OpCode.Add => (IOperation) new AddOperation(nounImmediate, verbImmediate),
                OpCode.Multiply => new MultiplyOperation(nounImmediate, verbImmediate),
                OpCode.Input => new InputOperation(_input),
                OpCode.Output => new OutputOperation(nounImmediate),
                OpCode.JumpIfTrue => new JumpIfTrueOperation(nounImmediate, verbImmediate),
                OpCode.JumpIfFalse => new JumpIfFalseOperation(nounImmediate, verbImmediate),
                OpCode.LessThan => new LessThanOperation(nounImmediate, verbImmediate),
                OpCode.Equals => new EqualsOperation(nounImmediate, verbImmediate),
                _ => null
            };
        }
    }
}