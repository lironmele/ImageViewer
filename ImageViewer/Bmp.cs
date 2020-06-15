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
        public Bmp(string path, string name)
        {
            Path = path;
            Name = name;
            bytes = File.ReadAllBytes(path);
            dimensions = GetDimensions();
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
            if (dimensions[0] % 4 == 0) { return 0; }
            else { return 4 - dimensions[0] % 4; }
        }
    }
}
