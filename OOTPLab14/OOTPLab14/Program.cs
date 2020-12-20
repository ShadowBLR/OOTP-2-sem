using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Xml;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.Text.Json;

namespace OOTPLab14
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Author a1 = new Author("Ivan", "Ivanov", 28, 10, 2001);
                Author a2 = new Author("Petya", "Petrov", 8, 1, 1991);
                Author a3 = new Author("Sergey", "Sergeevich", 13, 7, 2000);
                Author a4 = new Author("Nicolai", "Nicolaevich", 8, 5, 1997);

                Console.WriteLine("=================BynaryFormatter==================");
                BinaryFormatter bf = new BinaryFormatter();
                using(FileStream fs = new FileStream("Authors.dat",FileMode.Create))
                {
                    bf.Serialize(fs, a1);
                    Console.WriteLine("a1 сериализован");
                }

                using (FileStream fs = new FileStream("Authors.dat",FileMode.Open))
                {
                    Author newAuthor1 = (Author)bf.Deserialize(fs);
                    Console.WriteLine("a1 десериализован");
                    Console.WriteLine($"{newAuthor1.FirstName}\n{newAuthor1.LastName}\n{newAuthor1.BirthDay}\n" +
                        $"{newAuthor1.BirthMonth}\n{newAuthor1.BirthYear}");
                }

                //=======================SOAP=================
                Console.WriteLine("=======================SOAP=================");
                SoapFormatter sf = new SoapFormatter();
                using (FileStream fs = new FileStream("AuthorsSoap.dat",FileMode.Create))
                {
                    sf.Serialize(fs, a2);
                    Console.WriteLine("a2 сериализован");
                }
                using (FileStream fs = new FileStream("AuthorsSoap.dat", FileMode.Open))
                {
                    Author newAuthor2 = (Author)sf.Deserialize(fs);
                    Console.WriteLine("a2 десериализован");
                    Console.WriteLine($"{newAuthor2.FirstName}\n{newAuthor2.LastName}\n{newAuthor2.BirthDay}\n" +
                      $"{newAuthor2.BirthMonth}\n{newAuthor2.BirthYear}");
                }


                //========================XML=================
                Console.WriteLine("========================XML=================");

                XmlSerializer xmls = new XmlSerializer(typeof(Author));
                using (FileStream fs = new FileStream("Authors.xml", FileMode.Create))
                {
                    xmls.Serialize(fs, a3);
                    Console.WriteLine("a3 сериализован");
                }
                using (FileStream fs = new FileStream("Authors.xml", FileMode.Open))
                {
                    Author newAuthor3 = (Author)xmls.Deserialize(fs);
                    Console.WriteLine("a3 десериализован");
                    Console.WriteLine($"{newAuthor3.FirstName}\n{newAuthor3.LastName}\n{newAuthor3.BirthDay}\n" +
                      $"{newAuthor3.BirthMonth}\n{newAuthor3.BirthYear}");
                }

                //=============================JSON=======================
                /*
                                JsonSerializer js = new JsonSerializer();
                                using (FileStream fs = new FileStream("Authors.json", FileMode.OpenOrCreate))
                                {
                                    js.Serialize(fs, a4);
                                    Console.WriteLine("a4 сериализован");
                                }
                                using (FileStream fs = new FileStream("Authors.json", FileMode.OpenOrCreate))
                                {
                                    Author newAuthor3 = (Author)xmls.Deserialize(fs);
                                    Console.WriteLine("a3 десериализован");
                                    Console.WriteLine($"{newAuthor3.FirstName}\n{newAuthor3.LastName}\n{newAuthor3.BirthDay}\n" +
                                      $"{newAuthor3.BirthMonth}\n{newAuthor3.BirthYear}");
                                }*/

                Console.WriteLine("===========JSON=============");
                string json = JsonSerializer.Serialize<Author>(a4);
                Console.WriteLine("a4 сериализован:");
                Console.WriteLine(json);
                
                Author jsonAuthor = JsonSerializer.Deserialize<Author>(json);
                Console.WriteLine("jsonAuthor десериализован:");
                Console.WriteLine(jsonAuthor);

                //========================Коллекция===================
                Console.WriteLine("========================Коллекция===================");

                Author[] arrAuthor = { a1, a2, a3, a4 };
                XmlSerializer xmlsArr = new XmlSerializer(typeof(Author[]));
                using (FileStream fs = new FileStream("AuthorsArray.xml", FileMode.Create))
                {
                    xmlsArr.Serialize(fs, arrAuthor);
                    Console.WriteLine("arrAuthor сериализован");
                }
                using (FileStream fs = new FileStream("AuthorsArray.xml", FileMode.Open))
                {
                    Author []AuthorsArr = (Author[])xmlsArr.Deserialize(fs);
                    Console.WriteLine("arrAuthor десериализован");
                    foreach (var a in AuthorsArr)
                    {
                        Console.WriteLine($"{a.FirstName}\n{a.LastName}\n{a.BirthDay}\n" +
                        $"{a.BirthMonth}\n{a.BirthYear}");
                    }
                }

                //================xPath=========================
                Console.WriteLine("====================xPath=====================");
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load("AuthorsArray.xml");
                XmlElement xRoot = xDoc.DocumentElement;

                //выбор всех дочерних узлов
                XmlNodeList childNodes = xRoot.SelectNodes("*");
                foreach(XmlNode n in childNodes)
                {
                    Console.WriteLine(n.OuterXml);
                }
                Console.WriteLine();
                
                //Выбор всех авторов с Nicolai в тэге FirstName
                XmlNode node = xRoot.SelectSingleNode("Author[FirstName='Nicolai']");
                Console.WriteLine(node.OuterXml);

                //===============JSON LINQ===================
                JObject jo = JObject.Parse(@"{
'Author': 'Лев Толстой',
'Date birth':[
    '28',
    '10',
    '2001'
]
}");
                string auth = (string)jo["Author"];
                Console.WriteLine($"One:{auth}");

                string firstDate = (string)jo["Date birth"][0];
                Console.WriteLine($"Two:{firstDate}");

                IList<string> ilst = jo["Date birth"].Select(t => (string)t).ToList();

                foreach(var i in ilst)
                {
                    Console.WriteLine(i);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
