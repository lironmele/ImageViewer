using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageViewer
{
    class Bmp
    {
        string Path;
        string Name;
        bool BmHeader;
        public Bmp(string path, string name)
        {
            Path = path;
            Name = name;
            BmHeader = GetConfirmation();
        }
        public bool GetConfirmation()
        {
            string head;
            using (FileStream stream = new FileStream(Path, FileMode.Open, FileAccess.Read))
            {
                byte[] bytes = new byte[2];
                stream.Read(bytes, 0, 2);
                head = Encoding.Default.GetString(bytes);
            }

            if (head == "BM") { return true; }
            else { return false; }
        }
    }
}
