namespace AdventOfCode.Days._2021._10
{
    public class BoardValue 
    {
        public int Value { get;}
        public (int X, int Y) Position { get; }
        public bool IsMarked { get; private set; }

        public BoardValue(int value, int x, int y)
        {
            Value = value;
            Position = (x, y);
        }

        public void Mark()
        {
            IsMarked = true;
        }
    }
}