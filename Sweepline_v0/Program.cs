// See https://aka.ms/new-console-template for more information
using Sweepline_v0;

Console.WriteLine("Hello, World!");
//[12:43] Marco Kiltz
//    0,9,1 -> 5,9,1
//8,0,2 -> 0,8,2
//9,4,1 -> 3,4,1
//2,2,3 -> 2,1,3
//7,0,2 -> 7,4,2
//6,4,1 -> 2,0,1
//0,9,1 -> 2,9,1
//3,4,2 -> 1,4,2
//0,0,2 -> 8,8,2
//5,5,1 -> 8,2,1

Point p1 = new Point(0, 9, 1);
Point p2 = new Point(5, 9, 1);

//Point p3 = new Point(8, 0);
//Point p4 = new Point(0, 8);

Point p5 = new Point(9, 4, 1);
Point p6 = new Point(3, 4, 1);

Point p7 = new Point(2, 2, 3);
Point p8 = new Point(2, 1, 3);

Point p9 = new Point(3, 0, 2);
Point p10 = new Point(3, 4, 2);

//Point p11 = new Point(6, 4);
//Point p12 = new Point(2, 0);

Point p13 = new Point(0, 9, 1);
Point p14 = new Point(2, 9, 1);

Point p15 = new Point(3, 4, 2);
Point p16 = new Point(1, 4, 2);

//Point p17 = new Point(0, 0);
//Point p18 = new Point(8, 8);

//Point p19 = new Point(5, 5);
//Point p20 = new Point(8, 2);



LineSegment l1 = new LineSegment(p1, p2, 0);

//LineSegment l2 = new LineSegment(p3, p4, 1);
LineSegment l3 = new LineSegment(p5, p6, 1);
LineSegment l4 = new LineSegment(p7, p8, 2);
LineSegment l5 = new LineSegment(p9, p10, 3);
//LineSegment l6 = new LineSegment(p11, p12, 5);
LineSegment l7 = new LineSegment(p13, p14, 4);
LineSegment l8 = new LineSegment(p15, p16, 5);
//LineSegment l9 = new LineSegment(p17, p18, 8);
//LineSegment l10 = new LineSegment(p19, p20, 9);

SortedDictionary<int, LineSegment> lineSegments = new SortedDictionary<int, LineSegment>();
lineSegments.Add(l1.Index, l1);
lineSegments.Add(l3.Index, l3);
lineSegments.Add(l4.Index, l4);
lineSegments.Add(l5.Index, l5);
lineSegments.Add(l7.Index, l7);
lineSegments.Add(l8.Index, l8);

//List<LineSegment> lineSegments = new List<LineSegment>() { l1, l3, l4, l5, l7, l8};

EventPoint[] arr = new EventPoint[lineSegments.Count()*2];
for(int i=0; i< lineSegments.Count(); i++)
{
    arr[i*2] = lineSegments[i].StartPoint;
    arr[(i*2)+1] = lineSegments[i].EndPoint;
}
HeapSort.sort(arr);

BinarySearchTree map = new BinarySearchTree();

DangerousAreas dangerousArea = new DangerousAreas();





for (int i = 0; i < arr.Count(); i++)
{
    EventPoint e = arr[i];
    Console.WriteLine("(" +e.X+", "+e.Y+", "+e.Type.ToString()+ ", " + e.Index+")");
    if (e.Type == EventPointType.Insert)
    {
        if(map.Count>0)
        {
            LineSegment ls1 = lineSegments[e.Index];
            foreach (KeyValuePair<int, EventPoint> kv in map)
            {
                LineSegment ls2 = lineSegments[kv.Key];
                if(ls1.StartPoint.Z == ls2.StartPoint.Z)
                {
                    List<Point> intersectionPoints = Intersection.IsIntersect(ls1, ls2);
                    dangerousArea.Add(intersectionPoints, ls1, ls2);
                }
            }
        }

        map.Add(e.Index, e);
    }
    else
    {
        map.Remove(e.Index);
    }
}
int nnn = 0;

