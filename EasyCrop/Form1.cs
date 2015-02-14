using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyCrop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Point Begin { get; set; }
        public Rectangle Selection { get; private set; }

        private void Form1_Load(object sender, EventArgs e)
        {
            ofdOpen.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            if(ofdOpen.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                OpenImage(ofdOpen.FileName);
            }
            else
            {
                MessageBox.Show("The program will now end", "exit");
                Application.Exit();
            }
        }

        private void OpenImage(string path)
        {
            pbPicture.Load(path);
        }

        private void pbPicture_MouseDown(object sender, MouseEventArgs e)
        {
            // begin drag a box
            Begin = e.Location;
        }

        private void pbPicture_MouseUp(object sender, MouseEventArgs e)
        {
            Point begin = Begin;
            Point end = e.Location;

            GraphicsUnit pixel = GraphicsUnit.Pixel;

            var bounds = pbPicture.Image.GetBounds(ref pixel);
            int imageWidth = pbPicture.Image.Width;
            int imageHeight = pbPicture.Image.Height;

            if (bounds.Contains(begin) && bounds.Contains(end))
            {
                Selection = MakeRectangle(begin, end);
                using (Graphics g = pbPicture.CreateGraphics())
                using (Pen pen = new Pen(Color.Black, 2))
                using (Brush brush = new SolidBrush(this.pbPicture.BackColor))
                {
                    g.DrawRectangle(pen, Selection);
                }
                
                Begin = Point.Empty;
            }
            else
            {
                MessageBox.Show(this, "Selected coordinates are outside the picture", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Rectangle MakeRectangle(Point begin, Point end)
        {
            Point topLeft = new Point(Math.Min(begin.X, end.X), Math.Min(begin.Y, end.Y));
            Point bottomRight = new Point(Math.Max(begin.X, end.X), Math.Max(begin.Y, end.Y));

            int width = bottomRight.X - topLeft.X;
            int height = bottomRight.Y - topLeft.Y;

            Size size = new Size(width, height);

            return new Rectangle(topLeft, size);
        }
    }
}
