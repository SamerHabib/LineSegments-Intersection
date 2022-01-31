using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweepline_v0
{
    internal class DangerousAreas:Dictionary<Point,HashSet<int>>
    {
        public void Add(List<Point> points, LineSegment l1, LineSegment l2)
        {
            foreach (Point point in points)
            {
                if(!this.ContainsKey(point))
                    this.Add(point, new HashSet<int>());
                this[point].Add(l1.Index);
                this[point].Add(l2.Index);
            }
        }
        public int getNumberOfAreas()
        {
            return this.Keys.Count;
        }
    }
}
