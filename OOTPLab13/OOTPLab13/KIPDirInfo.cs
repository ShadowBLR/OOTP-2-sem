using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOTPLab13
{
    class KIPDirInfo
    {
        public void DirInfo(string dirName)
        {
            Console.WriteLine("DirInfo");
            if (Directory.Exists(dirName))
            {
                string[] files = Directory.GetFiles(dirName);
                
                Console.WriteLine($"\tCountOfFiles: {files.Length}");

                Console.WriteLine($"\tCreationTime:{Directory.GetCreationTime(dirName)}");
                string[] dirs = Directory.GetDirectories(dirName);
  
                Console.WriteLine($"\tCountOfSubDirectories: {dirs.Length}");

                Console.WriteLine($"\tParents: {Directory.GetParent(dirName)}");
            }
            else
            {
                Console.WriteLine($"This directory doesn't exists");
            }
        }
    }
}
