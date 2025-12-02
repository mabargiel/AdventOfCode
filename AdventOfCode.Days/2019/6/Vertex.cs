using System;

namespace AdventOfCode.Days._2019._6;

public class Vertex : IComparable<Vertex>
{
    public Vertex(OribitngObject oribitngObject, int cost)
    {
        OribitngObject = oribitngObject;
        Cost = cost;
    }

    public OribitngObject OribitngObject { get; }
    public int Cost { get; set; }

    public int CompareTo(Vertex other)
    {
        return Cost.CompareTo(other.Cost);
    }
}
