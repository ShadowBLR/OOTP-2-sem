using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOTPLab3_new
{
    enum TypeOfBinding { Solid, Soft,Undefined };
    partial class Book
    {
        static uint numberOfBooks = 0;
        const string NameOfOwner = "OAO BELARUSSIAN BOOKS";
        public readonly int id;
        public string Name { get; set; }
        public string Author { get; set; }
        public short YearOfPublishing { get; set; }
        public ushort NumberOfPages { get; }
        public int Толщина { get; set; }
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
                {
                    while (value < 10)
                    {
                        value = Convert.ToInt32(Console.ReadLine());
                    }
                }
                price = value;
            }
        }

        private TypeOfBinding Binding=TypeOfBinding.Soft;
        public TypeOfBinding Bind 
        { 
            get 
            {
                return Binding;
            }
            set 
            {
                Binding=value;
            }
        }
        
        public Book(string name = "",string author="" , short yearOfPublishing=0,int price = 0,ushort numberOfPages=0, TypeOfBinding binding = TypeOfBinding.Undefined,int толщина=0)
        {
            ++numberOfBooks;
            Name = name;
            Author = author;
            YearOfPublishing = yearOfPublishing;
            Price = price;
            NumberOfPages = numberOfPages;
            this.Binding = binding;
            id = this.GetHashCode();
        }
        public Book(string name)
        {
            ++numberOfBooks;
            Name = name;
            Author = "";
            YearOfPublishing = 0;
            Price = 0;
            NumberOfPages = 0;
            id = 0;        }
        public Book(Book b)
        {
            ++numberOfBooks;
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
         public static void PrintBook(Book b)
        {
            Console.WriteLine();
            Console.WriteLine("Нзавание книги:" + b.Name);
            Console.WriteLine("Автор книги:" + b.Author);
            Console.WriteLine("Год издания:" + b.YearOfPublishing);
            Console.WriteLine("Количество страниц:"+b.NumberOfPages);
            Console.WriteLine("Цена:"+b.Price);
            Console.WriteLine("Толщина:"+b.Толщина);
            Console.WriteLine();
        }
        public static void TestingRefAndOut(ref int a,ref int b,out int c)
        {
            c = a + b;
        }
    
        /* public static void  TypeOfClass()
        {
            Type tp = Type.GetType("OOTPLab3_new.Book");
            Console.WriteLine(tp.AssemblyQualifiedName);
           
        }*/
    }
}
