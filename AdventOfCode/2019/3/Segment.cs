using System;
using System.Drawing;

namespace AdventOfCode._2019._3
{
    public class Segment
    {
        public Segment(Point start, Point end)
        {
            Start = start;
            End = end;
        }

        public Point Start { get; }
        public Point End { get; }

        public Point? GetIntersection(Segment segment)
        {
            if (Equals(segment) || Start.Equals(segment.End) || End.Equals(segment.Start) || Start.Equals(segment.Start) || End.Equals(segment.End))
            {
                return null;
            }

            return Intersects(this, segment);
        }

        public override string ToString()
        {
            return $"{Start.ToString()} -> {End.ToString()}";
        }

        private static Point? Intersects(Segment ab, Segment cd)
        {
            var dx1 = ab.End.X - ab.Start.X;
            var dx2 = cd.End.X - cd.Start.X;
            var dy1 = ab.End.Y - ab.Start.Y;
            var dy2 = cd.End.Y - cd.Start.Y;
            var denom = dy2 * dx1 - dx2 * dy1;

            if (denom == 0)
            {
                return null;
            }

            var ua = (dx2 * (ab.Start.Y - cd.Start.Y) - dy2 * (ab.Start.X - cd.Start.X)) / (double) denom;
            var ub = (dx1 * (ab.Start.Y - cd.Start.Y) - dy1 * (ab.Start.X - cd.Start.X)) / (double) denom;

            if (ua < 0 || ua > 1 || ub < 0 || ub > 1)
            {
                return null;
            }

            var ix = ab.Start.X + ua * (ab.End.X - ab.Start.X);
            var iy = ab.Start.Y + ua * (ab.End.Y - ab.Start.Y);

            return new Point((int) Math.Round(ix), (int) Math.Round(iy));
        }
    }
}