using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OOTPLab16
{
    class Program
    {
        public static async void AsyncFactorial(int n)
        {
            Console.WriteLine("Async invoke");
            await Task.Run(()=>Factorial(n));
            Console.WriteLine("Async end");
        }
        public static int Factorial(int x)
        {
            int result = 1;
            
                for (int i = 1; i <= x; i++)
                {
                    result *= i;
                }
            Thread.Sleep(6000);
            Console.WriteLine("factorial:" + result);
            return result;

        }
        public static  async Task<int> FactInvoke(int n)
        {
            return await Task.Run(() => Factorial(n));
        }
        static void Main(string[] args)
        {
            int result = 1;
            AsyncFactorial(15);
            int x = 15;

            for (int j = 0; j < 5; j++)
            {
                Stopwatch stopw = new Stopwatch();
                stopw.Start();
                Task taskOne = Task.Run(() =>
                {
                    int[] arr = new int[100000];
                    Random rnd = new Random();
                    for (int i = 0; i < arr.Length; i++)
                    {
                        arr[i] = rnd.Next() / 500;
                    }
                    for (int i = 0; i < arr.Length; i++)
                    {
                        arr[i] *= 500;
                    }
                });
                Task.WaitAll(taskOne);
                stopw.Stop();
                Console.WriteLine($"Count tick:{ stopw.ElapsedTicks}");
                Console.WriteLine($"isComplited{taskOne.IsCompleted}");
                Console.WriteLine($"ID:{taskOne.Id}");
                Console.WriteLine($"{taskOne.Status}");
            }
            Task taskTwo = Task.Run(() =>
            {
                int[] arr = new int[100000];
                Random rnd = new Random();
                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i] = rnd.Next() / 500;
                }
                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i] *= 500;
                }

            });

            CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
            CancellationToken token = cancelTokenSource.Token;
            cancelTokenSource.Cancel();
            if (token.IsCancellationRequested)
            {
                Console.WriteLine("Есть запрос на остановление");
                Console.WriteLine($"IsCancelationRequested:{cancelTokenSource.IsCancellationRequested}");
            }
            int iii = FactInvoke(13).GetAwaiter().GetResult();
            Task taskThree = Task.Run(() =>
            {
                int res=0;
                res +=  FactInvoke(10).Result;
                Console.WriteLine(res);
                res += FactInvoke(15).Result;
                Console.WriteLine(res);
                res += FactInvoke(20).Result;
                
                Console.WriteLine(res);
            });

            //==============CONTINUE_WITH=================
            Task task1 = new Task(() => {
                Console.WriteLine($"Id задачи: {Task.CurrentId}");
            });

            // задача продолжения
            Task task2 = task1.ContinueWith(Display);

            task1.Start();

            // ждем окончания второй задачи
            task2.Wait();
            Console.WriteLine("Выполняется работа метода Main");
            Console.ReadLine();
            try
            {
                stock = new BlockingCollection<string>();

                Task tsk1 = new Task(startBuyer);
                Task tsk2 = new Task(startProvider);
                tsk2.Start();
                tsk1.Start();
                Task.WaitAll(task1, task2);
                Thread.Sleep(4000);
                Methods.NotParallelFor();
                Methods.ParallelFor();
                Methods.NotParallelForEach();
                Methods.ParallelForEach();
                Parallel.Invoke(Display, () => Console.WriteLine("2 method invoke"));
                Thread.Sleep(3000);
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
      
        public static void Display(Task t)
        {
            Console.WriteLine($"Id задачи: {Task.CurrentId}");
            Console.WriteLine($"Id предыдущей задачи: {t.Id}");
            Thread.Sleep(3000);
        }
        public static void Display()
        {
            Console.WriteLine("Diaplay invoke");
        }
        static bool b = false;
        static BlockingCollection<string> stock;
        public static void startBuyer()
        {
            var mans = new[]
            {
                new Buyer("Max"),
                new Buyer("Andrey"),
                new Buyer("Anton"),
                new Buyer("Diana"),
                new Buyer("Vadim"),
                new Buyer("Katya"),
                new Buyer("Dasha"),
                new Buyer("Danil"),
                new Buyer("Nikita"),
                new Buyer("Julia")
            };


            while (!stock.IsCompleted)
            {
                foreach (var i in mans)
                {
                    i.Take(stock,b);
                }

            }
            Console.WriteLine("Товар закончен");
        }
        public static void startProvider()
        {
            var providers = new[]
            {
                new Provider("First Provider", 500),
                new Provider("Second Provider", 1100),
                new Provider("Third Provider", 300),
                new Provider("Fourth Provider", 100),
                new Provider("Fiveth Provider", 760)
            };

            for (int i = 0; i < 10;)
            {
                foreach (var prov in providers)
                {
                    if (i == 5)
                    { b = true; break; }
                    Thread.Sleep(prov.Speed);
                    prov.Add(stock);
                    i++;

                }

            }
            stock.CompleteAdding();
        }
    }
}
