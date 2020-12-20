using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOTPLab07
{
    class Controller
    {
        public Library library;
        public Controller() { }
        public Controller(Library lib)
        {
            library = lib;
        }
        public void PrintByYearOfPublishing(int year)
        {
            for(int i=0;i<library.printings.Count;i++)
                if(library.printings[i].GetYearOfPublishing()<year&& library.printings[i].GetYearOfPublishing()!=-1)
                {
                    Console.WriteLine("Издание найдено");
                    library.printings[i].PrintAuthorInfo();
                }
        }
        public int CountOfMagazines()
        {
            int count = 0;
            for (int i = 0; i < library.printings.Count; i++)
                if (library.printings[i] is Magazine)
                    count++;
            return count;
        }
        public int TotalPrice()
        {
            int price = 0;
            for (int i = 0; i < library.printings.Count; i++)
                if (library.printings[i] is PrintEdition)
                    price += (library.printings[i] as PrintEdition).PRICE.Price;
            return price;
        }
    }
}
