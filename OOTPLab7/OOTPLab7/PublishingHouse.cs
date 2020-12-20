namespace OOTPLab07
{
    public static class  PublishingHouse
    {
        public static PrintEdition[] ArrPrintEditions;

         static PublishingHouse() 
        {
            System.Console.WriteLine("Печатный центр создан");
        }
        public static string ToString(int i)
        {
            return ArrPrintEditions[i].ToString();
        }
    }
}
