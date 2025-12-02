using System;
using System.Collections.Generic;

namespace AdventOfCode.Days._2020._7;

public class Bag : IEquatable<Bag>
{
    public Bag(string shade, string color, int qty, List<Bag> bags = null)
    {
        Shade = shade;
        Color = color;
        Qty = qty;
        Bags = bags ?? new List<Bag>();
    }

    public string Shade { get; }
    public string Color { get; }
    public int Qty { get; }
    public List<Bag> Bags { get; }

    public bool Equals(Bag other)
    {
        if (ReferenceEquals(null, other))
        {
            return false;
        }

        if (ReferenceEquals(this, other))
        {
            return true;
        }

        return Shade == other.Shade && Color == other.Color;
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj))
        {
            return false;
        }

        if (ReferenceEquals(this, obj))
        {
            return true;
        }

        return obj.GetType() == GetType() && Equals((Bag)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Shade, Color);
    }
}
