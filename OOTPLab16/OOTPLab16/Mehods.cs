using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OOTPLab16
{
    class Methods
    {
        public static void ParallelFor()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Parallel.For(0, 100000, Generate);
            sw.Stop();
            Console.WriteLine("Затраченное время //параллельный for:"+sw.ElapsedMilliseconds);
        }
        public static void NotParallelFor()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < 100000; i++)
            {
                Generate(i);
            }
            sw.Stop();
            Console.WriteLine("Затраченное время //for:" + sw.ElapsedMilliseconds);
        }
        public static void NotParallelForEach()
        {
            Stopwatch sw = new Stopwatch();
            int []arr = new int [1000];
            sw.Start();
            foreach(var a in arr)
            {
                Generate(1000000);
            }
            sw.Stop();
            Console.WriteLine("Затраченное время //forEach:" + sw.ElapsedMilliseconds);
        }
        public static void ParallelForEach()
        {
            Stopwatch sw = new Stopwatch();
            int[] arr = new int[1000];
            sw.Start();
            Parallel.ForEach(arr, Generate);
            sw.Stop();
            Console.WriteLine("Затраченное время //параллельный forEach:" + sw.ElapsedMilliseconds);
        }

        public static void Generate(int n)
            {
                 int[] arr = new int[n];
            }
    }
}
