using System;

namespace AdventOfCode.Days._2019._12;

public struct Point3 : ICloneable
{
    public int X { get; }
    public int Y { get; }
    public int Z { get; }

    public Point3(int x, int y, int z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    public object Clone()
    {
        return new Point3(X, Y, Z);
    }
}
