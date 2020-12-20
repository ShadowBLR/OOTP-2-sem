using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace OOTPLab10
{
        
public class Computer : ISet<Computer>
    {
        public class CoumputerEnumerator : IEnumerator
        {
            private int position = -1;
            public List<Computer.User> luser;
            public CoumputerEnumerator() { }
            public CoumputerEnumerator(Computer comp) 
            {
                luser = new List<Computer.User>();
                for (int i = 0; i < comp.luser.Count; i++)
                {
                    luser.Add(comp.luser[i]);
                }
            }
            public bool isExist(User item)
            {
                foreach (var i in luser)
                {
                    if (item.Equals(i))
                    {
                        return true;
                    }
                }
                return false;
            }
            public CoumputerEnumerator(List<Computer.User> lus)
            {
                luser = new List<Computer.User>();
                for (int i = 0; i < lus.Count; i++)
                {
                    luser.Add(lus[i]);
                }
            }
            public object Current
            {
                get
                {
                    if (position == -1 || position >= luser.Count)
                        throw new InvalidOperationException();
                    return luser[position];
                }
            }
            public bool MoveNext()
            {
                if (position < luser.Count - 1)
                {
                    position++;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public void Reset()
            {
                position = -1;
            }
        }
        List<User> luser;
       
        public class User
        {
            public string Name { get; set; }
            private static int Count = 0;
            private string password;
            public override string ToString()
            {
                return $"Name:{Name}";
            }
            public User() { Count++; }
            public User(string nm,string pas)
            {
                Name = nm;
                SetPassword(pas);
                Count++;
            }
            private string GetPassword()
            {
                return password;
            }

            private void SetPassword(string value)
            {
                password = value;
            }
        }
        public string Name { get; set; }
        public int MaxPrice { get; private set; }
        private int currentPrice;
        public int CurrentPrice 
        {
            get
            {
                return currentPrice;
            }
            private set
            {
                if(value>MaxPrice)
                {
                    throw new Exception("cuurent price > max price");
                }
                else
                {
                    currentPrice = value;
                }
            }
        }
        private  int Count = 1;

        public Computer() { }
        public Computer(string name,int maxprice,int currentprice)
        {
            Name = name;
            MaxPrice = maxprice;
            CurrentPrice = currentprice;
        }
        public bool IsReadOnly => false;

        
        int ICollection<Computer>.Count => Count;

        public bool Add(User item)
        {
            if(luser==null)
            {
                luser = new List<User>();
            }
            luser.Add(item);
            return true;
        }

        public bool isExist(User item)
        {
            foreach(var i in luser)
            {
                if(item.Equals(i))
                {
                    return true;
                }
            }
            return false;
        }
        public void Clear()
        {
            luser.Clear();
        }

        public bool Contains(User item)
        {
            return luser.Contains(item);
        }

        public void CopyTo(User[] array, int arrayIndex)
        {
            for(int i=0,k=arrayIndex;i<luser.Count&&k<array.Length;i++)
            {
                array[k] = luser[i];
            }
        }

        public void ExceptWith(IEnumerable<Computer> other)
        {
            Clear();
        }

        public void IntersectWith(IEnumerable<Computer> other)
        {
            if(other is Computer comp)
            foreach(var i in luser)
            {
                if(!comp.isExist(i))
                    {
                        luser.Remove(i);
                    }
            }
        }

        public bool IsProperSubsetOf(IEnumerable<Computer> other)
        {
            if (other is Computer comp)
                foreach (var i in luser)
                {
                    if (!comp.isExist(i))
                    {
                        return false;
                    }
                }
            return true;
        }
        public override string ToString()
        {
            string str = $@"
Name:{Name}
Price:{CurrentPrice}
Users:";
            if (luser != null)
            {
                foreach (var i in luser)
                {
                    str += i.Name + "\n";
                }
            }
            return str;
        }
        public bool IsProperSupersetOf(IEnumerable<Computer> other)
        {
            return Count > other.Count();
        }

        public bool IsSubsetOf(IEnumerable<Computer> other)
        {
            if( other is Computer cmp)
            {

                for(int i=0;i<luser.Count;i++)
                {
                    if (!cmp.isExist(luser[i]))
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

        public bool IsSupersetOf(IEnumerable<Computer> other)
        {
            if (other is Computer comp)
                foreach (var i in comp.luser)
                {
                    if (!this.isExist(i))
                    {
                        return false;
                    }
                }
            return true;
        }

        public bool Overlaps(IEnumerable<Computer> other)
        {
            if (other is Computer comp)
                foreach (var i in luser)
                {
                    if (comp.isExist(i))
                    {
                        return true;
                    }
                }
            return false;
        }
        public void SymmetricExceptWith(IEnumerable<Computer> other)
        {
            if (other is Computer comp)
                foreach (var i in luser)
                {
                    if (!comp.isExist(i))
                    {
                        luser.Remove(i);
                    }
                }
        }

        public void UnionWith(IEnumerable<Computer> other)
        {
            if (other is Computer comp)
            {
                foreach (var i in luser)
                {
                    if (!comp.isExist(i))
                    {
                        comp.Add(i);
                    }
                }
                foreach (var i in comp.luser)
                {
                    if (!isExist(i))
                    {
                        luser.Add(i);
                    }
                }
            }
        }

        void ICollection<Computer>.Add(Computer item)
        {
            foreach(var i in item.luser)
            {
                luser.Add(i);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
           return luser.GetEnumerator();
        }

        public bool Add(Computer item)
        {
            foreach (var i in item.luser)
            {
                luser.Add(i);
            }
            return true;
        }

        public bool SetEquals(IEnumerable<Computer> other)
        {
            if (other is Computer cmp)
            {
                if (cmp.Count != luser.Count)
                {
                    return false;
                }
                for(int i=0;i<cmp.Count;i++)
                {
                    if(!isExist(cmp.luser[i]))
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

        public bool Contains(Computer item)
        {
            foreach(var i in item.luser)
            {
                if(!isExist(i))
                {
                    return false;
                }
            }
            foreach (var i in luser)
            {
                if (!item.isExist(i))
                {
                    return false;
                }
            }
            return true;
        }

        public void CopyTo(Computer[] array, int arrayIndex)
        {
            for(int i=0;i<array.Length&&i<luser.Count;i++)
            {
                array[i].luser[0] = luser[i];
            }
        }

        public bool Remove(Computer item)
        {
            foreach (var i in item.luser)
            {
               luser.Remove(i);
            }
            return true;
        }

        IEnumerator<Computer> IEnumerable<Computer>.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
