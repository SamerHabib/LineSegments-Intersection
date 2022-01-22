﻿// See https://aka.ms/new-console-template for more information
using Sweepline_v0;

Console.WriteLine("Hello, World!");
Point p1 = new Point(0, 9);
Point p2 = new Point(5, 9);

//Point p3 = new Point(8, 0);
//Point p4 = new Point(0, 8);

Point p5 = new Point(9, 4);
Point p6 = new Point(3, 4);

Point p7 = new Point(2, 2);
Point p8 = new Point(2, 1);

Point p9 = new Point(7, 0);
Point p10 = new Point(7, 4);

//Point p11 = new Point(6, 4);
//Point p12 = new Point(2, 0);

Point p13 = new Point(0, 9);
Point p14 = new Point(2, 9);

Point p15 = new Point(3, 4);
Point p16 = new Point(1, 4);

//Point p17 = new Point(0, 0);
//Point p18 = new Point(8, 8);

//Point p19 = new Point(5, 5);
//Point p20 = new Point(8, 2);


LineSegment l1 = new LineSegment(p1, p2,0);
//LineSegment l2 = new LineSegment(p3, p4, 1);
LineSegment l3 = new LineSegment(p5, p6, 2);
LineSegment l4 = new LineSegment(p7, p8, 3);
LineSegment l5 = new LineSegment(p9, p10, 4);
//LineSegment l6 = new LineSegment(p11, p12, 5);
LineSegment l7 = new LineSegment(p13, p14, 6);
LineSegment l8 = new LineSegment(p15, p16, 7);
//LineSegment l9 = new LineSegment(p17, p18, 8);
//LineSegment l10 = new LineSegment(p19, p20, 9);

List<LineSegment> lineSegments = new List<LineSegment>() { l1, l3, l4, l5, l7, l8};

EventPoint[] arr = new EventPoint[lineSegments.Count()*2];
for(int i=0; i<arr.Count()-1; i += 2)
{
    arr[i] = lineSegments[Convert.ToInt32(i / 2)].StartPoint;
    arr[i+1] = lineSegments[Convert.ToInt32(i / 2)].EndPoint;
}
HeapSort.sort(arr);

AVL bTree = new AVL();

List<EventPoint> list = new List<EventPoint>();
List<Point> intersectionPoints = new List<Point>();
for(int i = 0; i < arr.Count(); i++)
{
    EventPoint e = arr[i];
    if(e.Type == EventPointType.Insert)
    {
        if(list.Count()>0)
        {
            LineSegment ls1 = lineSegments.Where(l => l.Index == e.Index).ToList().First();
            foreach (EventPoint ep in list)
            {
                LineSegment ls2 = lineSegments.Where(l => l.Index == ep.Index).ToList().First();
                intersectionPoints.AddRange(Intersection.IsIntersect(ls1, ls2));
            }
        }

        list.Add(e);
    }
    else
    {
        list.Remove(list.Where(ep => ep.Index == e.Index).ToList().First());
    }
}
int nnn = 0;

