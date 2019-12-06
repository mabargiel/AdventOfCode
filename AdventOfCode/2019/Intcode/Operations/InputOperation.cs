namespace AdventOfCode._2019.Intcode.Operations
{
    public class InputOperation : IOperation
    {
        private readonly Argument _arg1;
        private readonly int _input;

        public InputOperation(Argument arg1, in int input)
        {
            _arg1 = arg1;
            _input = input;
        }

        public void Execute(ref int position, ref int output)
        {
            _arg1.Set(_input);

            position += 2;
        }
    }
}