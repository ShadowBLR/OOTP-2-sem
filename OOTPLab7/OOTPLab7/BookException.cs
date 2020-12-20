using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOTPLab7
{
    class BookException:PrintEditionException
    {
        public BookException(string message) : base(message)
        {
            Console.WriteLine("Вызвано исключение для книги");
        }
    }
}
