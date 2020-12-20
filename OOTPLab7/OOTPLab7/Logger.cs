using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace OOTPLab7
{
    public static class Logger
    {
        public static DateTime date;
       public static string Message { get; set; }
        public static void Log(string fileName,Exception ex)
        {
            date = DateTime.Now;
            byte[] array = Encoding.Default.GetBytes(@$"Результат работы логгера
Текущее время:{date}
сообщение:{ex.Message}
кадр стеков вызова:{ex.StackTrace}
метод,создавший исключение:{ex.TargetSite}");
            FileStream File = new FileStream(fileName,FileMode.OpenOrCreate);
            if (File == null)
                throw new FileNotFoundException();
            File.Write(array,0,array.Length);
            File.Close();
        }
        public static void Log(Exception ex)
        {
            Console.WriteLine(@$"Результат работы логгера
Текущее время:{date}
сообщение:{ex.Message}
кадр стеков вызова:{ex.StackTrace}
метод,создавший исключение:{ex.TargetSite}");
        }
    }
}
