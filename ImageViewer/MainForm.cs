﻿using System;
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
                Bmp image = new Bmp(opnFileImage.FileName,
                    System.IO.Path.GetFileName(opnFileImage.FileName));
            }
        }
    }
}
