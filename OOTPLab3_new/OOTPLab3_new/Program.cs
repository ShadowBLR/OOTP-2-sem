using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOTPLab3_new
{
    class Program
    {
        static void Main(string[] args)
        {
            Book b = new Book("The Picture of Dorian Gray", "Оскар Уайлд",2010, 200, 200);
            Console.WriteLine("Type:"+b.GetType());
            Book b2 = new Book("Termonator","HZ" ,1960, 1000, 400);
            b2.Price = 300;
            b2.Name = "Terminator";
            Book b3 = new Book(b);
            if (b.Equals(b2))
            {
                Console.WriteLine("Книги одинаковы 1 и 2");
            }
            else
            {
                Console.WriteLine("Книги 1 и 2 различны");
            }
            if (b.Equals(b3))
            {
                Console.WriteLine("Книги 1 и 3 одинаковы");
            }
            else
            {
                Console.WriteLine("Книги 1 и 3 различны");
            }
            Book []arrBook =new Book[3];
            arrBook[0] = new Book(b);
            arrBook[1] = new Book(b2);
            arrBook[2] = new Book("three Musteketeers ","Duma", 1924, 1000, 2000);

            Console.WriteLine("Введите автора:");
            string buffer = Console.ReadLine();
            Console.WriteLine("Фильтрация по автору:");
            for(int i=0;i<arrBook.Length;i++)
            {
                if(arrBook[i].Author==buffer)
                {
                   Book.PrintBook(arrBook[i]);
                }
            }
            Console.WriteLine("Введите год выпуска:");
            int year = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Фильтрация по году:");
            for (int i = 0; i < arrBook.Length; i++)
            {
                if (arrBook[i].YearOfPublishing > year)
                {
                    Book.PrintBook(arrBook[i]);
                }
            }

            var user = new { Name = "Tom", Age = 34 };
            var student = new { Name = "Alice", Age = 21 };
        }

    }
}
