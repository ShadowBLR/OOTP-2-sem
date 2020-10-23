using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OOTPLab04
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>();
            list.Add("Петя");
            list.Add("Вася");
            list.Add("Акакий");

            Console.WriteLine(list[0].Data);
            Console.WriteLine(list[1].Data);
            Console.WriteLine(list[3].Data);

            string str = "";
            Console.WriteLine(str.MaxLengthWord(list));
            Console.WriteLine(list.Count);
            Console.WriteLine(StatisticOperation.CharCount("Мама мыла раму", 'м'));
            Console.WriteLine(StatisticOperation.Sum(list));

            Console.WriteLine(list.Head.Data);
            Console.WriteLine( _ = list >> 1);
            Console.WriteLine(list.Count);
            Console.WriteLine( list.Head.Data);
            
            List<string> list2 = new List<string>();
            list2.Add("Вася");
            list2.Add("Акакий");

            Console.WriteLine(list==list2);
            Console.WriteLine(list != list2);

            List<string> list3 = list;

            Console.WriteLine(list == list3);
            Console.WriteLine(list != list3);

            Console.WriteLine(list.date.dt);

            List<string>.Owner owner = new List<string>.Owner();
            Console.WriteLine(owner.Id);
            Console.WriteLine(owner.Name);
            Console.WriteLine(owner.Organisation);

        }
    }
}
