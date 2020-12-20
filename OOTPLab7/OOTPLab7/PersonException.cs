using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOTPLab7
{
    class PersonException:ApplicationException
    {
        public PersonException(string message) : base(message)
        {
            Console.WriteLine("Вызвано исключение для человека");
        }
    }
}
