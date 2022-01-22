using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweepline_v0
{
    internal class HeapSort
    {
        public static void sort(EventPoint[] arr)
        {
            int n = arr.Count();

            for (int i = n / 2 - 1; i >= 0; i--)
                heapify(arr, n, i);
            for (int i = n - 1; i >= 0; i--)
            {
                EventPoint temp = arr[0];
                arr[0] = arr[i];
                arr[i] = temp;
                heapify(arr, i, 0);
            }
        }
        static void heapify(EventPoint[] arr, int n, int i)
        {
            int largest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;
            if (left < n && arr[left].CompareTo(arr[largest]) > 0)
                largest = left;
            if (right < n && arr[right].CompareTo(arr[largest]) > 0)
                largest = right;
            if (largest != i)
            {
                EventPoint swap = arr[i];
                arr[i] = arr[largest];
                arr[largest] = swap;
                heapify(arr, n, largest);
            }
        }
    }
}
