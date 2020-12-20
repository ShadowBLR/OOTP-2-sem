using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOTPLab05
{
    public partial class Library
    {
        public Library()
        {
            printings.Add(new Book(100, "Война и мир", 1850, "Лев", "Толстой", 28, 10, 2001, "Роман"));

        }
        public IPrinting Get(int i)
        {
            return printings[i];
        }
        public bool Set(int i, PrintEdition pe)
        {
            if (i > 0 && i < printings.Count)
            {
                printings[i-1] = pe;
                return true;
            }
            return false;
        }
        public void PrintElementFromLibrary(int i)
        {
            if (printings[i] != null)
            {
                printings[i].SayHello();
                printings[i].PrintAuthorInfo();
            }
        }
        public void PrintAllElementsFromLibrary()
        {
            for (int i = 0; i < printings.Count; i++)
            {
                PrintElementFromLibrary(i);
            }
        }
        public void AddElementFromLibrary(IPrinting pe)
        {
            printings.Add(pe);
        }
        public bool RemoveElementFromLibrary(IPrinting pe)
        {
            return printings.Remove(pe);
        }
    }
}
