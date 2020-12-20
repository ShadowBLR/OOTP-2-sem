using System;
using System.Collections.Generic;
using System.IO;

using OOTPLab05;

namespace OOTPLab8
{
   // public class CollectionType<T> : IController<T> where T : struct, IComparable
    public class CollectionType<T> : IController<T> where T : PrintEdition,IPrinting,new()
    { 
        public List<T> list;
        public CollectionType()
        {
            list = new List<T>();
        }
        public bool IsEmpty()
        {
            return list.Count == 0;
        }
        public void Add(T data)
        {
            Node<T> node = new Node<T>(data);
            if (list.Head == null)
            {
                list.Head = node;
                list.Tail = list.Head;
            }
            else
            {
                list.Tail.Next = node;
                list.Tail = node;
            }
            list.Count++;
        }
        public bool Remove(T data)
        {
            Node<T> current = list.Head;
            Node<T> previous = null;
            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    if (previous != null)
                    {
                        previous.Next = current.Next;
                    }
                    else
                    {
                        list.Head = list.Head.Next;
                        if (list.Head == null)
                        {
                            list.Tail = null;
                        }
                    }
                    list.Count--;
                    return true;
                }
                previous = current;
                current = current.Next;
            }
            return false;
        }
        public Node<T> Search(T data)
        {
            Node<T> current = list.Head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    return current;
                }
            }
            return null;
        }
        public bool RemoveLastNode()
        {
            if (IsEmpty())
            {
                return false;
            }
            list.Count--;
            Node<T> temp = list.Head;
            for (int i = 0; i < list.Count - 1; i++)
            {
                temp = temp.Next;
            }
            list.Tail = temp;
            temp.Next = null;
  
            return true;
        }

        public void Print(int index)
        {
            Console.WriteLine(list[index].Data);

        }
        public void PrintAll()
        {
            for (int i = 0; i < list.Count;i++)
            {
                Print(i);
            }
        }
        public void SaveInfFile(string path)
        {
                Node<T> tempNode = list.Head;
                StreamWriter sw = new StreamWriter(new FileStream(path, FileMode.Create, FileAccess.Write));
                for (int i = 0; i < list.Count; i++)
                {
                    sw.WriteLine(tempNode.Data);
                    tempNode = tempNode.Next;
                }
                sw.Close();
        }
        public void ReadFromFile(string path)
        {
            StreamReader sw = new StreamReader(path);
            Console.WriteLine("\n\n\n\n");
            while (!sw.EndOfStream)
            {
                Console.WriteLine(sw.ReadLine());
            }
            sw.Close();
        }
    }
}
