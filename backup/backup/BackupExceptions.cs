using System;
using System.Collections.Generic;
using System.Text;

namespace backup
{
    class BackupExceptions : System.Exception
    {
        public BackupExceptions(string message) : base(message) { }

        public class FileNotExist : BackupExceptions
        {
            public FileNotExist(string message)
                : base("Error. File was not found") { }
        }
        public class UnknownFileDeletion : BackupExceptions
        {
            public UnknownFileDeletion(string message)
                : base("The file you want to delete was not found.") { }
        }
        public class ImposibleAddInc : BackupExceptions
        {
            public ImposibleAddInc(string message)
                : base("Unable to create an increment, no source data.") { }
        }
    }
}
