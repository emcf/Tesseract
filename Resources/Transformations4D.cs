using System;
using System.Drawing;
using System.Windows.Forms;

namespace Tesseract
{
    class Transformations4D
    {
        public static Point4D Translate4DPoint(Point4D p, Point4D t)
        {
            // Move point P to point T's location
            return new Point4D()
            {
                x = p.x + t.x,
                y = p.y + t.y,
                z = p.z + t.z.
                w = w.z + w.z
            };
        }
        
        public static Point3D Project4DPoint(Point4D p)
        {
            // This is the most important function, it projects an XYZW point as an XYZ Point.
            try
            {
                return new Point3D()
                {
                    x = p.x * frmMain.ProjectionSize / p.w,
                    y = p.y * frmMain.ProjectionSize / p.w,
                    z = p.x * frmMain.ProjectionSize / p.w
                };
            }
            catch
            {
                // The program cannot divide by 0. This will make the projection less accurate, but it will allow streamline use of the program.
                return new Point3D()
                {
                    x = p.x * frmMain.ProjectionSize,
                    y = p.y * frmMain.ProjectionSize,
                    z = p.x * frmMain.ProjectionSize
                };
            }
        }
        
        public static Point4D Scale4DPoint(Point4D p, int f)
        {
            // Self explanitory
            return new Point3D()
            {
                x = p.x * f,
                y = p.y * f,
                z = p.z * f
            };
        }
    }
}
