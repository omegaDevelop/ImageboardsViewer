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

namespace ImageboardsViewer
{
    public partial class FullImageForm : Form
    {
        // Объявляем делегат
        public delegate void FullImageStateHandler(string message);
        public delegate void FullImageshareStateHandler(string message, int imageIndex);
        // Событие, возникающее при смене папки
        public event FullImageStateHandler SaveFolderChanged;
        public event FullImageshareStateHandler KeyPressed;
        int lastX, lastY;
        private string url, fileName, imageFormat;
        private SaveFileDialog saveFileDialog;
        private string lastSaveFolderPath;
        private int imageIndex;

        public FullImageForm(string imageUrl, string fileName, string lastSaveFolderPath, int imageIndex)
        {
            InitializeComponent();
            this.lastSaveFolderPath = lastSaveFolderPath;
            imageFormat = ".jpg";
            pictureBox1.LoadAsync(imageUrl);
            url = imageUrl;
            this.fileName = fileName;
            this.imageIndex = imageIndex;
            Rectangle sS = System.Windows.Forms.Screen.PrimaryScreen.Bounds;
            this.Width = (int)(sS.Width / 1.11);
            this.Height = (int)(sS.Height / 1.11);
            panel1.Location = new Point(4, 4);
            panel1.Width = this.Width - 8;
            panel1.Height = this.Height - 8;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.BackColor = Color.Thistle;
            pictureBox1.SizeMode = ((PictureBoxSizeMode)Properties.Settings.Default["FullImageSizeMode"]);

            if (((PictureBoxSizeMode)Properties.Settings.Default["FullImageSizeMode"]) == PictureBoxSizeMode.Zoom) //процент от экрана
            {
                pictureBox1.Width = this.Width - 8;
                pictureBox1.Height = this.Height - 8;
            }
        }

        private void PictureBox_MouseLeave(object sender, EventArgs e) { MouseEventArgs me = (MouseEventArgs)e; if (me.Button == MouseButtons.Right) this.Close(); }

        private void PictureBox1_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                if (url.IndexOf(".jpg") != -1)
                {
                    url = url.Replace(".jpg", ".png");
                    pictureBox1.LoadAsync(url);
                    imageFormat = ".png";
                }
                else if(url.IndexOf(".png") != -1)
                {
                    url = url.Replace(".png", ".gif");
                    pictureBox1.LoadAsync(url);
                    imageFormat = ".gif";
                }
                else
                {
                    url = url.Replace(".gif", ".jpeg");
                    pictureBox1.LoadAsync(url);
                    imageFormat = ".jpeg";
                }
            }
            if (((PictureBox)sender).Image != ((PictureBox)sender).InitialImage)
            {
                this.WindowState = FormWindowState.Normal;
                this.Focus();
            }
        }

        private void FullImageForm_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Right:
                    KeyPressed("next", imageIndex);
                    break;
                case Keys.Left:
                    KeyPressed("prew", imageIndex);
                    break;
            }
        }

        private void PictureBox1_DoubleClick(object sender, EventArgs e)
        {
            saveFileDialog = new SaveFileDialog
            {
                InitialDirectory = lastSaveFolderPath,
                FileName = fileName + imageFormat
            };
            saveFileDialog.FileOk += new CancelEventHandler(SaveFileDialog_FileOk);
            saveFileDialog.ShowDialog();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && pictureBox1.SizeMode == PictureBoxSizeMode.AutoSize)
            {
                if(panel1.HorizontalScroll.Value + e.X - lastX < 0) panel1.HorizontalScroll.Value = 0;
                else if (panel1.HorizontalScroll.Value + e.X - lastX > panel1.HorizontalScroll.Maximum) panel1.HorizontalScroll.Value = panel1.HorizontalScroll.Maximum;
                else panel1.HorizontalScroll.Value += (e.X - lastX);

                if (panel1.VerticalScroll.Value + e.Y - lastY < 0) panel1.VerticalScroll.Value = 0;
                else if (panel1.VerticalScroll.Value + e.Y - lastY > panel1.VerticalScroll.Maximum) panel1.VerticalScroll.Value = panel1.VerticalScroll.Maximum;
                else panel1.VerticalScroll.Value += (e.Y - lastY);
            }
            lastX = e.X;
            lastY = e.Y;
        }

        private void SaveFileDialog_FileOk(object sender, EventArgs e)
        {
            SaveFolderChanged(saveFileDialog.FileName.Replace(fileName + imageFormat, ""));
            pictureBox1.Image.Save(saveFileDialog.FileName);
        }

        public void loadImage(string imageUrl, int imageIndex)
        {
            this.imageIndex = imageIndex;
            url = imageUrl;
            imageFormat = ".jpg";
            pictureBox1.LoadAsync(imageUrl);
        }
    }
}
