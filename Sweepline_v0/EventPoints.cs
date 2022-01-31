using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweepline_v0
{
    internal class EventPoints
    {
        private EventPoint[] points;
        public EventPoints(int countLineSegments)
        {
            points = new EventPoint[countLineSegments*2];
        }
        public void Add(int index, EventPoint ep)
        {
            points[index] = ep;
        }
        public EventPoint getbyIndex(int index)
        {
            return points[index];
        }
        public void HeapSort()
        {

        }
    }
}
