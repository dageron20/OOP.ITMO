using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace backup
{
    class File
    {
        public DateTime Date;
        public DateTime LastWriteDate;
        public long Size;
        public string Name;
        public File(string path)
        {
            FileInfo fileinf = new FileInfo(path);
            Size = fileinf.Length;
            Date = fileinf.CreationTime;
            LastWriteDate = fileinf.LastWriteTime;
            Name = fileinf.Name;
        }

    }
}
