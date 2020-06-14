using System;
using System.Collections.Generic;
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
        public bool BmHeader { get; }
        public int Size { get; }
        public Bmp(string path, string name)
        {
            Path = path;
            Name = name;
            bytes = File.ReadAllBytes(path);
        }
        public bool GetConfirmation()
        {
            string head = Encoding.Default.GetString(bytes, 0, 2);
            if (head == "BM") { return true; }
            else { return false; }
        }
        public int GetFileSize()
        {
            int size;
            using (FileStream stream = new FileStream(Path, FileMode.Open, FileAccess.Read))
            {
                byte[] bytes = new byte[2 + 4];
                stream.Read(bytes, 2, 4);
                size = BitConverter.ToInt32(bytes, 0);
            }
            size = BitConverter.ToInt32(bytes, 2);
            MessageBox.Show(size.ToString());
            return size;
        }
    }
}
