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
        public Bmp(string path, string name)
        {
            Path = path;
            Name = name;
        }
        public bool GetConfirmation()
        {
            string head;
            using (FileStream stream = new FileStream(Path, FileMode.Open, FileAccess.Read))
            {
                byte[] bytes = new byte[3];
                stream.Read(bytes, 0, 3);
                head = Encoding.Default.GetString(bytes);
                MessageBox.Show(head);
            }

            if (head == "BMP") { return true; }
            else { return false; }
        }
    }
}
