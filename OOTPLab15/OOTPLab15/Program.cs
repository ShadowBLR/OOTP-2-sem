using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OOTPLab15
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Process[] proc = Process.GetProcesses();
                foreach (var p in proc)
                {
                    Console.WriteLine("Name:" + p.ProcessName);
                    Console.WriteLine("ID:" + p.Id);
                    Console.WriteLine("Priority" + p.BasePriority);
                    // Console.WriteLine(p.StartTime);
                    // Console.WriteLine(p.Modules);
                    Console.WriteLine(p.Threads);

                }
                Console.WriteLine("\nCurrent domain: ");
                AppDomain domain = AppDomain.CurrentDomain;
                Console.WriteLine("Name: " + domain.FriendlyName + "\nConfiguration: " + domain.SetupInformation);
                Console.WriteLine("Assemblies of current domain: ");
                Assembly[] assembly = domain.GetAssemblies();
                foreach (Assembly ass in assembly)
                {
                    Console.WriteLine(ass.GetName().Name);
                }
                AppDomain domain2 = AppDomain.CreateDomain("Second domain");
                string assemblyPath = @"C:\Users\User\source\repos\OOTPLab15\Assembly\bin\Debug\" + "Assembly.exe";
                domain2.ExecuteAssembly(assemblyPath);
                AppDomain.Unload(domain2);

                //======================TASK 3 ===========================
                Console.WriteLine("\nPrime number: ");
                Thread thread = new Thread(NumberWriter);
                thread.Start();
                Console.WriteLine("Thread №1 is " + thread.ThreadState);
                thread.Name = "Write numbers in file and console";
                Console.WriteLine("Name: " + thread.Name + "\nPriority: " + thread.Priority + "\nStatus: " + thread.ThreadState + "\nId: " + thread.ManagedThreadId);
                thread.Join();


                Console.WriteLine("\n\nEven and Odd");
                ThreadHandler thrhan = new ThreadHandler(10);
                thrhan.myThread.Start();
                thrhan.myThread.Join();
                thrhan.myThread1.Start();
                thrhan.myThread1.Join();
                Console.WriteLine();

                ThreadHandler thrhan1 = new ThreadHandler(10);
                thrhan1.myThread.Start();
                thrhan1.myThread1.Start();
                thrhan1.myThread.Join();
                thrhan1.myThread1.Join();
                Console.WriteLine();

                //bool flag = false;
                int num = 10;
                TimerCallback tm = new TimerCallback(thrhan.Count);
                Timer timer = new Timer(tm, num, 150, 1000);
               /* Thread th = new Thread(x=>
                {
                    while(flag==false)
                    {
                        Console.WriteLine("false flag");
                        Thread.Sleep(500);
                    }
                });
                th.Start();*/
                Thread.Sleep(5000);
                //flag = true;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void NumberWriter()
        {
            try
            {
                Console.WriteLine("\nGet in count of numbers");
                int m = Convert.ToInt32(Console.ReadLine());
                int[] arr = new int[m];
                int s = 0, k;
                arr[s++] = 1;
                for (int i = 2; i <= m; i++)
                {
                    k = 0;
                    for (int j = 2; j <= i; j++)
                    {
                        if (i % j == 0)
                        {
                            k += 1;
                        }
                    }
                    if (k == 1)
                    {
                        arr[s++] = i;
                    }
                }
                for (int i = 0; i < s; i++)
                {
                    Console.WriteLine(arr[i] + " ");
                    using (StreamWriter file = new StreamWriter("Info.txt", true, System.Text.Encoding.Default))
                    {
                        file.WriteLine(arr[i] + " ");
                    }
                    Console.Write(arr[i] + " ");
                    Console.WriteLine("Write in File");
                    Thread.Sleep(100);
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
