using OOTPLab7;
using System;

namespace OOTPLab07
{
    public struct COST
    {
        public int Price { get; set; }
    }
    public  class PrintEdition:IPrinting
    {
        public COST PRICE;
        public int NumberOfPages { get; set; }
        public string Name { get; set; }
        public int YearOfPublishing {
            get { return YearOfPublishing; }
            set {
                if (value < 0)
                    throw new PrintEditionException("Старое печатное издание");
                        }
        }
        public Author author;
        public PrintEdition(PrintEdition pe)
        {
            this.author = pe.author;
            this.Name = pe.Name;
            this.NumberOfPages = pe.NumberOfPages;
            this.PRICE.Price = pe.PRICE.Price;
        }
        public PrintEdition(int _NumberOfPages, string _Name,int YearOfPublishing, Author _author, COST PRICE)
        {
            NumberOfPages = _NumberOfPages;
            Name = _Name;
            author = _author;
            this.PRICE = PRICE;
            this.YearOfPublishing = YearOfPublishing;
        }
        public PrintEdition() { }
        public override string ToString()
        {
            return @$"name:{Name}
Author:{author.FirstName} {author.LastName}";
        }
        public virtual void PrintAuthorInfo()
        {
            System.Console.WriteLine("========Автор=========");
            System.Console.WriteLine("Имя:" + author.FirstName);
            System.Console.WriteLine("Фамилия:" + author.LastName);
            System.Console.WriteLine($"Дата рождения:{author.BirthDay}.{author.BirthMonth}.{author.BirthYear}");
        }

        public void SayHello()
        {
            ((IPrinting)author).SayHello();
        }

        public int GetYearOfPublishing()
        {
            return YearOfPublishing;
        }
    }
}
