using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOTPLab04
{
    
    public class Node<T>
    {
        public T Data{get;set;}
        public Node<T> Next { get; set; }
        public Node(T data)
        {
            Data = data;
        }
        public Node() { }
        public static bool operator +(Node<T> node, Node<T> data)
        {
            node.Next = data;
            return true;
        }
        
    }

}
