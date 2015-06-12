namespace Tesseract
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnImport = new System.Windows.Forms.Button();
            this.cbDrawMesh = new System.Windows.Forms.CheckBox();
            this.tbProjectionSize = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ofdImport = new System.Windows.Forms.OpenFileDialog();
            this.cbDrawWireframe = new System.Windows.Forms.CheckBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tbPointSize = new System.Windows.Forms.TrackBar();
            this.pnlPlane = new Tesseract.DoubleBufferedPanel();
            this.pnlZRotation = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.pnlYRotation = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlXRotation = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tbProjectionSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbPointSize)).BeginInit();
            this.pnlPlane.SuspendLayout();
            this.pnlZRotation.SuspendLayout();
            this.pnlYRotation.SuspendLayout();
            this.pnlXRotation.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnImport
            // 
            this.btnImport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(79)))), ((int)(((byte)(92)))));
            this.btnImport.FlatAppearance.BorderSize = 0;
            this.btnImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(185)))), ((int)(((byte)(0)))));
            this.btnImport.Location = new System.Drawing.Point(15, 31);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(615, 23);
            this.btnImport.TabIndex = 1;
            this.btnImport.Tag = "Import a 3D object";
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = false;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // cbDrawMesh
            // 
            this.cbDrawMesh.AutoSize = true;
            this.cbDrawMesh.Checked = true;
            this.cbDrawMesh.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbDrawMesh.Cursor = System.Windows.Forms.Cursors.Default;
            this.cbDrawMesh.ForeColor = System.Drawing.Color.White;
            this.cbDrawMesh.Location = new System.Drawing.Point(578, 67);
            this.cbDrawMesh.Name = "cbDrawMesh";
            this.cbDrawMesh.Size = new System.Drawing.Size(52, 17);
            this.cbDrawMesh.TabIndex = 2;
            this.cbDrawMesh.Text = "Mesh";
            this.cbDrawMesh.UseVisualStyleBackColor = true;
            this.cbDrawMesh.CheckedChanged += new System.EventHandler(this.cbDrawLines_CheckedChanged);
            // 
            // tbProjectionSize
            // 
            this.tbProjectionSize.Location = new System.Drawing.Point(98, 63);
            this.tbProjectionSize.Maximum = 500;
            this.tbProjectionSize.Name = "tbProjectionSize";
            this.tbProjectionSize.Size = new System.Drawing.Size(137, 45);
            this.tbProjectionSize.TabIndex = 4;
            this.tbProjectionSize.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbProjectionSize.Value = 300;
            this.tbProjectionSize.Scroll += new System.EventHandler(this.tbProjectionSize_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(15, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Projection Size";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(238, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Point Size";
            // 
            // ofdImport
            // 
            this.ofdImport.Filter = "3D Files|*.xyz|4D Files|*.xyzw|2D Files|*.xy";
            this.ofdImport.Title = "Import a Tesseract File";
            // 
            // cbDrawWireframe
            // 
            this.cbDrawWireframe.AutoSize = true;
            this.cbDrawWireframe.Checked = true;
            this.cbDrawWireframe.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbDrawWireframe.Cursor = System.Windows.Forms.Cursors.Default;
            this.cbDrawWireframe.ForeColor = System.Drawing.Color.White;
            this.cbDrawWireframe.Location = new System.Drawing.Point(479, 66);
            this.cbDrawWireframe.Name = "cbDrawWireframe";
            this.cbDrawWireframe.Size = new System.Drawing.Size(93, 17);
            this.cbDrawWireframe.TabIndex = 8;
            this.cbDrawWireframe.Text = "Full Wireframe";
            this.cbDrawWireframe.UseVisualStyleBackColor = true;
            this.cbDrawWireframe.CheckedChanged += new System.EventHandler(this.cbDrawWireframe_CheckedChanged);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(79)))), ((int)(((byte)(92)))));
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(600, -2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(30, 18);
            this.btnClose.TabIndex = 9;
            this.btnClose.Tag = "Import a 3D object";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(12, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(177, 13);
            this.lblTitle.TabIndex = 10;
            this.lblTitle.Text = "Tesseract - Multidimensional Models";
            // 
            // tbPointSize
            // 
            this.tbPointSize.Location = new System.Drawing.Point(298, 63);
            this.tbPointSize.Maximum = 20;
            this.tbPointSize.Name = "tbPointSize";
            this.tbPointSize.Size = new System.Drawing.Size(175, 45);
            this.tbPointSize.TabIndex = 7;
            this.tbPointSize.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbPointSize.Value = 5;
            this.tbPointSize.Scroll += new System.EventHandler(this.tbPointSize_Scroll);
            // 
            // pnlPlane
            // 
            this.pnlPlane.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(79)))), ((int)(((byte)(92)))));
            this.pnlPlane.Controls.Add(this.pnlZRotation);
            this.pnlPlane.Controls.Add(this.pnlYRotation);
            this.pnlPlane.Controls.Add(this.pnlXRotation);
            this.pnlPlane.Location = new System.Drawing.Point(15, 90);
            this.pnlPlane.Name = "pnlPlane";
            this.pnlPlane.Size = new System.Drawing.Size(615, 370);
            this.pnlPlane.TabIndex = 0;
            this.pnlPlane.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlPlane_Paint);
            this.pnlPlane.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlPlane_MouseDown);
            this.pnlPlane.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlPlane_MouseMove);
            this.pnlPlane.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlPlane_MouseUp);
            // 
            // pnlZRotation
            // 
            this.pnlZRotation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(185)))), ((int)(((byte)(0)))));
            this.pnlZRotation.Controls.Add(this.label5);
            this.pnlZRotation.Location = new System.Drawing.Point(3, 347);
            this.pnlZRotation.Name = "pnlZRotation";
            this.pnlZRotation.Size = new System.Drawing.Size(74, 19);
            this.pnlZRotation.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 2);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(12, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "z";
            // 
            // pnlYRotation
            // 
            this.pnlYRotation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(185)))), ((int)(((byte)(0)))));
            this.pnlYRotation.Controls.Add(this.label4);
            this.pnlYRotation.Location = new System.Drawing.Point(3, 326);
            this.pnlYRotation.Name = "pnlYRotation";
            this.pnlYRotation.Size = new System.Drawing.Size(74, 19);
            this.pnlYRotation.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(12, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "y";
            // 
            // pnlXRotation
            // 
            this.pnlXRotation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(185)))), ((int)(((byte)(0)))));
            this.pnlXRotation.Controls.Add(this.label3);
            this.pnlXRotation.Location = new System.Drawing.Point(3, 305);
            this.pnlXRotation.Name = "pnlXRotation";
            this.pnlXRotation.Size = new System.Drawing.Size(74, 19);
            this.pnlXRotation.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(12, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "x";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(65)))));
            this.ClientSize = new System.Drawing.Size(644, 476);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.cbDrawWireframe);
            this.Controls.Add(this.tbPointSize);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbProjectionSize);
            this.Controls.Add(this.cbDrawMesh);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.pnlPlane);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMain";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tesseract";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmMain_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmMain_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.frmMain_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.tbProjectionSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbPointSize)).EndInit();
            this.pnlPlane.ResumeLayout(false);
            this.pnlZRotation.ResumeLayout(false);
            this.pnlZRotation.PerformLayout();
            this.pnlYRotation.ResumeLayout(false);
            this.pnlYRotation.PerformLayout();
            this.pnlXRotation.ResumeLayout(false);
            this.pnlXRotation.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DoubleBufferedPanel pnlPlane;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.CheckBox cbDrawMesh;
        private System.Windows.Forms.TrackBar tbProjectionSize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.OpenFileDialog ofdImport;
        private System.Windows.Forms.Panel pnlZRotation;
        private System.Windows.Forms.Panel pnlYRotation;
        private System.Windows.Forms.Panel pnlXRotation;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cbDrawWireframe;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TrackBar tbPointSize;
    }
}

