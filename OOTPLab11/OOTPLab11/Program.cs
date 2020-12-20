using OOTPLab3_new;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace OOTPLab11
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] strArray = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            int n;
            n = Convert.ToInt32(Console.ReadLine());


            /*  var selectedTeams = new List<string>();

              foreach(string s in strArray)
              {
                  if (s.Length == n)
                      selectedTeams.Add(s);
              }
              foreach(var i in selectedTeams)
              {
                  Console.WriteLine(i);
              }*/
            Console.WriteLine("========1===========");
            var selectedTeams1 = from t in strArray
                                where
              t.Length == n
                                select t;
            foreach (var i in selectedTeams1)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("=========2==========");
            var selectedTeams2 = from t in strArray
                                 where
                                 t == "January" ||
                                 t == "February" ||
                                 t == "December" ||
                                 t == "June" ||
                                 t == "July" ||
                                 t == "August"
                                 select t;
            foreach (var i in selectedTeams2)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("=========3==========");
            var selectedTeams3 = from t in strArray
                                 orderby  t
                                 select t;
            foreach (var i in selectedTeams3)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("========4===========");
            var selectedTeams4 = from t in strArray
                                 where
            t.Length > 3 &&t.Contains("u")
                                 select t;

            foreach (var i in selectedTeams4)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("=======Выборка из книг 1 =====");


            List<Book> lst = new List<Book>();
            lst.Add(new Book("Жить или не жить", "Kishko Ivan", 2020, 100000, 1, TypeOfBinding.Soft,8));
            lst.Add(new Book("Золотая рыбка", "Пушкин А.С.", 1523, 10, 2, TypeOfBinding.Soft,15));
            lst.Add(new Book("1984", "Дж. Оруэлл", 1948, 1000, 3, TypeOfBinding.Soft,22));
            lst.Add(new Book("Три товарища", "Эрих Мария Ремарк", 2020, 103, 4, TypeOfBinding.Soft,66));
            lst.Add(new Book("Цитаты великих людей", "Великий человек", 2021, 300, 5, TypeOfBinding.Soft,77));
            lst.Add(new Book("Колобок", "никто", 2020, 100000, 6, TypeOfBinding.Soft,1));
            lst.Add(new Book("Философия", "Kishko Ivan", 2020, 100000, 7, TypeOfBinding.Soft,2));
            lst.Add(new Book("Войну и мир", "Лев Николаевич Толстой", 1820, 1000, 8, TypeOfBinding.Soft,4));

            var selectedList1 = from t in lst
                                where
             t.Author == "Kishko Ivan" && t.YearOfPublishing == 2020
                                select t;

            foreach (var i in selectedList1)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("=======Выборка из книг 2=====");
            var selectedList2 = from t in lst
                                where
             t.YearOfPublishing> 2000
                                select t;

            foreach (var i in selectedList2)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("=======Выборка из книг 3=====");
            int min = lst.Min(a=>a.Толщина);
            var minBook = lst.FirstOrDefault(a => a.Толщина == min);
                Console.WriteLine(minBook);

            Console.WriteLine("=======Выборка из книг 4=====");
            var selectedList4 = lst.OrderByDescending(a => a.Толщина).ThenBy(a => a.Price).Take(5);
            foreach(var i in selectedList4)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("=======Выборка из книг 5=====");
            var selectedList5 = from t in lst
                                orderby t.Price
                                select t;

            foreach (var i in selectedList5)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("==================Свой пример==============");
            var resul = lst.Where(a => a.Price > 10).Concat(lst.Take(1)).OrderByDescending(a=>a.Price).Contains(lst.Last());   
            foreach(var i in lst)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("=======Join=====");
            List<Book> iList = new List<Book>();
            iList.Add(new Book("Колобок", "никто", 2020, 100000, 6, TypeOfBinding.Soft, 1));
            iList.Add(new Book("Философия", "Kishko Ivan", 2020, 100000, 7, TypeOfBinding.Soft, 2));
            iList.Add(new Book("Война и мир", "Лев Николаевич Толстой", 1820, 1000, 8, TypeOfBinding.Soft, 4));

            List<Score> ScoreLst = new List<Score>();
            ScoreLst.Add(new Score("OZ", "Колобок", 15));
            ScoreLst.Add(new Score("Library Belstu", "Философия", 150));
            ScoreLst.Add(new Score("Beldruk", "Война и мир", 10));
            ScoreLst.Add(new Score("FIX_RPICE", "red Riding Hood", 10));

            var resultJoin = iList.Join( ScoreLst,
                p=>p.Name,
                t=>t.ProductName,
                (p, t) => new {p.Name,p.Author,p.NumberOfPages,p.Price,t.ScoreName,t.Count });

            foreach(var i in resultJoin)
            {
                Console.WriteLine(i);
            }
        }
    }
}
