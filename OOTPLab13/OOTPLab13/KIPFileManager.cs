using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOTPLab13
{
   public class KIPFileManager
    {
        public string Path { get; set; } = @"C:\\";
        public KIPFileManager() { }
        public KIPFileManager(string path) { Path = path; }
        public void GetDirectoryInfo(string path)
        {
            if (Directory.Exists(Path))
            {
                Console.WriteLine("Subdir:");
                string []dirs = Directory.GetDirectories(Path);
                foreach(string s in dirs)
                {
                    Console.WriteLine(s);
                }
                Console.WriteLine();
                Console.WriteLine("Files");
                string[] files = Directory.GetFiles(Path);
                foreach (var f in files)
                {
                    Console.WriteLine(f);
                }
                Console.WriteLine();
            }
        }
        public string CreateDirectory(string pathDirectory,string fileName=@"\\KIPdirinfo.txt")
        {
           DirectoryInfo dirinfo= Directory.CreateDirectory(pathDirectory);
        
            using (StreamWriter sw = new StreamWriter(dirinfo.FullName+"\\"+fileName))
            {
                sw.WriteLine("Some text");
            }
            return dirinfo.FullName;
        }
        public void CopyTo(string pathDirectory, string newPath)
        {
            FileInfo fileinfo = new FileInfo(pathDirectory + "\\KIPdirinfo.txt");
            fileinfo.CopyTo(pathDirectory + ".txt", true);
            fileinfo.Delete();
        }
        public void CopyAllFiless(string path)
        {
            string filecopydir;
            DirectoryInfo dInfo = new DirectoryInfo(filecopydir = path + @"\\KIPFiles");
            dInfo.Create();
            string[] files2 = Directory.GetFiles(path);
            foreach (string s in files2)
            {
                    File.Copy(s, filecopydir + "\\" + new FileInfo(s).Name);    
            }
        }
        public  void CreateArchive(string directory)
        { 
            ZipFile.CreateFromDirectory(directory+ @"\\KIPFiles", "archiv.zip");
            
            using (ZipArchive zip = ZipFile.OpenRead(directory+ "\\archiv.zip"))
            {
                foreach(ZipArchiveEntry entry in zip.Entries)
                {
                    Console.WriteLine(entry.FullName);
                }
            }

            ZipFile.ExtractToDirectory(directory + "\\archiv.zip", @"C:\Users\User\source\repos\OOTPLab13\OOTPLab13\bin");

        }

    }
}
