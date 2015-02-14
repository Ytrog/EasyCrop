namespace EasyCrop
{
    partial class Form1
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
            this.pbPicture = new System.Windows.Forms.PictureBox();
            this.ofdOpen = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pbPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // pbPicture
            // 
            this.pbPicture.Cursor = System.Windows.Forms.Cursors.Cross;
            this.pbPicture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbPicture.Location = new System.Drawing.Point(0, 0);
            this.pbPicture.Name = "pbPicture";
            this.pbPicture.Size = new System.Drawing.Size(817, 446);
            this.pbPicture.TabIndex = 0;
            this.pbPicture.TabStop = false;
            this.pbPicture.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbPicture_MouseDown);
            this.pbPicture.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbPicture_MouseUp);
            // 
            // ofdOpen
            // 
            this.ofdOpen.Filter = "JPEG|*.jpg|PNG|*.png|All files|*.*";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 446);
            this.Controls.Add(this.pbPicture);
            this.Name = "Form1";
            this.Text = "Easy Crop";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbPicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbPicture;
        private System.Windows.Forms.OpenFileDialog ofdOpen;
    }
}

