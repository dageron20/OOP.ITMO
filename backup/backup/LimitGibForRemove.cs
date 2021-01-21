using System;
using System.Collections.Generic;
using System.Text;

namespace backup
{
    public class LimitGibForRemove 
    {
        public List<IRemovPoint> Limits;
        public bool MinValue = false;
        public bool MaxValue = true;
        public LimitGibForRemove()
        {
            Limits = new List<IRemovPoint>();
        }
        public void PushLimit(IRemovPoint remov)
        {
            Limits.Add(remov);
        }   
        public void ValueForGibridMax(bool max)
        {
            if (max)
            {
                MinValue = false;
                MaxValue = true;
            }
            else
            {
                MinValue = true;
                MaxValue = false;
            }
        }
        public void GibridClear(Backup backup)
        {
            int count = 0;
            if(MaxValue)
                foreach (var item in Limits)
                {
                    count = Math.Max(count, item.RemovePoint(backup));
                }            
            else
            {
                count = backup.points.Count;
                foreach (var item in Limits)
                count = Math.Min(count, item.RemovePoint(backup));
            }
            backup.points.RemoveRange(0, count);
        }
    }
}
