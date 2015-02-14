using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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

            Image image = pbPicture.Image;

            var bounds = image.GetBounds(ref pixel);
            int imageWidth = image.Width;
            int imageHeight = image.Height;

            if (bounds.Contains(begin) && bounds.Contains(end))
            {
                Selection = MakeRectangle(begin, end);
                using (Graphics g = pbPicture.CreateGraphics())
                using (Pen pen = new Pen(Color.Black, 2))
                using (Brush brush = new SolidBrush(this.pbPicture.BackColor))
                {
                    g.DrawRectangle(pen, Selection);
                }

                Bitmap bitmap = image as Bitmap;

                if (bitmap != null)
                {
                    Bitmap result = bitmap.Clone(Selection, bitmap.PixelFormat);

                    string cropPath = CropPath(ofdOpen.FileName);
                    sfdSave.InitialDirectory = Path.GetDirectoryName(ofdOpen.FileName);
                    sfdSave.FileName = cropPath;
                    if(sfdSave.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                    {
                        result.Save(sfdSave.FileName);
                    }
                    else
                    {
                        Deselect();
                    }
                }

                Begin = Point.Empty;
            }
            else
            {
                MessageBox.Show(this, "Selected coordinates are outside the picture", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Deselect()
        {
            Selection = Rectangle.Empty;
            pbPicture.Refresh();
        }

        private string CropPath(string p)
        {
            string directory = Path.GetDirectoryName(p);
            string file = Path.GetFileNameWithoutExtension(p);
            string extension = Path.GetExtension(p);

            return Path.Combine(directory, file + "_cropped" + extension);

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
