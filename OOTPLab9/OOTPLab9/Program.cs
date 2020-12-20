using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace OOTPLab9
{
    
    class Program
    {
      
        static void Main(string[] args)
        {
            Human h1 = new Human(100, 4);
            Elph e1 = new Elph(120, 4);
            Orc o1 = new Orc(200, 6);
            Game g1 = new Game();

            g1.InfoAboutObject += h1.PrintInfo;
            g1.InfoAboutObject += e1.PrintInfo;
            g1.InfoAboutObject += o1.PrintInfo;
            g1.Print();

            g1.Attack += h1.GetDamage;
            g1.Attack += e1.GetDamage;
            g1.Attack += o1.GetDamage;
            g1.ToAttack(15);
            g1.Print();

            g1.Hill += h1.GetHp;
            g1.Hill += e1.GetHp;
            g1.Hill += o1.GetHp;
            g1.ToHil(20);

            g1.Print();

            g1.Dead += ()=>
            {
                h1.Dead();
                e1.Dead();
                o1.Dead();
            };
            
            Console.WriteLine(h1.IsDead);
            g1.KillAll();
            Console.WriteLine(h1.IsDead);
            

            string str = "Не успел доделать/лабу на прошлой паре.Приходится;досдавать_сегодня";
            string str2 = str;
            Func<string, string>testFunc= StringHandler.RemoveS;
            Console.WriteLine("Строка до: {0}\nПосле: {1}\n", str, str = testFunc(str));
            testFunc= StringHandler.RemoveSpase;
            Console.WriteLine("Строка до: {0}\nПосле: {1}\n", str, str = testFunc(str));
            testFunc= StringHandler.Upper;
            Console.WriteLine("Строка до: {0}\nПосле: {1}\n", str, str = testFunc(str));
            testFunc= StringHandler.Letter;
            Console.WriteLine("Строка до: {0}\nПосле: {1}\n", str, str = testFunc(str));
            testFunc= StringHandler.AddToString; 
            Console.WriteLine("Строка до: {0}\nПосле: {1}\n", str, str = testFunc(str));

            Console.Read();
        }    
   
    }
}