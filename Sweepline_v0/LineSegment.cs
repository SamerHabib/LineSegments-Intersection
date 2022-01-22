using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweepline_v0
{
    internal class LineSegment
    {
        private EventPoint startPoint, endPoint;
        private int index;
        private LineType type;
        public int Index { get { return index; } }
        public LineType Type { get { return type; } }
        public EventPoint StartPoint { get { return startPoint; } }
        public EventPoint EndPoint { get { return endPoint; } }
        public LineSegment(Point p, Point q,int i)
        {
            index = i;
            type = (p.X == q.X) ? LineType.Vertical : LineType.Horizontal;
            if (p.CompareTo(q) > 0)
            {
                startPoint = new EventPoint(p, EventPointType.Insert, index);
                endPoint = new EventPoint(q, EventPointType.Delete, index);
            }
            else
            {
                startPoint = new EventPoint(q, EventPointType.Insert, index);
                endPoint = new EventPoint(p, EventPointType.Delete, index);
            }
        }
    }
    public enum LineType
    {
        Horizontal,
        Vertical
    }
}
