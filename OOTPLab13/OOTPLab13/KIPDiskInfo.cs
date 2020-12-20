using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOTPLab13
{
    class KIPDiskInfo
    {
        public void DiskInfo()
        {
            Console.WriteLine("DiskInfo");
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
            {
                Console.WriteLine($"\tName:{drive.Name}");
                Console.WriteLine($"\tType:{drive.DriveType}");

                if (drive.IsReady)
                {
                    Console.WriteLine($"\tFormat:{drive.DriveFormat}");
                    Console.WriteLine($"\tFreeSpace: available - {drive.AvailableFreeSpace / 1024 / 1024} MB, total - {drive.TotalFreeSpace / 1024 / 1024} MB");
                    Console.WriteLine($"\tCapacity: {drive.TotalSize / 1024 / 1024 / 1024} GB");
                }
                Console.WriteLine();
            }
        }
    }
}
