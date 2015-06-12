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
    }
}
