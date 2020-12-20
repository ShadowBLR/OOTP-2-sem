using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOTPLab14
{
    public enum GENDER
    {
        MEN,
        WOMEN
    }

    [Serializable]
    abstract public class Person
    {
        
        public GENDER Gender { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int BirthDay { get;  set; }
        public int BirthMonth { get;  set; }
        public int BirthYear { get;  set; }
        public Person(string _FirstName, string _LastName, int _BirthDay, int _BirthMonth, int _BirthYear,GENDER gENDER = GENDER.MEN)
        {
            FirstName = _FirstName;
            LastName = _LastName;
            BirthDay = _BirthDay;
            BirthMonth = _BirthMonth;
            BirthYear = _BirthYear;
            Gender = gENDER;
        }
        public Person() { }
        public override string ToString()
        {
            return @$"Person:{FirstName} {LastName}
dateOfBirth:{BirthDay}.{BirthMonth}.{BirthYear}";
        }
    }
}
