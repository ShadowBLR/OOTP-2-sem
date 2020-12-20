using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOTPLab13
{
    class KIPFileInfo
    {
        public void FileData(string path)
        {
            Console.WriteLine("FileInfo");
            FileInfo fileInf = new FileInfo(path);
            if (fileInf.Exists)
            {
                Console.WriteLine($"\tAll way : {fileInf.DirectoryName}");
                Console.WriteLine($"\tExtention : {fileInf.Extension}");
                Console.WriteLine($"\tsize:{fileInf.Length}");
                Console.WriteLine($"\tName: {fileInf.Name}");
                Console.WriteLine($"\tTime creation: {fileInf.CreationTime}");
                Console.WriteLine($"\tTime redaction: {fileInf.LastWriteTime}");
                
            }
            else
            {
                Console.WriteLine("This file doesn't exists");
            }
        }
    }
}
