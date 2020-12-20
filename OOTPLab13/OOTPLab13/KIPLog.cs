using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOTPLab13
{
    class KIPLog
    {
        FileSystemWatcher fsw;
        public void Search(string path)
        {
            using (StreamWriter sw = new StreamWriter(@"C:\Users\User\source\repos\OOTPLab13\OOTPLab13\KIPlogfile.txt", false, System.Text.Encoding.Default))
            {

            }

            fsw= new FileSystemWatcher(path);
            fsw.Changed += OnChanged;
            fsw.Created += OnChanged;
            fsw.Renamed += OnRenamed;
            fsw.Deleted += OnChanged;
            fsw.EnableRaisingEvents = true;
        }
        public static void OnChanged(object source, FileSystemEventArgs e)
        {
            using (StreamWriter sw = new StreamWriter(@"C:\Users\User\source\repos\OOTPLab13\OOTPLab13\KIPlogfile.txt", true, Encoding.Default))
            {
                sw.WriteLine(DateTime.Now);
                sw.WriteLine($"File: {e.FullPath} {e.ChangeType}");
            }

        }
        public static void OnRenamed(object source, RenamedEventArgs e)
        {
            using (StreamWriter sw = new StreamWriter(@"C:\Users\User\source\repos\OOTPLab13\OOTPLab13\KIPlogfile.txt", true, Encoding.Default))
            {
                sw.WriteLine(DateTime.Now);
                sw.WriteLine($"File: {e.OldFullPath} renamed to {e.FullPath}");
            }
        }
        public void RemoveLog()
        {
            string result="";
            DateTime current = DateTime.Now;
            using (StreamReader sw = new StreamReader(@"C:\Users\User\source\repos\OOTPLab13\OOTPLab13\KIPlogfile.txt"))
            {
                while (!sw.EndOfStream)
                { 
                    string[] buf = sw.ReadLine().Split(new char[] { '.', ':', ' ' });
                    DateTime bfdt = new DateTime(Convert.ToInt32(buf[2]), Convert.ToInt32(buf[1]),
                        Convert.ToInt32(buf[0]), Convert.ToInt32(buf[3]),
                        Convert.ToInt32(buf[4]), Convert.ToInt32(buf[5]));
                    if(current.Year==bfdt.Year&&
                        current.Month==bfdt.Month&&
                        current.Day==bfdt.Day)
                    {
                        switch(current.Hour-bfdt.Hour)
                        {
                            
                            case 0 :
                                result += bfdt+"\n";
                                result += sw.ReadLine() + "\n";
                                break;
                            case 1:if (current.Minute < bfdt.Minute)
                                {
                                    result += bfdt + "\n";
                                    result += sw.ReadLine() + "\n";
                                }
                                else
                                {
                                    sw.ReadLine();
                                }
                                break;
                            default:
                                sw.ReadLine();
                                break;
                        }
                    }
                    else
                    {
                        sw.ReadLine();
                    }
                }
            }
            using(StreamWriter sw = new StreamWriter(@"C:\Users\User\source\repos\OOTPLab13\OOTPLab13\KIPlogfile.txt",false,Encoding.Default))
            {
               string[]temp= result.Split('\n');
                foreach(string s in temp)
                {
                    sw.WriteLine(s);
                }
            }
        }
    }
}
