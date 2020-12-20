using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOTPLab9
{
   public class StringHandler
    {
        public static string RemoveS(string str)//удаление знаков
        {
            char[] sign = { '.', ',', '/', '?', '_', ';' };
            for (int i = 0; i < str.Length; i++)
            {
                if (sign.Contains(str[i]))
                {
                    str = str.Remove(i, 1);
                }
            }
            return str;
        }

        public static string AddToString(string str)//добавление строки
        {
            return str += " $AddToString$";
        }

        public static string RemoveSpase(string str)//удаление пробелов
        {
            return str.Replace(" ", string.Empty);//возвр. изменённую строку
        }

        public static string Upper(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                str = str.Replace(str[i], Char.ToUpper(str[i]));
            }
            return str;
        }

        public static string Letter(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                str = str.Replace(str[i], Char.ToLower(str[i]));
            }
            return str;
        }
    }
}
