using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace OOTPLab8
{
    public partial class List<T>
    {
        public List(){}
        public Node<T> this[int index]
        {
            get 
            {
                Node<T> tmp = new Node<T>();
                if (index < this.Count)
                {
                    tmp = Head;
                    for (int i = 0; i < index; i++)
                    {
                        tmp = tmp.Next;
                    }
                }
                return tmp;

            }

        }
        public Node<T> Tail { get; set; }
        public Node<T> Head { get;set;}
        
        public int Count { get; set; }
       
       public static bool operator ==(List<T> list,List <T> list2)
        {
            return list.Equals(list2);
        }
        public static bool operator !=(List<T> list, List<T> list2)
        {
            return !list.Equals(list2);
        }
        public static bool operator >>(List<T> list, int count)
        {
            if (list.Count < count)
            {
                return false;
            }
            Node<T> temp = list.Head;
            int i;
            for (i = 0; i < count-1; i++)
            {
            temp = temp.Next;
            count++;
            }
            if (i == 0)
            {
                list.Head = list.Head.Next;
            }

            else
            {
                temp = temp.Next.Next;
            }
            list.Count--;
            return true;
        }
    }
}
