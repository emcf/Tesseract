using System;
using System.Drawing;
using System.Windows.Forms;

namespace Tesseract
{
    class Transformations2D
    {
        public static Point Translate2DPoint(Point p, Point t)
        {
            // Move point P to point T's location
            return new Point()
            {
                X = p.X + t.X,
                Y = p.Y + t.Y
            };
        }

        public static Point Scale2DPoint(Point p, int f)
        {
            // Self explanitory
            return new Point()
            {
                X = p.X * f,
                Y = p.Y * f
            };
        }

        public static Point Rotate2DPoint(Point point, float rotation)
        {
            // Convert the rotation to radians
            rotation = rotation / 180f;

            // Algorithm from https://upload.wikimedia.org/math/7/5/2/752fd6396a9c9d026f10eccb39ddca15.png

            int PointX = point.X;
            int PointY = point.Y;

            // Multiply by 10 for a smoother rotation feeling

            point.X = (int)(PointX * cos(rotation) * 10 - PointY * sin(rotation) * 10);
            point.Y = (int)(PointX * sin(rotation) * 10 + PointY * cos(rotation) * 10);

            return new Point(point.X, point.Y);
        }

        // For readability and easier typing, I use cos and sin instead of Math.Cos and Math.Sin
        public static float cos(float input)
        {
            return (float)Math.Cos(input);
        }

        public static float sin(float input)
        {
            return (float)Math.Sin(input);
        }

        public static float GetDistance2D(Point p, Point t)
        {
            // Distance formula
            // http://emcf.github.io/projects_files/Distance.png

            double DistX = Math.Pow(p.X - t.X, 2);
            double DistY = Math.Pow(p.Y - t.Y, 2);
            return (float)Math.Sqrt(DistX + DistY);
        }
    }
}
