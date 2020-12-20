namespace OOTPLab05
{
    public enum GENDER
    {
        MEN,
        WOMEN
    }
 
    abstract public class Person
    {
        public GENDER Gender { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int BirthDay { get; private set; }
        public int BirthMonth { get; private set; }
        public int BirthYear { get; private set; }
        public Person(string _FirstName,string _LastName,int _BirthDay,int _BirthMonth,int _BirthYear)
        {
            FirstName = _FirstName;
            LastName = _LastName;
            BirthDay = _BirthDay;
            BirthMonth = _BirthMonth;
            BirthYear = _BirthYear;
        }
        public Person(){}
        public override string ToString()
        {
            return @$"Person:{FirstName} {LastName}
dateOfBirth:{BirthDay}.{BirthMonth}.{BirthYear}";
        }
        public abstract  void SayHello();

    }
}
