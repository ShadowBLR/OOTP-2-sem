namespace OOTPLab9
{
    public class Human:GameObjject
    {
       public Human() { }
        public  Human(int HP,int AT):base(HP,AT)
        {

        }
        public override void GetHp(int delta)
        {
            this.HitPoints += delta*2;
            System.Console.WriteLine($"Полученное здоровье:{delta*2}");
        }
        public override void GetDamage(int delta)
        {
            HitPoints -= delta + 2;
            System.Console.WriteLine($"Полученный урон:{delta + 2}");
        }

    }
}
