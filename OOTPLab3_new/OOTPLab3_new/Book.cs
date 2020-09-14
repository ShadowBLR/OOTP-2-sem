using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOTPLab3_new
{
    enum TypeOfBinding { Solid, Soft };
   partial class Book
    {
        static uint numberOfBooks = 0;
        const string NameOfOwner = "OAO BELARUSSIAN BOOKS"; 
        public readonly int  id;
        public  string Name { get; set; }
        public string Author { get; set; }
        public short YearOfPublishing { get; set; }
        public ushort NumberOfPages { get; set; }
        private int price;
        public int Price 
        { 
            get 
            {
                return price;
             } 
            set
            {
                if (value < 0)
                    while (value < 10)
                        value = Convert.ToInt32(Console.ReadLine());
                price = value;
            }
        }

        TypeOfBinding binding=(TypeOfBinding)1;
        public Book(string name = "",string author="" , short yearOfPublishing=0,int price = 0,ushort numberOfPages=0)
        {
            ++numberOfBooks;
            Name = name;
            Author = author;
            YearOfPublishing = yearOfPublishing;
            Price = price;
            NumberOfPages = numberOfPages;
            id = this.GetHashCode();
        }
        public Book(Book b)
        {
            Name = b.Name;
            Author = b.Author;
            YearOfPublishing = b.YearOfPublishing;
            Price = b.Price;
            NumberOfPages = b.NumberOfPages;
            id = this.GetHashCode();
        }
        static Book()
        {
            Console.WriteLine("Создана первая книга");
        }
        private Book()
        {
            ++numberOfBooks;
            Console.WriteLine("Типа будущий синглтон");
        }
         public void printBook()
        {
            Console.WriteLine();
            Console.WriteLine("Нзавание книги:" + Name);
            Console.WriteLine("Автор книги:" + Author);
            Console.WriteLine("Год издания:" + YearOfPublishing);
            Console.WriteLine("Количество страниц:"+NumberOfPages);
            Console.WriteLine("Цена:"+Price);
            Console.WriteLine();
        }
         public static void  TypeOfClass()
        {
            Type tp = Type.GetType("OOTPLab3_new.Book");
            Console.WriteLine(tp.AssemblyQualifiedName);
           
        }
    }
}
