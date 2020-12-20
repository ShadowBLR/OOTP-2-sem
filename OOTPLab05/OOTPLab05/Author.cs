namespace OOTPLab05
{
    public class Author:Person,IPrinting
    {
        public string[] Books;

        public override void SayHello()
        {
            System.Console.WriteLine("Hello from author");
        }
         void  IPrinting.SayHello()
        {
            System.Console.WriteLine("IPrinting Hello");
        }
        public Author() : base()
        {
         
        }

        public Author(string _FirstName, string _LastName, int _BirthDay, int _BirthMonth, int _BirthYear) :base(_FirstName,_LastName,_BirthDay,_BirthMonth,_BirthYear)
        { }
        public override string  ToString()
        {
            return base.ToString();
        }
        public void PrintAuthorInfo()
        {
            System.Console.WriteLine(this.ToString());
        }
        public override bool Equals(object obj)
        {
            return Equals(FirstName)&&Equals(LastName);
        }
        public override int GetHashCode()
        {
            return (BirthDay+BirthMonth+BirthYear)*FirstName.Length+LastName.Length;
        }

        public int GetYearOfPublishing()
        {
            return -1;
        }
    }
}
