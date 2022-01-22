using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweepline_v0
{
    internal class Intersection
    {
        public static List<Point> IsIntersect(LineSegment l1, LineSegment l2)
        {
            List<Point> points = new List<Point>();
            if (l1.Type == l2.Type)
            {
                if(l1.Type == LineType.Horizontal)
                {
                    points = H2HIntersection(l1, l2);
                }
                else
                {
                    points = V2VIntersection(l1, l2);
                }
            }
            else
            {
                Point p = null;
                if (l1.Type == LineType.Horizontal)
                {
                    p = H2VIntersection(l1, l2);
                }
                else
                {
                    p = H2VIntersection(l2, l1);
                }
                if (p != null)
                    points.Add(p);
            }
            return points;
        }
        private static Point H2VIntersection(LineSegment horiontalLine, LineSegment VerticalLine)
        {
            if(horiontalLine.StartPoint.Y <= VerticalLine.EndPoint.Y && horiontalLine.StartPoint.Y >= VerticalLine.StartPoint.Y)
            {
                if(VerticalLine.StartPoint.X <= horiontalLine.EndPoint.X && VerticalLine.StartPoint.X >= horiontalLine.StartPoint.X)
                {
                    return new Point(VerticalLine.StartPoint.X, horiontalLine.StartPoint.Y);
                }
            }
            return null;
        }
        private static List<Point> H2HIntersection(LineSegment horiontalLine1, LineSegment horiontalLine2)
        {
            List<Point> points = new List<Point>();
            int minX = Math.Max(horiontalLine1.StartPoint.X, horiontalLine2.StartPoint.X);
            int maxX = Math.Min(horiontalLine1.EndPoint.X, horiontalLine2.EndPoint.X);
            int y = horiontalLine1.StartPoint.Y;
            for (int x = minX; x <= maxX; x++)
                points.Add(new Point(x, y));
            return points;
        }

        private static List<Point> V2VIntersection(LineSegment VerticalLine1, LineSegment VerticalLine2)
        {
            List<Point> points = new List<Point>();
            int minY = Math.Max(VerticalLine1.StartPoint.Y, VerticalLine2.StartPoint.Y);
            int maxY = Math.Min(VerticalLine1.EndPoint.Y, VerticalLine2.EndPoint.Y);
            int x = VerticalLine1.StartPoint.X;
            for (int y = minY; y <= maxY; y++)
                points.Add(new Point(x, y));
            return points;
        }
    }
}
