namespace OOTPLab9
{
    public class Orc:GameObjject
    {
        public Orc() { }
        public Orc(int HP, int AT) : base(HP, AT)
        {

        }
        public override void GetHp(int delta)
        {
            System.Console.WriteLine($"Лечение орка невозможно");
        }
        public override void GetDamage(int delta)
        {
            this.HitPoints -= delta/2;
            System.Console.WriteLine($"Полученный урон:{delta/2}");
        }
    }
}
