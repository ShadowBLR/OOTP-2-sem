namespace OOTPLab9
{
    public class Elph:GameObjject
    {
        public Elph() { }
        public Elph(int HP,int AT):base(HP,AT)
        {

        }
        public override void GetHp(int delta)
        {
            this.HitPoints += delta ;
            System.Console.WriteLine($"Полученное здоровье:{delta}");
        }
        public override void GetDamage(int delta)
        {
            this.HitPoints -= delta -1;
            System.Console.WriteLine($"Полученный урон:{delta - 1}");
        }
    }
}
