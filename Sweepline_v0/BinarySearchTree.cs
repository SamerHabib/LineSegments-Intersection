using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweepline_v0
{
    internal class BinarySearchTree: SortedDictionary<int, EventPoint>
    {
        public void Add(int index, EventPoint e)
        {
            base.Add(e.Index, e);
        }
        public void Delete(int index)
        {
            base.Remove(index);
        }
    }
}
