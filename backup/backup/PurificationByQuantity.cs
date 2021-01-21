using System;
using System.Collections.Generic;
using System.Text;

namespace backup
{
    public class PurificationByQuantity : IRemovPoint
    {
        public int QuantityLimit;
        public PurificationByQuantity(int quantityremove)
        {
            QuantityLimit = quantityremove;
        }

        public int RemovePoint(Backup backup)
        {
            int count = 0;
            while (  (backup.points.Count - count) != QuantityLimit  )
            {
                count++;
            }
            return count;
        }
    }
}
