using System.Drawing;
using System;
using System.Runtime.CompilerServices;

namespace SAPR.Classes
{
    public static class ExtensionMethods
    {
        public static Point AddByPoint(this Point srcPoint, Point point)
        {
            return new Point(srcPoint.X + point.X, srcPoint.Y + point.Y);
        }
        public static Point SubByPoint(this Point srcPoint, Point point)
        {
            return new Point(srcPoint.X - point.X, srcPoint.Y - point.Y);
        }
        public static Point DivByNumber(this Point srcPoint, int devider)
        {
            return new Point(srcPoint.X / devider, srcPoint.Y / devider);
        }
        public static float GetLength(this Point point)
        {
            return (float)Math.Sqrt(point.X * point.X + point.Y * point.Y);
        }
        public static int Dot(this Point point1, Point point2)
        {
            return point1.X * point2.X + point1.Y * point2.Y;
        }
        public static float GetLength(this PointF point)
        {
            if (point.X < 0)
                point.X = Math.Abs(point.X);
            if (point.Y < 0)
                point.Y = Math.Abs(point.Y);

            return (float)Math.Sqrt(point.X * point.X + point.Y * point.Y);
        }
        public static float Dot(this PointF point1, PointF point2)
        {
            float temp = point1.X * point2.X + point1.Y * point2.Y;
            if (temp > 1f)
                temp = 1f;

            return temp;
        }
        public static PointF Normalize(this PointF point)
        {
            float length = point.GetLength();
            point.X /= length;
            point.Y /= length;

            return point;
        }
        public static PointF AddByPoint(this PointF srcPoint, PointF point)
        {
            return new PointF(srcPoint.X + point.X, srcPoint.Y + point.Y);
        }
        public static PointF SubByPoint(this PointF srcPoint, PointF point)
        {
            return new PointF(srcPoint.X - point.X, srcPoint.Y - point.Y);
        }
        public static Point MaxPoint(Point point1, Point point2)
        {
            return new Point(point1.X > point2.X ? point1.X : point2.X,
                point1.Y > point2.Y ? point1.Y : point2.Y);
        }
        public static Point MinPoint(Point point1, Point point2)
        {
            return new Point(point1.X < point2.X ? point1.X : point2.X,
                point1.Y < point2.Y ? point1.Y : point2.Y);
        }
        public static Point MaxPoint(Point[] points)
        {
            Point temp = new Point(int.MinValue, int.MinValue);
            foreach (Point point in points)
            {
                if (point.X > temp.X)
                    temp.X = point.X;
                if (point.Y > temp.Y)
                    temp.Y = point.Y;
            }

            return temp;
        }
        public static Point MinPoint(Point[] points)
        {
            Point temp = new Point(int.MaxValue, int.MaxValue);
            foreach (Point point in points)
            {
                if (point.X < temp.X)
                    temp.X = point.X;
                if (point.Y < temp.Y)
                    temp.Y = point.Y;
            }

            return temp;
        }
    }
}
