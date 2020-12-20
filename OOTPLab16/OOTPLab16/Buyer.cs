using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OOTPLab16
{
    class Buyer
    {
        string Name { get; }

        public Buyer(string name)
        {
            Name = name;
        }

        public void Take(BlockingCollection<string> stock,bool b)
        {
            if (stock.Count == 0 &&b)
            {
                Console.WriteLine("Товар кончился.Все остальные ушли");
                Thread.ResetAbort();
            }
                Random rnd = new Random();
            Thread.Sleep(rnd.Next(100, 1000));
            if (stock.TryTake(out string product))
                Console.WriteLine($"{Name} Купил продукт");
            else
            {
                Console.WriteLine($"{Name} Ушел");
            }
            

        }

    }
}
