using System;
using System.Collections.Generic;
using System.Text;

namespace backup
{
    public class PurificationBySize : IRemovPoint
    {
        public long SizeLimit;
        public PurificationBySize(long maxmemory)
        {
            SizeLimit = maxmemory;
        }
        public int RemovePoint(Backup backup)
        {
            int count = 0;
            foreach (var item in backup.points)
            {
                backup.SizeAllPoints += item.PointSize;
            }
            while (backup.SizeAllPoints > SizeLimit)
            {
                backup.SizeAllPoints -= backup.points[0].PointSize;
                count++;
            }
            return count;
        }
    }
}
