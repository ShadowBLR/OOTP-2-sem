using System.Runtime.CompilerServices;

namespace OOTPLab05
{

   sealed  public class Book :PrintEdition,IPrinting
    {
       public string Genre { get; set; }
       public Book() : base() { }
       public Book(int _NumberOfPages,string _Name,int yearOfPub,string _FirstName, string _LastName, int _BirthDay, int _BirthMonth, int _BirthYear,string _Genre) : base(_NumberOfPages,_Name,yearOfPub,new Author(_FirstName, _LastName, _BirthDay, _BirthMonth, _BirthYear),new COST {Price= 100 })
        {
            Genre = _Genre;
        }

        public void SayHello()
        {
            System.Console.WriteLine("Hello");
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}