namespace OOTPLab05
{
    public class Printer
    {
        public static void IAmPrinting(object o)
        {
            if(o is Book)
            {
                System.Console.WriteLine("Это книга!");
            }
            if(o is PrintEdition)
            {
                System.Console.WriteLine("Это печатное издание");
            }
            if(o is PublishingHouse)
            {
                System.Console.WriteLine("Это печатный центр");
            }
            if (o is Person)
            {
                System.Console.WriteLine("Это человек");
            }
            if (o is Author)
            {
                System.Console.WriteLine("Это автор");
            }
           
        }
    }
}
