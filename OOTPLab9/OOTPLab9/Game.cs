using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOTPLab9
{
    public class Game
    {
        public Game()
        {
        }
        public delegate void GameHandler();
        public delegate void GameEngineHandler(int delta);
        public event GameEngineHandler Attack;
        public event GameEngineHandler Hill;
        public event GameHandler Dead;
        public event GameHandler InfoAboutObject;
        public  void ToAttack(int delta)
        {
            Attack?.Invoke(delta);
        }
        public void KillAll()
        {
            Dead?.Invoke();
            Console.WriteLine("Все мертвы");
        }
        public void ToHil(int delta)
        {
            Hill?.Invoke(delta);
        }
       public void Print()
        {
            InfoAboutObject?.Invoke();
        }
       
    }
}
