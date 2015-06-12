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
            return new Point4D()
            {
                x = p.x * f,
                y = p.y * f,
                z = p.z * f,
                z = p.w * f
            };
        }
        
        public static Point4D Rotate4DPoint(Point4D point, Point4D rotation)
        {
            // Convert the rotation to radians
            float RotationX = rotation.x / 180.0f;
            float RotationY = rotation.y / 180.0f;
            float RotationZ = rotation.z / 180.0f;
            float RotationW = rotation.w / 180.0f;
            int PointX, PointY, PointZ, PointW;

            // This is the perspective projection the program uses to convert (x, y, z, w) co-ordinates to (x, y, z) co-ordinates
            // This function is not on the internet... anywhere.

            // Below is the 3D rotation function. Hopefully I can change it to rotate 4D objects soon 
            /*
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
            */
            
            return point;
        }
        
        public static float cos(float input)
        {
            return (float)Math.Cos(input);
        }

        public static float sin(float input)
        {
            return (float)Math.Sin(input);
        }
        
        public static float GetDistance4D(Point4D p, Point4D t)
        {
            // Distance formula
            // http://emcf.github.io/projects_files/Distance.png
            
            double DistX = Math.Pow(p.x - t.x, 2);
            double DistY = Math.Pow(p.y - t.y, 2);
            double DistZ = Math.Pow(p.z - t.z, 2);
            double DistW = Math.Pow(p.w - t.w, 2);
            return (float)Math.Sqrt(DistX + DistY + DistZ + DistW);
        }
    }
}
