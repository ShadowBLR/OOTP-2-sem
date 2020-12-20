using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OOTPLab15
{
    public class ThreadHandler
    {
        public Thread myThread;
        public Thread myThread1;
        public int Num { get; set; }
        public ThreadHandler(int num)
        {
            myThread = new Thread(this.Even);
            myThread1 = new Thread(new ThreadStart(this.Odd)) { Priority = ThreadPriority.AboveNormal };
            Num = num;
        }
        public void Count(object obj)
        {
            Console.WriteLine("Таймер истек");
            int x = (int)obj;
            for (int i = 1; i < 4; i++, x++)
            {
                Console.WriteLine(x * i);
            }
           
        }

        public void Even()
        {
            for (int i = 0; i < Num; i++)
            {
                if (i % 2 == 0)
                {
                    Console.Write(i + " ");
                }
                Thread.Sleep(200);
            }
        }
        public void Odd()
        {
            for (int i = 0; i < Num; i++)
            {
                if (i % 2 != 0)
                {
                    Console.Write(i + " ");
                }
                Thread.Sleep(200);
            }
        }
    }
}
