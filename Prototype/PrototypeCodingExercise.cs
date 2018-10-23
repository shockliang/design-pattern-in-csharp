using System;

namespace Prototype
{
    public class Point
    {
        public int X, Y;
    }

    public class Line
    {
        public Point Start, End;

        public Line DeepCopy()
        {
            var start = new Point() { X = Start.X, Y = Start.Y };
            var end = new Point() { X = End.X, Y = End.Y };
            return new Line() { Start = start, End = end };
        }
    }
}