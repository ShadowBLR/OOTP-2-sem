namespace OOTPLab05
{
    public class Magazine : PrintEdition, IPrinting
    {
        public Person Painter;
        public new void SayHello()
        {
            System.Console.WriteLine("Say hello fron Magazine");
        }
        
    }
}
