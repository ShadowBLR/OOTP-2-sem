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

namespace OOTPLab04
{
    public partial class List<T>
    {
        public Date date;
        public List()
            {
            date = new Date();
            }
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
        public Node<T> Tail { get; private set; }
        public Node<T> Head { get;private set;}
        
        public int Count { get; private set; }
        public void Add(T data)
        {
            Node<T> node = new Node<T>(data);
            if (Head == null)
            {
                Head = node;
                Tail = Head;
            }
            else
            {
                Tail.Next = node;
                Tail = node;
            }
            Count++;
        }
        public bool IsEmpty()
        { 
            return Count == 0;
        }
        public void AppendFirst(T data)
        {
            Node<T> node = new Node<T>(data)
            {
                Next = Head
            };
            Head = node;
            if(Count==0)
            {
                Tail = Head;
            }
            Count++;
        }
        public bool Remove(T data)
        {
            Node<T> current = Head;
            Node<T> previous = null;
            while(current!=null)
            {
                if(current.Data.Equals(data))
                {
                    if(previous!=null)
                    {
                        previous.Next = current.Next;
                    }
                else
                {
                    Head = Head.Next;
                    if(Head==null)
                    {
                        Tail = null;
                    }
                }
                    Count--;
                    return true;
                }
                previous = current;
                current = current.Next;
            }
        return false;
        }
        public bool RemoveLastNode()
        {
            if(this.IsEmpty())
            {
                return false;
            }
            Node <T> temp= this.Head;
            for(int i=0;i<Count-1;i++)
            {
                temp = temp.Next;
            }
            this.Tail = temp;
            temp.Next = null;
            return true;
        }
        public Node<T> Search(T data)
        {
            Node<T> current = Head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    return current;
                }
            }
            return null;
        }
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
        public static string GetLongestWord (List<T> list)
        {
            Node<T> tempNode = list.Head;
            string str = tempNode.ToString();
            while(tempNode!=null)
            {
               if(str.Length<tempNode.ToString().Length)
                {
                    str = tempNode.ToString();
                }
                tempNode = tempNode.Next;
            }
            return str;
        }
    }
}
