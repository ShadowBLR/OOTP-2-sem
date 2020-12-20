using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOTPLab13
{
    class Program
    {
        static void Main(string[] args)
        {
            KIPLog kiplog = new KIPLog();
            //kiplog.RemoveLog();
            kiplog.Search(@"C:\Users\User\source\repos\OOTPLab13\OOTPLab13\bin\Debug");

            KIPDirInfo kipdir = new KIPDirInfo();
            kipdir.DirInfo(@"C:\Users\User\source\repos\OOTPLab13\OOTPLab13");

            KIPDiskInfo kipdisk = new KIPDiskInfo();
            kipdisk.DiskInfo();

            KIPFileInfo kipfile = new KIPFileInfo();
            kipfile.FileData(@"C:\Users\User\Desktop\temp\текст.txt");

            KIPFileManager kipmanager = new KIPFileManager();
           string payh= kipmanager.CreateDirectory("katalog");
           kipmanager.CopyTo(payh, @"C:\Users\User\source\repos\OOTPLab13\OOTPLab13\bin\Debug");
            kipmanager.CopyAllFiless(@"C:\Users\User\source\repos\OOTPLab13\OOTPLab13\bin\Debug");
            kipmanager.CreateArchive(@"C:\Users\User\source\repos\OOTPLab13\OOTPLab13\bin\Debug");
        }
    }
}
