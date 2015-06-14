using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace Tesseract
{
    public partial class frmMain : Form
    {
        public static int ProjectionSize = 300;
        int Distance = 100;
        int PointSize = 5;
        
        bool DrawMesh = true;
        bool DrawWireframe = false;
        bool IsFormDragging = false;
        bool IsRotating = false;
        
        Point4D Rotation = new Point4D() { x = 0, y = 0, z = 0, w = 0 };
        Point[] Object2D;
        Point3D[] Object3D;
        Point4D[] Object4D;
        
        Point FormStartingMouseLocation;
        Point RotationStartingMouseLocation;

        public frmMain()
        {
            InitializeComponent();
            tbPointSize.SendToBack();
            tbDistance.SendToBack();
            tbProjectionSize.SendToBack();
        }

        private void pnlPlane_Paint(object sender, PaintEventArgs e)
        {
            SolidBrush PointBrush = new SolidBrush(Color.FromArgb(141, 185, 0));
            Pen LinePen = new Pen(new SolidBrush(Color.FromArgb(33, 42, 65)));

            // Draw the 2D grid in the background of the panel
            for (int x = 0; x < pnlPlane.Width; x += 10)
            {
                for (int y = 0; y < pnlPlane.Height; y += 10)
                {
                    e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(33, 42, 65)), x, y, 1, 1);
                }
            }

            if (Object2D != null)
            {
                Point[] Verticies = new Point[Object2D.Length];

                for (int i = 0; i < Verticies.Length; i++)
                {
                    Point Rotated = Transformations2D.Rotate2DPoint(Object2D[i], Rotation.x);
                    Point Scaled = Transformations2D.Scale2DPoint(Rotated, ProjectionSize / 10);
                    Point Translated = Transformations2D.Translate2DPoint(Scaled, new Point(pnlPlane.Width / 2, pnlPlane.Height / 2));

                    Verticies[i] = Translated;
                   
                    // Draw a point for each vertex
                    e.Graphics.FillEllipse(PointBrush, Verticies[i].X, Verticies[i].Y, PointSize, PointSize);

                    // Draw line from each vertex to the other

                    if (DrawWireframe)
                    {
                        // Lines are drawn from every point to every other point when full wireframe is enabled.
                        for (int i2 = 0; i2 < Verticies.Length; i2++)
                        {
                            Point PointOne = Object2D[i];
                            Point PointTwo = Object2D[i2];
                            if (PointOne != PointTwo && !Verticies[i].IsEmpty && !Verticies[i2].IsEmpty)
                            {
                                e.Graphics.DrawLine(LinePen, Verticies[i], Verticies[i2]);
                            }
                        }
                    }
                    else if (DrawMesh && i > 0)
                    {
                        Point p = Verticies[i];

                        // Set values for finding lowest distances
                        float[] VertexDistances = new float[Verticies.Length];

                        // This is the algorithm that finds the three lowest distances and draws lines to only them
                        for (int n = 0; n < Verticies.Length; n++)
                        {
                            VertexDistances[n] = Transformations2D.GetDistance2D(Object2D[i], Object2D[n]);
                        }

                        Array.Sort(VertexDistances);

                            for (int i2 = 0; i2 < Verticies.Length; i2++)
                            {
                                Point PointOne = Object2D[i];
                                Point PointTwo = Object2D[i2];
                                float PointsDistance = Transformations2D.GetDistance2D(PointOne, PointTwo);

                                // Detect whether the point is one of the top 2 closes points to point PointOne
                                bool ShouldDrawLine = PointsDistance <= VertexDistances[1];

                                if (ShouldDrawLine && PointOne != PointTwo && !Verticies[i].IsEmpty && !Verticies[i2].IsEmpty)
                                {
                                    e.Graphics.DrawLine(LinePen, Verticies[i], Verticies[i2]);
                                }
                        }
                    }
                }
            }
            if (Object3D != null)
            {
                Point[] Verticies = new Point[Object3D.Length];

                for (int i = 0; i < Verticies.Length; i++)
                {
                    // Scale the 3D vertex
                    Point3D Scaled = Transformations3D.Scale3DPoint(Object3D[i], 10);
                    // Convert the XYZW rotation to XYZ rotation by omitting the W value, rotate the pitch, roll, and yaw
                    Point3D Rotated = Transformations3D.Rotate3DPoint(Scaled, new Point3D() { x = Rotation.x, y = Rotation.y, z = Rotation.z });
                    // Translate it using distance
                    Point3D Translated3D = Transformations3D.Translate3DPoint(Rotated, new Point3D() { x = 0, y = 0, z = Distance });
                    // Convert 3D to 2D and project it in the middle of the panel
                    Point Projected = Transformations3D.Project3DPoint(Translated3D);
                    Point Translated2D = Transformations2D.Translate2DPoint(Projected, new Point(pnlPlane.Width / 2, pnlPlane.Height / 2));

                    Verticies[i] = Translated2D;

                    // Draw a point for each vertex
                    e.Graphics.FillEllipse(PointBrush, Verticies[i].X, Verticies[i].Y, PointSize, PointSize);

                    // Draw line from each vertex to the other
                    if (DrawWireframe)
                    {
                        // Lines are drawn from every point to every other point when full wireframe is enabled.
                        for (int i2 = 0; i2 < Verticies.Length; i2++)
                        {
                            Point3D PointOne = Object3D[i];
                            Point3D PointTwo = Object3D[i2];
                            if (PointOne != PointTwo && !Verticies[i].IsEmpty && !Verticies[i2].IsEmpty)
                            {
                                e.Graphics.DrawLine(LinePen, Verticies[i], Verticies[i2]);
                            }
                        }
                    }
                    else if (DrawMesh && i > 0)
                    {
                        Point p = Verticies[i];

                        // Set values for finding lowest distances
                        float[] VertexDistances = new float[Verticies.Length];

                        // This is the algorithm that finds the three lowest distances and draws lines to only them

                        for (int n = 0; n < Verticies.Length; n++)
                        {
                            VertexDistances[n] = Transformations3D.GetDistance3D(Object3D[i], Object3D[n]);
                        }

                        Array.Sort(VertexDistances);

                        for (int i2 = 0; i2 < Verticies.Length; i2++)
                        {
                            Point3D PointOne = Object3D[i];
                            Point3D PointTwo = Object3D[i2];
                            float PointsDistance = Transformations3D.GetDistance3D(PointOne, PointTwo);

                            // Detect whether the point is one of the top 3 closes points to point PointOne
                            bool ShouldDrawLine = PointsDistance <= VertexDistances[2];

                            if (ShouldDrawLine && PointOne != PointTwo && !Verticies[i].IsEmpty && !Verticies[i2].IsEmpty)
                            {
                                e.Graphics.DrawLine(LinePen, Verticies[i], Verticies[i2]);
                            }
                        }
                    }
                }
            }
            if (Object4D != null)
            {
                Point[] Verticies = new Point[Object4D.Length];

                for (int i = 0; i < Verticies.Length; i++)
                {
                    // Kill me please
                    Point4D Scaled = Transformations4D.Scale4DPoint(Object4D[i], 10);
                    Point4D Translated4D = Transformations4D.Translate4DPoint(Scaled, new Point4D() { x = 0, y = 0, z = Distance, w = 0 });
                    Point3D Projected3D = Transformations4D.Project4DPoint(Translated4D);
                    Point Projected2D = Transformations3D.Project3DPoint(Projected3D);
                    Point Translated2D = Transformations2D.Translate2DPoint(Projected2D, new Point(pnlPlane.Width / 2, pnlPlane.Height / 2));

                    Verticies[i] = Translated2D;

                    // Draw a point for each vertex
                    e.Graphics.FillEllipse(PointBrush, Verticies[i].X, Verticies[i].Y, PointSize, PointSize);

                    // Draw line from each vertex to the other

                    if (DrawWireframe)
                    {
                        // Lines are drawn from every point to every other point when full wireframe is enabled.
                        for (int i2 = 0; i2 < Verticies.Length; i2++)
                        {
                            Point4D PointOne = Object4D[i];
                            Point4D PointTwo = Object4D[i2];
                            if (PointOne != PointTwo && !Verticies[i].IsEmpty && !Verticies[i2].IsEmpty)
                            {
                                e.Graphics.DrawLine(LinePen, Verticies[i], Verticies[i2]);
                            }
                        }
                    }
                    else if (DrawMesh && i > 0)
                    {
                        Point p = Verticies[i];

                        // Set values for finding lowest distances
                        float[] VertexDistances = new float[Verticies.Length];

                        // This is the algorithm that finds the three lowest distances and draws lines to only them

                        for (int n = 0; n < Verticies.Length; n++)
                        {
                            VertexDistances[n] = Transformations3D.GetDistance3D(Object3D[i], Object3D[n]);
                        }

                        Array.Sort(VertexDistances);

                        for (int i2 = 0; i2 < Verticies.Length; i2++)
                        {
                            Point3D PointOne = Object3D[i];
                            Point3D PointTwo = Object3D[i2];
                            float PointsDistance = Transformations3D.GetDistance3D(PointOne, PointTwo);

                            // Detect whether the point is one of the top 4 closes points to point PointOne
                            bool ShouldDrawLine = PointsDistance <= VertexDistances[3];

                            if (ShouldDrawLine && PointOne != PointTwo && !Verticies[i].IsEmpty && !Verticies[i2].IsEmpty)
                            {
                                e.Graphics.DrawLine(LinePen, Verticies[i], Verticies[i2]);
                            }
                        }
                    }
                }
            }
        }

        void RedrawObject()
        {
            // This void is mostly for readability throughout the code
            // Because Invalidate() isn't too explanitory
            pnlPlane.Invalidate();

            // Convert the rotation to radians
            float RotationX = Rotation.x / 180.0f;
            float RotationY = Rotation.y / 180.0f;
            float RotationZ = Rotation.z / 180.0f;

            if (Object2D != null)
            {
                pnlXRotation.Width = (int)(Math.Sin(RotationX) * 50);
                pnlYRotation.Width = 0;
                pnlZRotation.Width = 0;
            }
            if (Object3D != null)
            {
                pnlXRotation.Width = (int)(Math.Sin(RotationX) * 50);
                pnlYRotation.Width = (int)(Math.Sin(RotationY) * 50);
                pnlZRotation.Width = (int)(Math.Sin(RotationZ) * 50);
            }
            if (Object4D != null)
            {

            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            // Import .xyz file
            if (ofdImport.ShowDialog() == DialogResult.OK)
            {
                // Read each line and seperate the (x, y, z) points at each comma
                String[] Lines = File.ReadAllLines(ofdImport.FileName);
                int DimensionsInFile = Lines[0].Split(',').Length;

                // If in 2D
                if (DimensionsInFile == 2)
                {
                    Object3D = null;
                    Object4D = null;
                    Object2D = new Point[Lines.Length];

                    // Projection size in 2D should be lowered due to a change in the Transformations2D class
                    ProjectionSize = ProjectionSize / 10;
                    tbProjectionSize.Value = ProjectionSize;

                    for (int i = 0; i < Lines.Length; i++)
                    {
                        String[] SplitCoordinates = Lines[i].Split(',');
                        int xVal = Convert.ToInt32(SplitCoordinates[0]);
                        int yVal = Convert.ToInt32(SplitCoordinates[1]);

                        // Add point to object
                        Object2D[i] = new Point()
                        {
                            X = xVal,
                            Y = yVal
                        };
                    }

                }
                // If in 3D
                else if (DimensionsInFile == 3)
                {
                    Object2D = null;
                    Object4D = null;
                    Object3D = new Point3D[Lines.Length];

                    for (int i = 0; i < Lines.Length; i++)
                    {
                        String[] SplitCoordinates = Lines[i].Split(',');
                        int xVal = Convert.ToInt32(SplitCoordinates[0]);
                        int yVal = Convert.ToInt32(SplitCoordinates[1]);
                        int zVal = Convert.ToInt32(SplitCoordinates[2]);

                        // Add point to object
                        Object3D[i] = new Point3D()
                        {
                            x = xVal,
                            y = yVal,
                            z = zVal
                        };
                    }
                }
                else if (DimensionsInFile == 4)
                {
                    Object2D = null;
                    Object3D = null;
                    Object4D = new Point4D[Lines.Length];

                    for (int i = 0; i < Lines.Length; i++)
                    {
                        String[] SplitCoordinates = Lines[i].Split(',');
                        int xVal = Convert.ToInt32(SplitCoordinates[0]);
                        int yVal = Convert.ToInt32(SplitCoordinates[1]);
                        int zVal = Convert.ToInt32(SplitCoordinates[2]);
                        int wVal = Convert.ToInt32(SplitCoordinates[3]);

                        // Add point to object
                        Object4D[i] = new Point4D()
                        {
                            x = xVal,
                            y = yVal,
                            z = zVal,
                            w = wVal
                        };
                    }
                }
                else
                {
                    MessageBox.Show("File not formatted correctly, there are " + DimensionsInFile.ToString() + " dimensions", "Error");
                }

                RedrawObject();
            }
        }

        private void cbDrawLines_CheckedChanged(object sender, EventArgs e)
        {
            DrawMesh = cbDrawMesh.Checked;
        }

        private void tbProjectionSize_Scroll(object sender, EventArgs e)
        {
            ProjectionSize = tbProjectionSize.Value;
        }

        private void tbPointSize_Scroll(object sender, EventArgs e)
        {
            PointSize = tbPointSize.Value;
        }

        private void pnlPlane_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsRotating)
            {
                int MovementX = e.X;
                int MovementY = e.Y;

                Rotation.x = MovementX;
                Rotation.y = MovementY;
                // I just arbitrarily chose what the z value should look like. It turned out nicely.
                Rotation.z = (Rotation.x + Rotation.y) / 3;

                RedrawObject();
            }
        }

        private void cbDrawWireframe_CheckedChanged(object sender, EventArgs e)
        {
            DrawWireframe = cbDrawWireframe.Checked;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmMain_MouseDown(object sender, MouseEventArgs e)
        {
            IsFormDragging = true;
            FormStartingMouseLocation = e.Location;
        }

        private void frmMain_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsFormDragging)
            {
                //this.Location = Cursor.Position;
                this.Location = new Point(Cursor.Position.X - FormStartingMouseLocation.X, Cursor.Position.Y - FormStartingMouseLocation.Y);
            }
        }

        private void frmMain_MouseUp(object sender, MouseEventArgs e)
        {
            IsFormDragging = false;
        }

        private void pnlPlane_MouseDown(object sender, MouseEventArgs e)
        {
            IsRotating = true;
            RotationStartingMouseLocation = e.Location;
        }

        private void pnlPlane_MouseUp(object sender, MouseEventArgs e)
        {
            IsRotating = false;
        }

        private void tbDistance_Scroll(object sender, EventArgs e)
        {
            Distance = tbDistance.Value;
        }
    }

    public class Point3D
    {
        // Class for a 3D Vector
        public int x { get; set; }
        public int y { get; set; }
        public int z { get; set; }
    }

    public class Point4D
    {
        // Class for a 4D Vector
        public int x { get; set; }
        public int y { get; set; }
        public int z { get; set; }
        public int w { get; set; }
    }
}
