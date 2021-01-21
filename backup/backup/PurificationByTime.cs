using System;
using System.Collections.Generic;
using System.Text;

namespace backup
{
    public class PurificationByTime : IRemovPoint
    {
        public DateTime TimeLimit;
        public PurificationByTime(DateTime date)
        {
            TimeLimit = date;
        }
        public int RemovePoint(Backup backup)
        {
            int count = 0;
            foreach (var item in backup.points)
            {
                if (item.DTime < TimeLimit)
                    count++;
            }
            return count;
        }
    }
}
