using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageViewer
{
    public partial class ImageForm : Form
    {
        Bitmap bmp;
        public ImageForm(Bitmap bmp)
        {
            this.bmp = bmp;
            InitializeComponent();
        }

        private void ImageForm_Load(object sender, EventArgs e)
        {
            Size = new Size(bmp.Width, bmp.Height);
            picImage.Size = Size;
            picImage.Image = bmp;
        }
    }
}
