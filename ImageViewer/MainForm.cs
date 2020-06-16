using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ImageViewer
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        private void btnChooseFile_Click(object sender, EventArgs e)
        {
            if (opnFileImage.ShowDialog() == DialogResult.OK)
            {
                Bitmap bmp;
                switch (Path.GetExtension(opnFileImage.FileName))
                {
                    case ".bmp":
                        Bmp image = new Bmp(opnFileImage.FileName, Path.GetFileName(opnFileImage.FileName));
                        if (!image.GetConfirmation())
                        {
                            MessageBox.Show("Image file is corrupted! Please try a different file.");
                            return;
                        }
                        bmp = image.GetBitmap();
                        break;
                    default:
                        bmp = null;
                        break;
                }
                if (bmp != null)
                    new ImageForm(bmp).ShowDialog();
            }
        }
    }
}
