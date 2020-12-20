using System;

namespace OOTPLab7
{
    class PrintEditionException:ApplicationException
    {
       public PrintEditionException(string message):base(message)
        {
            Console.WriteLine("Вызвано исключение для печатного издания");
        }
    }
}
