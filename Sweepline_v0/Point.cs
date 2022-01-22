using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweepline_v0
{
    internal class Point:IComparable<Point>
    {
        private int x;
        private int y;
        public int X { get { return x; } }
        public int Y { get { return y; } }

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int CompareTo(Point? other)
        {
            if (other == null)
                throw new ArgumentNullException("other can not be NULL");
            if (x.CompareTo(other.x) < 0)
                return 1;
            if (y.CompareTo(other.y) < 0)
                return 1;
            return 0;
        }
    }
}
