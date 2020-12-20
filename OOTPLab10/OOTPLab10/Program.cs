using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OOTPLab10
{
     class Program
    {
        static void Main(string[] args)
        {
            HashSet<Computer> HashTableComputer = new HashSet<Computer>();
            Computer cm1 = new Computer("HP 270 G7", 1500, 800);
            Computer cm2 = new Computer("Asus bla-bla", 3500, 2400);
            Computer cm3 = new Computer("Macbook Pro", 5500, 4500);

            cm1.Add(new Computer.User("Ivan", "qwerty123"));
            cm2.Add(new Computer.User("NotIvan", "123qwerty"));
            cm3.Add(new Computer.User("Ivan Ivanov", "IvanIvanovQwerty123"));

            HashTableComputer.Add(cm1);
            HashTableComputer.Add(cm2);
            HashTableComputer.Add(cm3);
            HashTableComputer.OrderBy(x => x.MaxPrice);
            HashTableComputer.Remove(cm2);
            
            foreach(var  i in HashTableComputer)
            {
                Console.WriteLine(i);
            }


            //==========TASK2===================
            HashSet<object> hSet = new HashSet<object>();
            hSet.Add(14);
            hSet.Add(24);
            hSet.Add(34);
            hSet.Add("aaa");
            hSet.Add("bbb");
            hSet.Add(44);
            hSet.Add(true);
            hSet.Add(54);
            hSet.Add(14.543);
            hSet.Add('5');
            hSet.Add(9);

            foreach(var i in hSet)
            {
                Console.WriteLine(i);
            }
            for(int i=0;i<5;i++)
            {
                hSet.Remove(hSet.ElementAt(0));
            }
            Console.WriteLine("После удаления:");
            foreach (var i in hSet)
            {
                Console.WriteLine(i);
            }
            Stack<object> stk = new Stack<object>();
            Console.WriteLine("После заполнения стека:");

            foreach (var i in hSet)
            {
                stk.Push(i);
                Console.WriteLine(stk.Peek());
            }
            Console.WriteLine("Поиск");
            int count=stk.Count;
            for(int i=0;i<stk.Count;i++)
            {
               if(stk.Peek().ToString() =="5" )
                {
                    Console.WriteLine("Элемент найден:"+stk.Pop()+" под номером "+ (i+1));
                }
                else
                {
                    stk.Pop();
                }
            }

            //==========================TASK3===================================
            ObservableCollection<Computer> obsCol = new ObservableCollection<Computer>();
            obsCol.CollectionChanged += PrintMessage;
            Computer comp = new Computer("IBM", 100000, 99990);
            obsCol.Add(comp);
            obsCol.Add(new Computer("ASUS",3000,100));
            obsCol.Remove(comp);
            comp.Name = "NotIBM";
            comp.Add(new Computer.User("Ivan", "qwerty123"));
            obsCol.Add(comp);
            
            foreach(var i in obsCol)
            {
                Console.WriteLine(i);
            }

        }
        public static void PrintMessage(object sender,NotifyCollectionChangedEventArgs nccea)
        {
            Console.WriteLine("Объект изменен");
            Console.WriteLine(nccea.Action);
            Console.WriteLine(nccea.NewStartingIndex);
        }
    }
}
