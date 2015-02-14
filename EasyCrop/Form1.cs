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
            
        }
    }
}
