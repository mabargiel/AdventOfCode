using System;

namespace AdventOfCode._2019._6
{
    public class Vertex : IComparable<Vertex>
    {
        public OribitngObject OribitngObject { get; }
        public int Cost { get; set; }

        public Vertex(OribitngObject oribitngObject, int cost)
        {
            OribitngObject = oribitngObject;
            Cost = cost;
        }

        public int CompareTo(Vertex other)
        {
            return Cost.CompareTo(other.Cost);
        }
    }
}