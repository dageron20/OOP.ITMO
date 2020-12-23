using System;
using System.IO;

namespace backup
{
    class Program
    {
        static void Main(string[] args)
        {
            string path1 = @"E:\first.txt";
            string path2 = @"E:\too.txt";
            string path3 = @"E:\three.txt";
            string path4 = @"E:\TestRestore.txt";

            File f1 = new File(path1);
            File f2 = new File(path2);
            File f3 = new File(path3);


            Backup firstBack = new Backup();
            firstBack.AddFile(f1);
            firstBack.AddFile(f2);
            firstBack.AddFile(f3);

            firstBack.CreateRPoint();

            File f4 = new File(path4);
            firstBack.AddFile(f4);

            firstBack.CreateIPoint();

            LimitGibForRemove lim = new LimitGibForRemove();
            //lim.PushLimit(new PurificationByQuantity(1));
            lim.PushLimit(new PurificationBySize(10));
            lim.ValueForGibridMax(true);
            lim.GibridClear(firstBack);
        }
    }
}
