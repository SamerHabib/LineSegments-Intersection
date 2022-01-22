using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Sweepline_v0
{
    internal class EventPoint : Point, IComparable<EventPoint>
    {
        private EventPointType type;
        private int index;
        public int Index { get { return index; } }
        public EventPointType Type { get { return type; } }
        public EventPoint(Point p, EventPointType e,int i) : base(p.X,p.Y)
        {
            type = e;
            index = i;
        }        
        public int CompareTo(EventPoint? other)
        {
            if (other == null)
                throw new ArgumentNullException("other can not be NULL");

            List<string> properties = new List<string> { "X", "Y", "Type" };
            //List<int> returnValues = new List<int> { 1, -1, 1 };
            foreach (string prop in properties)
            {
                int compareValue = Comparer<object>.Default.Compare(this.GetType().GetProperty(prop).GetValue(this),  other.GetType().GetProperty(prop).GetValue(other));
                if(compareValue != 0)
                    return compareValue ;
            }
            return 1;
        }
    }
    public enum EventPointType
    {
        Insert,
        Delete
    }
}
