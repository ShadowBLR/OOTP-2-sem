using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OOTPLab04
{
    public static class StatisticOperation
    {
        public static int Sum(List<string> list)
        {
            Node<string> tempNode = list.Head;
            int sumLength=0;
            while(tempNode!=null)
            {
                sumLength += tempNode.Data.ToString().Length;
                tempNode = tempNode.Next;
            }
            return sumLength;   
        }
        public static string MaxLengthWord(this string str, List<string> list)
        {
            Node<string> tempNode = list.Head;
            string str2 = tempNode.Data.ToString();
            int maxLength = tempNode.Data.ToString().Length;
            int buff;
            while (tempNode != null)
            {
                buff = tempNode .ToString().Length;
                if (buff > maxLength)
                {
                    str2 = tempNode.Data.ToString();
                }
                tempNode = tempNode.Next;
            }
            return str2;
        }
        public static int Difference(List<string> list)
        {
            Node<string> tempNode = list.Head;
            int minLength = tempNode.Data.ToString().Length;
            int maxLength = minLength;
            int buff=0;
            while (tempNode != null)
            {
                buff = tempNode.Data.ToString().Length;
                if (buff>maxLength)
                {
                    maxLength = tempNode.Data.ToString().Length;
                }
                if(buff<minLength)
                {
                    minLength = buff;
                }    
                tempNode = tempNode.Next;
            }
            return maxLength - minLength;
        }
        
        public static int CharCount(this string str,char c)
        {
            int count = 0;
            for(int i=0;i<str.Length;i++)
            {
                if (str[i] == c)
                    count++;
            }
            return count;
        }
    }
}
