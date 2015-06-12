using System;
using System.Drawing;
using System.Windows.Forms;

namespace Tesseract
{
    class Transformations3D
    {
        // Transformations class using the Point3D data type to translate, transform, and project 2D and 3D Objects
        // TODO: Add a functional 4D projection algorithm to Tesseract

        public static Point3D Translate3DPoint(Point3D p, Point3D t)
        {
            // Move point P to point T's location
            return new Point3D()
            {
                x = p.x + t.x,
                y = p.y + t.y,
                z = p.z + t.z
            };
        }

        public static Point Project3DPoint(Point3D p)
        {
            // This is the most important function, it projects an XYZ point as an XY Point.
            try
            {
                return new Point()
                {
                    X = p.x * frmMain.ProjectionSize / p.z,
                    Y = p.y * frmMain.ProjectionSize / p.z
                };
            }
            catch
            {
                // The program cannot divide by 0. This will make the projection less accurate, but it will allow streamline use of the program.
                return new Point()
                {
                    X = p.x * frmMain.ProjectionSize,
                    Y = p.y * frmMain.ProjectionSize
                };
            }
        }

        public static Point3D Scale3DPoint(Point3D p, int f)
        {
            // Self explanitory
            return new Point3D()
            {
                x = p.x * f,
                y = p.y * f,
                z = p.z * f
            };
        }

        public static Point3D Rotate3DPoint(Point3D point, Point3D rotation)
        {
            // Convert the rotation to radians
            float RotationX = rotation.x / 180.0f;
            float RotationY = rotation.y / 180.0f;
            float RotationZ = rotation.z / 180.0f;
            int PointX, PointY, PointZ;


            // This is the perspective projection the program uses to convert (x, y, z) co-ordinates to (x, y) co-ordinates
            // The function this is based off of is on my website. The formula is also on wikipedia.
            // http://emcf.github.io/projects_files/PerspectiveProjection.png
            // http://en.wikipedia.org/wiki/3D_projection

            PointY = point.y;
            PointZ = point.z;
            point.y = (int)(PointY * cos(RotationX) - PointZ * sin(RotationX));
            point.z = (int)(PointY * sin(RotationX) + PointZ * cos(RotationX));

            PointZ = point.z;
            PointX = point.x;
            point.z = (int)(PointZ * cos(RotationY) - PointX * sin(RotationY));
            point.x = (int)(PointZ * sin(RotationY) + PointX * cos(RotationY));

            PointX = point.x;
            PointY = point.y;
            point.x = (int)(PointX * cos(RotationZ) - PointY * sin(RotationZ));
            point.y = (int)(PointX * sin(RotationZ) + PointY * cos(RotationZ));

            return point;
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

        public static float GetDistance3D(Point3D p, Point3D t)
        {
            // Distance formula
            // http://emcf.github.io/projects_files/Distance.png

            double DistX = Math.Pow(p.x - t.x, 2);
            double DistY = Math.Pow(p.y - t.y, 2);
            double DistZ = Math.Pow(p.x - t.z, 2);
            return (float)Math.Sqrt(DistX + DistY + DistZ);
        }
    }
}
