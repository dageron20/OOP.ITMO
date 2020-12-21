﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using static backup.BackupExceptions;

namespace backup
{
    class Backup
    {
        public DateTime Date;
        public List<File> files;
        public List<RestorePoint> points = new List<RestorePoint>();
        public long SizeFiles;
        public long SizeAllPoints;
        public static int BackupID = 0;
        int id;
        public Backup()
        {
            SizeFiles = 0;
            files = new List<File>();
            Date = DateTime.Now;
            id = BackupID;
            BackupID++;
        }
        public void AddFile(File file)
        {
            files.Add(file);
            SizeFiles += file.Size;
        }
        public void RemoveFileBackup(File file)
        {
            files.Remove(file);
            SizeFiles -= file.Size;
        }
        public string ShowFileBackup(File file)
        {
            if (files.Contains(file))
                foreach (var item in files)
                {
                    if (item == file)
                        return item.Name;
                }
            else              
                throw new FileNotExist("File not found");
            return null;
        }
        public void CreateRPoint()
        {
            points.Add(new RestorePoint(files));
        }
        public void CreateIPoint()
        {
            List<File> IPoint = new List<File>(files);
            foreach (var item in points.Last().Files)
            {
                foreach(var jtem in files)
                {
                    if (item.Name == jtem.Name && item.LastWriteDate == jtem.LastWriteDate)
                        IPoint.Remove(jtem);                                   
                }
            }
            if (IPoint.Count != 0)
                points.Add(new RestorePoint(IPoint));
            else
                throw new ImposibleAddInc("List is empty");
        }
        public void PurificationByQuantity(int number)
        {
            while(points.Count != number)
            {               
                points.RemoveAt(0);
            }
        }
        public void PurificationBySize(long numSize)
        {
            foreach(var item in points)
            {
                SizeAllPoints += item.PointSize;
            }
            while(SizeAllPoints > numSize )
            {
                SizeAllPoints -= points[0].PointSize;
                files.RemoveAt(0);
            }
        }
        public void PurificationByTime(DateTime date)
        {
            foreach(var item in points)
            {
                if (item.DTime < date)
                    points.RemoveAt(points.IndexOf(item));
            }
        }
    }
}
