using System.Runtime.InteropServices;

namespace OOTPLab9
{
    public abstract class GameObjject
    {
        public int MaxHitPoints { get; private set; }
        public int HitPoints { get;set; }
        public int Power { get; private set; }
        public bool IsDead { get; private set; }
        public GameObjject() { }
        public GameObjject(int HP,int AT)
        {
            MaxHitPoints=HitPoints = HP;
            Power = AT;
        }
        public abstract void GetDamage(int delta);
        public abstract void GetHp(int delta);
        public void Dead()
        {
            IsDead = true;
        }
        public void PrintInfo()
        {
            System.Console.WriteLine($"Current HP:{HitPoints}");
            System.Console.WriteLine($"Current Attack:{Power}");
            System.Console.WriteLine();
        }
    }
}
