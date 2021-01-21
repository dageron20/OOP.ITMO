using System;
using System.Collections.Generic;
using System.Text;

namespace backup
{
    public class RestorePoint
    {
        public List<File> Files = new List<File>();
        public long PointSize;
        public DateTime DTime;
        public static int PointID = 0;
        int id;
        public RestorePoint(List<File> files)
        {
            Files.AddRange(files);
            foreach(var item in files)
                PointSize += item.Size;
            DTime = DateTime.Now;
            id = PointID;
            PointID++;
        }
    }
}
