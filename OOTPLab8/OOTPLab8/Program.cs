using OOTPLab05;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOTPLab8
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "class.txt";
            try
            {
                /*          CollectionType<int> colltype = new CollectionType<int>();
                            colltype.Add(14);
                            colltype.Add(-124);
                            colltype.Add(14321);
                            colltype.Add(124);
                            colltype.Add(4);
                            colltype.Add(1);
                            colltype.PrintAll();
                            Console.WriteLine("remove 4");
                            colltype.Remove(4);
                            colltype.PrintAll();
                            Console.WriteLine("remove 13");
                            colltype.Remove(13);
                            colltype.PrintAll();*/

                CollectionType<PrintEdition> collTypePe = new CollectionType<PrintEdition>();
                collTypePe.Add(new PrintEdition(15, "1984", 1948, new Author("Ya", "Ya", 28, 10, 2001), new COST()));
                collTypePe.Add(new PrintEdition(125, "Божественная комедия", 1348, new Author("Данте", "Олигьери", 28, 10, 2001), new COST()));
                collTypePe.RemoveLastNode();
                collTypePe.PrintAll();

                collTypePe.SaveInfFile(path);
                collTypePe.ReadFromFile(path);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.Source);
            }
            finally
            {
                Console.WriteLine("\nБлок finally выполняется всегда");
            }
            Console.ReadLine();
        }
    }
}
