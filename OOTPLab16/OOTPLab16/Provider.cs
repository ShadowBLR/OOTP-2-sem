using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OOTPLab16
{
    class Provider
    {
        public string Name { get; }
        private int _speed = 1000;
        public int Speed
        {
            get { return _speed; }
            set
            {
                if (value >= 1000)
                    _speed = 1;
                else
                    _speed -= value;
            }
        }

        public Provider(string name, int speed)
        {
            Name = name;
            Speed = speed;
        }

        public void Add(BlockingCollection<string> stock)
        {
            Thread.Sleep(_speed);
            if(stock.TryAdd("product"))
                Console.WriteLine($"{Name} поставил продукт");
        }
    }
}
