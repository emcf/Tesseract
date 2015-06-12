using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace Tesseract
{
    public partial class frmMain : Form
    {
        public static int ProjectionSize = 300;
        int PointSize = 5;
        bool DrawMesh = true;
        bool DrawWireframe = true;
        bool IsFormDragging = false;
        bool IsRotating = false;
        Point3D Rotation = new Point3D() { x = 0, y = 0, z = 0 };
        Point3D[] Object;
        Point FormStartingMouseLocation;
        Point RotationStartingMouseLocation;

        public frmMain()
        {
            InitializeComponent();
            tbPointSize.SendToBack();
            tbProjectionSize.SendToBack();
        }

        private void pnlPlane_Paint(object sender, PaintEventArgs e)
        {
            if (Object != null)
            {
                int Distance = 100;
                Point[] Verticies = new Point[Object.Length];

                for (int i = 0; i < Verticies.Length; i++)
                {
                    // Kill me please
                    Verticies[i] = Transformations2D.Translate2DPoint(Transformations3D.Project3DPoint(Transformations3D.Translate3DPoint(Transformations3D.Rotate3DPoint(Transformations3D.Scale3DPoint(Object[i], 10), Rotation), new Point3D() { x = 0, y = 0, z = Distance })), new Point() { X = pnlPlane.Width / 2, Y = pnlPlane.Height / 2 });

                    // Draw a point for each vertex
                    SolidBrush PointBrush = new SolidBrush(Color.FromArgb(141, 185, 0));
                    e.Graphics.FillEllipse(PointBrush, Verticies[i].X, Verticies[i].Y, PointSize, PointSize);

                    // Draw line from each vertex to the other
                    // TODO: Use GetDistance3D() to only draw lines between the 3 closest points to a point.

                    Pen LinePen = new Pen(new SolidBrush(Color.FromArgb(33, 42, 65)));
                    if (DrawWireframe)
                    {
                        // Lines are drawn from every point to every other point when full wireframe is enabled.

                        for (int n = 0; n < Verticies.Length; n++)
                        {
                            for (int n2 = 0; n2 < Verticies.Length; n2++)
                            {
                                Point3D PointOne = Object[n];
                                Point3D PointTwo = Object[n2];
                                if (PointOne != PointTwo && !Verticies[n].IsEmpty && !Verticies[n2].IsEmpty)
                                {
                                    e.Graphics.DrawLine(LinePen, Verticies[n], Verticies[n2]);
                                }
                            }
                        }
                    }
                    else if (DrawMesh && i > 0)
                    {
                        Point p = Verticies[i];

                        // Set values for finding lowest distances
                        float[] VertexDistances = new float[Verticies.Length];

                        // This is the algorithm that finds the three lowest distances and draws lines to only them
                        // This lets the screen draw an accurate mesh rather than lines from every point to the other
                        // TODO: Use slope formula (http://emcf.github.io/projects_files/Slope.png) instead of distance to determine which lines intersect therefore shouldn't be drawn because they aren't faces

                        for (int n = 0; n < Verticies.Length; n++)
                        {
                            VertexDistances[n] = Transformations3D.GetDistance3D(Object[i], Object[n]);
                        }

                        Array.Sort(VertexDistances);

                        for (int n = 0; n < Verticies.Length; n++)
                        {
                            for (int n2 = 0; n2 < Verticies.Length; n2++)
                            {
                                Point3D PointOne = Object[n];
                                Point3D PointTwo = Object[n2];
                                float PointsDistance = Transformations3D.GetDistance3D(PointOne, PointTwo);

                                // Detect whether the point is one of the top 3 closes points to point PointOne
                                bool ShouldDrawLine = (PointsDistance <= VertexDistances[0]) || (PointsDistance <= VertexDistances[1]) || (PointsDistance <= VertexDistances[2]);

                                if (ShouldDrawLine && PointOne != PointTwo && !Verticies[n].IsEmpty && !Verticies[n2].IsEmpty)
                                {
                                    e.Graphics.DrawLine(LinePen, Verticies[n], Verticies[n2]);
                                }
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

            pnlXRotation.Width = (int)(Math.Sin(RotationX) * 50);
            pnlYRotation.Width = (int)(Math.Sin(RotationY) * 50);
            pnlZRotation.Width = (int)(Math.Sin(RotationZ) * 50);
        }
    
        private void btnImport_Click(object sender, EventArgs e)
        {
            // Import .xyz file
            if (ofdImport.ShowDialog() == DialogResult.OK)
            {
                // Read each line and seperate the (x, y, z) points at each comma
                String[] Lines = File.ReadAllLines(ofdImport.FileName);
                Object = new Point3D[Lines.Length];

                for (int i = 0; i < Lines.Length; i++)
                {
                    String[] SplitCoordinates = Lines[i].Split(',');
                    int xVal = Convert.ToInt32(SplitCoordinates[0]);
                    int yVal = Convert.ToInt32(SplitCoordinates[1]);
                    int zVal = Convert.ToInt32(SplitCoordinates[2]);

                    // Add point to object
                    Object[i] = new Point3D()
                    {
                        x = xVal,
                        y = yVal,
                        z = zVal
                    };
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
                Rotation.z = (Rotation.x + Rotation.y) / 2;

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


    public class DoubleBufferedPanel : Panel
    {
        // Double Buffered Panel to remove flickering during panel refreshes
        // This is actually not my code. In fact, I learned what Double Buffering is today.
        public DoubleBufferedPanel()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
            ControlStyles.OptimizedDoubleBuffer |
            ControlStyles.UserPaint, true);
        }
    }
}
