namespace AdventOfCode.Days._2021.Day4;

public class BoardValue
{
    public BoardValue(int value, int x, int y)
    {
        Value = value;
        Position = (x, y);
    }

    public int Value { get; }
    public (int X, int Y) Position { get; }
    public bool IsMarked { get; private set; }

    public void Mark()
    {
        IsMarked = true;
    }
}
