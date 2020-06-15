using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageViewer
{
    class Bmp
    {
        public string Path { get; }
        public string Name { get; }
        byte[] bytes { get; }
        int[] dimensions { get; }
        Color[] pixels { get; }
        public Bmp(string path, string name)
        {
            Path = path;
            Name = name;
            bytes = File.ReadAllBytes(path);
            dimensions = GetDimensions();
            pixels = GetPixelData();
        }
        public bool GetConfirmation()
        {
            string head = Encoding.Default.GetString(bytes, 0, 2);
            if (head == "BM") { return true; }
            else { return false; }
        }
        public int GetFileSize() { return BitConverter.ToInt32(bytes, 2); }
        public int GetOffSet() { return BitConverter.ToInt32(bytes, 10); }
        public int GetDIBHeader() { return BitConverter.ToInt32(bytes, 14); }
        public int[] GetDimensions() { return new int[] { BitConverter.ToInt32(bytes, 18), BitConverter.ToInt32(bytes, 22) }; }
        public int GetPadding()
        {
            if ((dimensions[0] * 3) % 4 == 0) { return 0; }
            else { return 4 - (dimensions[0] * 3) % 4; }
        }
        public Color[] GetPixelData()
        {
            Color[] pixels = new Color[dimensions[0] * dimensions[1]];
            int i = 0;
            for (int row = GetOffSet() + (dimensions[0] * 3 + GetPadding()) * (dimensions[1] - 1); row > GetOffSet() - 1; row -= (dimensions[0] * 3 + GetPadding()))
                for (int col = 0; col < dimensions[0] * 3; col += 3)
                {
                    pixels[i++] = Color.FromArgb(bytes[row + col + 2], bytes[row + col + 1], bytes[row + col]);
                }
            return pixels;
        }
        public Bitmap GetBitmap()
        {
            Bitmap bmp = new Bitmap(dimensions[0], dimensions[1]);
            for (int y = 0; y < dimensions[1]; y++)
                for (int x = 0; x < dimensions[0]; x++)
                    bmp.SetPixel(x, y, pixels[x + y * dimensions[1]]);
            return bmp;
        }
    }
}
