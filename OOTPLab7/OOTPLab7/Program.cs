using OOTPLab7;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOTPLab07
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                try
                {
                    PrintEdition pe = new PrintEdition();
                      //              throw new FileNotFoundException();
//pe.YearOfPublishing = -100;
                   // int varNull = 0;
                   // Debug.Assert(varNull!=0,"возможно деление на ноль");
                  //  int[] arr = new int[1];
                //    _ = arr[2];
                  //  varNull = 18 / varNull;
                }
                catch (IndexOutOfRangeException ex)
                {
                    Console.WriteLine("Лееее, куда прешь?За границы вышел");
                    throw;
                }
                catch(DivideByZeroException ex)
                {
                    Console.WriteLine("Разделил на нуль.Будь аккуратнее в следующий раз, иначе его может и не быть");
                    throw;
                }
                finally
                {
                    Console.WriteLine("finally");
                    //очистка ресурсов
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Не finally");
                Logger.Log("log.txt", ex);
                Logger.Log(ex);
            }
            finally
            {
                Console.WriteLine("finally выполнится в любом случае");
            }
        }
    }
}
