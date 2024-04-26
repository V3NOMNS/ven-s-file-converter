using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Ven_s_File_Converter_V1._2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg; *.jpeg; *.png; *.bmp)|*.jpg; *.jpeg; *.png; *.bmp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pictureBox1.Image = new System.Drawing.Bitmap(openFileDialog.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading image: " + ex.Message);
                }
            }
        }

        private void download_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    pictureBox1.Image.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);

                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "PNG Files (*.png)|*.png";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        using (FileStream fileStream = new FileStream(saveFileDialog.FileName, FileMode.Create))
                        {
                            memoryStream.WriteTo(fileStream);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No image to download.");
            }
        }
    }
}
