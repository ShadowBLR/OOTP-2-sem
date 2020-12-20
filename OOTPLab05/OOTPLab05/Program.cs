using System;
using System.Collections.Generic;


namespace OOTPLab05
{
    partial class Program
    {
        static void Main(string[] args)
        {
            
            Book b = new Book(100, "Война и мир",1850, "Лев", "Толстой", 28, 10, 2001,"Роман");
            Author p = new Author();
            b.PrintAuthorInfo();
            PublishingHouse.ArrPrintEditions = new PrintEdition[3];
            PublishingHouse.ArrPrintEditions[0] = new PrintEdition(14, "Крестный отец",1000,new Author("Papa","Carlo",18,10,2001),new COST { Price = 100 });
            Console.WriteLine( PublishingHouse.ToString(0));
            Printer.IAmPrinting(new Author());
            b.author.Gender = (GENDER)1;
            Console.WriteLine(b.author.Gender);
            Author au = new Author();
            IPrinting ip = new Author();
            au.SayHello();
            ((IPrinting)au).SayHello();
            ip.SayHello();
            object[] obj =  { b, p ,PublishingHouse.ArrPrintEditions[0]};
            foreach(var i in obj)
            {
                if (i is Book) Printer.IAmPrinting(i);
            }
            Library lib = new Library();
            lib.printings[0].SayHello();
            Console.WriteLine( lib.printings.Count);
            var a = lib.Get(0);
            a.SayHello();
            lib.AddElementFromLibrary(new PrintEdition
            {
                author = new Author("Ivan", "Ivanov", 12, 5, 20001),
                Name = "to be or not to be",
                NumberOfPages = 1
            });
            lib.PrintAllElementsFromLibrary();
           if( lib.RemoveElementFromLibrary((lib.Get(lib.printings.Count-1))))
            {
                Console.WriteLine("Элемент успешно удален");
            }
            lib.PrintAllElementsFromLibrary();
            Console.WriteLine();
            Console.WriteLine("Testing method");
            Controller control = new Controller(lib);
            control.PrintByYearOfPublishing(20000);
            Console.WriteLine("Total price:"+control.TotalPrice());
            Console.WriteLine("Count of magazines:"+control.CountOfMagazines());
            
        }
    }
}