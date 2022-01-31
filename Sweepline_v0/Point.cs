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
        private int z;
        public int X { get { return x; } }
        public int Y { get { return y; } }
        public int Z { get { return z; } }

        public Point(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public int CompareTo(Point? other)
        {
            if (other == null)
                throw new ArgumentNullException("other can not be NULL");
            if (x.CompareTo(other.x) < 0)
                return 1;
            if (y.CompareTo(other.y) < 0)
                return 1;
            if (y.CompareTo(other.z) < 0)
                return 1;
            return 0;
        }
        public override bool Equals(Object obj)
        {
            Point key = obj as Point;

            if (key == null)
                return false;

            return X.Equals(key.X) &&
                   Y.Equals(key.Y) && z.Equals(key.z);
        }
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hash = (int)2166136261;
                // Suitable nullity checks etc, of course :)
                hash = hash * 16777619 ^ X.GetHashCode();
                hash = hash * 16777619 ^ Y.GetHashCode();
                hash = hash * 16777619 ^ Z.GetHashCode();
                return hash;
            }
        }
    }
}
