using System.Drawing;
using NUnit.Framework;

namespace AdventOfCode.Tests
{
    public class WireSegment
    {
        [Test]
        public void Intersect_TwoIntersectingSegments_ReturnsIntersectPoint()
        {
            var s1 = new Segment(new Point(0, 0), new Point(20, 0));
            var s2 = new Segment(new Point(10, -10), new Point(10, 10));

            var intersectingPoint = s1.GetIntersection(s2);

            Assert.AreEqual(new Point(10, 0), intersectingPoint);
        }

        [Test]
        public void Intersect_TwoCollinearSegments_ReturnsNull()
        {
            var s1 = new Segment(new Point(0, 0), new Point(20, 0));
            var s2 = new Segment(new Point(5, 0), new Point(10, 0));

            var intersectingPoint = s1.GetIntersection(s2);

            Assert.AreEqual(null, intersectingPoint);
        }
    }
}