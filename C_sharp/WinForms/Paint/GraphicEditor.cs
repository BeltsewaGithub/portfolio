using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace Paint
{
    public partial class GraphicEditor : Form
    {
        private bool isDrawing = false;

        private Color currentColor = Color.Black;
        Pen currentPen = new Pen(Color.Black, 1);
        private Color backgroundColor = Color.White;

        private bool isDrawingRectangle = false;
        private bool isDrawingEllipse = false;
        private bool isPaint = false;
        private bool isFill = false;
        
        Bitmap myBitmap;
        Graphics g;

        Point point1, pointS, pointC;
        Point px, py;


        public GraphicEditor()
        {
            InitializeComponent();
            myBitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
            g = Graphics.FromImage(myBitmap);
            g.Clear(backgroundColor);
            pictureBox.Image = myBitmap;
        }

        private void GraphicEditor_Load(object sender, EventArgs e)
        {
            for (int i = 1; i < 40; i += 2)
            {
                lineThicknessToolStripDropDownButton.Items.Add(i);
            }
            
            colorChooseToolStripButton.BackColor = Color.Black;
            lineThicknessToolStripDropDownButton.SelectedItem = 1;
        }

        //**************
        //MOUSE ACTIONS
        //**************
        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                return;
            }
            isPaint = true;
            py = e.Location;
            pointC = new Point(e.X, e.Y);
            /*cX = e.X;
            cY = e.Y;*/
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                return;
            }
            isPaint = false;
            pointS = new Point(point1.X - pointC.X, point1.Y - pointC.Y);
            
            if (isDrawingRectangle)
                g.DrawRectangle(currentPen, pointC.X, pointC.Y, pointS.X, pointS.Y);

            if (isDrawingEllipse)
                g.DrawEllipse(currentPen, pointC.X, pointC.Y, pointS.X, pointS.Y);

        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing && isPaint)
            {
                if (e.Button == MouseButtons.Left)
                {
                    px = e.Location;
                    g.DrawLine(currentPen, px, py);
                    py = px;
                }
            }
            pictureBox.Refresh();
            point1 = new Point(e.X, e.Y);
            pointS = new Point(e.X - pointC.X, e.Y - pointC.Y);
        }

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            if (isPaint)
            {
                if (isDrawingEllipse)
                {
                    g.DrawEllipse(currentPen, pointC.X, pointC.Y, pointS.X, pointS.Y);
                }
                if (isDrawingRectangle)
                {
                    g.DrawRectangle(currentPen, pointC.X, pointC.Y, pointS.X, pointS.Y);
                }
            }
        }

        //**************
        //MOUSE ACTIONS
        //**************
        private void brushToolButton_Click(object sender, EventArgs e)
        {
            isDrawing = true;
            isDrawingEllipse = false;
            isDrawingRectangle = false;
            isFill = false;
            currentPen = new Pen(currentColor, Convert.ToInt32(lineThicknessToolStripDropDownButton.Text));
        }

        private void rectangleToolButton_Click(object sender, EventArgs e)
        {
            isDrawingRectangle = true;
            isDrawing = false;
            isDrawingEllipse = false;
            isFill= false;
        }

        private void ellipseToolButton_Click(object sender, EventArgs e)
        {
            isDrawingEllipse = true;
            isDrawing = false;
            isDrawingRectangle = false;
            isFill = false;
        }

        private void fillingToolStripButton_Click(object sender, EventArgs e)
        {
            isFill = true;
            isDrawingEllipse = false;
            isDrawing = false;
            isDrawingRectangle = false;
        }

        private void pictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                return;
            }
            if (isFill)
            {
                Point point = set_point(pictureBox, e.Location);
                Fill(myBitmap, point.X, point.Y, currentColor);

            }
        }
        public void Fill(Bitmap bm, int x, int y, Color newColor)
        {
            Color oldColor = bm.GetPixel(x, y);
            Stack<Point> pixel = new Stack<Point>();
            pixel.Push(new Point(x, y));
            bm.SetPixel(x, y, newColor);
            if (oldColor == newColor)
            {
                return;
            }

            while (pixel.Count > 0)
            {
                Point pt = (Point)pixel.Pop();
                if (pt.X > 0 && pt.Y > 0 && pt.X < bm.Width - 1 && pt.Y < bm.Height - 1)
                {
                    validate(bm, pixel, pt.X - 1, pt.Y, oldColor, newColor);
                    validate(bm, pixel, pt.X, pt.Y - 1, oldColor, newColor);
                    validate(bm, pixel, pt.X + 1, pt.Y, oldColor, newColor);
                    validate(bm, pixel, pt.X, pt.Y + 1, oldColor, newColor);
                }
            }
        }

        private void validate(Bitmap bm, Stack<Point> sp, int x, int y, Color old_color, Color new_color)
        {
            Color cx = bm.GetPixel(x, y);
            if (cx == old_color)
            {
                sp.Push(new Point(x, y));
                bm.SetPixel(x, y, new_color);
            }
        }

        static Point set_point(PictureBox pb, Point pt)
        {
            float pX = 1f * pb.Image.Width / pb.Width;
            float pY = 1f * pb.Image.Height / pb.Height;
            return new Point((int)(pt.X * pX), (int)(pt.Y * pY));
        }

        private void eraserToolButton_Click(object sender, EventArgs e)
        {
            isDrawing = true;
            isDrawingEllipse = false;
            isDrawingRectangle = false;
            isFill = false;
            currentPen = new Pen(backgroundColor,
                Convert.ToInt32(lineThicknessToolStripDropDownButton.Text));
        }

        private void colorChooseToolStripButton_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                currentColor = colorDialog.Color;
                currentPen = new Pen(currentColor, currentPen.Width);
            }

            colorChooseToolStripButton.BackColor = currentColor;
        }

        private void lineThicknessToolStripDropDownButton_Click(object sender, EventArgs e)
        {

            int width = Convert.ToInt32(lineThicknessToolStripDropDownButton.Text);
            currentPen = new Pen(currentColor, width);
        }

        //*************
        //MENU ACTIONS
        //*************
        private void newFileMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox.Image = null;
        }

        private void openFileMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "PNG|*.png";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {

                pictureBox.ImageLocation = openFileDialog.FileName;
            }
        }
        private void importMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            if (myBitmap != null)
            {
                myBitmap.Dispose();
            }

            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {

                myBitmap = new Bitmap(openFileDialog.FileName);
                pictureBox.ClientSize = new Size(myBitmap.Width, myBitmap.Height);
                pictureBox.Image = (Image)myBitmap;
            }
        }

        private void exportMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string file;
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filename = saveFileDialog.FileName;
                    pictureBox.Image.Save(filename);
                    file = Path.GetFileName(filename);
                    MessageBox.Show("File " + file + " was saved successfully.", "Save Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
