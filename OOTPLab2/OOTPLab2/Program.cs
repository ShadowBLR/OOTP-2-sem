using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace OOTPLab2
{
    class Program
    {

        static void Main(string[] args)
        {
            bool b = true;//true or false
            byte bt = 120;// 1 .. 255
            sbyte sBt = 12;//-128..127
            short sh = 13213;//-32768..32767
            ushort uSh = 65000;//0,,65535
            int i = 12300000;//-2147483648 .. 2147483647
            uint uI = 4032421;//0 .. 4294967295
            long l = -66637771232123;//9 223 372 036 854 775 808 .. 9 223 372 036 854 775 807
            ulong uL = 12371238123123;//0 .. 18 446 744 073 709 551 615
            char ch = 'a';
            decimal dc = 13124.213123M;//16 byte.28 symbol
            float f = -2142.213124123421F;
            double d = -12331.3214214214124D;

            Console.WriteLine("{0}\n{1}\n{2}\n{3}\n{4}\n{5}\n{6}\n{7}\n{8}\n{9}\n{10}" +
               "\n{11}\n{12}\n\n", b,bt,sBt,sh,uSh
                ,i,uI,l,uL,ch,dc,f,d);

            Console.WriteLine("{0}\n{1}\n{2}\n{3}\n", (int)d, Convert.ToBoolean(i),
               Convert.ToString(l)+"haha",Convert.ToDouble(sh)) ;

            Console.WriteLine("{0}\n{1}\n{2}\n{3}\n{4}\n", d+i,sh+i,f+d,dc+i,ch+uSh);

            //упаковка
            int abc = 123;
            object o = 123;
            //распаковка
            int shObject = (int)o;

            var notType = "str";

            Nullable<int> z = null;//int?z = null;
             if(z.HasValue)
                Console.WriteLine(z);
             else
                Console.WriteLine("z not defined");
            z = 2323;

            if (z.HasValue)
                Console.WriteLine(z.Value);
            else
                Console.WriteLine("z not defined");

            //строки
            string str1 = "Hello, world";
            string str2 = "Privet, mir";
            Console.WriteLine(String.Compare(str1,str2));

            string str3 = "Mama mila ramy ";
            string str4 = "I not understand";
            string str5 = str3 + str4;
            str3 = String.Copy(str5);
            Console.WriteLine(str3);
            str5=str5.Insert(0," this is the end");
            Console.WriteLine(str5);

            Console.WriteLine($"|{"Left",-7}|{"Right",7}|");

            StringBuilder stringBuilder = new StringBuilder("Mama mila ramy");
            stringBuilder.Remove(1, 3);
            stringBuilder.Remove(8, 2);
            stringBuilder.Insert(0,"aAbB");
            stringBuilder.Insert(stringBuilder.Length, "zZxX");
            Console.WriteLine(stringBuilder);

            //массивы
            int[,] arr = { {14221, 12412, 4234, 123 },{3123,5555,12321,5344 }, { 234, 5355, 21, 534 }
            ,{347,7775,1943,515 }} ;
            for(int k=0;k<Math.Sqrt(arr.Length);k++)
            {
                for(int m=0;m < Math.Sqrt(arr.Length);m++)
                    Console.Write($"{arr[k,m],-6}");
                Console.WriteLine();
            }

            string[] cars = { "Volvo", "BMW", "Ford", "Mazda" };
            Console.WriteLine("Размер массива = "+cars.Length);
           for(int k=0;k<cars.Length;k++)
            Console.Write($"{cars[k]}\t");

            
            int position;
            do
            {
                Console.WriteLine("Введите индекс массива для замены");
                position =  Convert.ToInt32(Console.ReadLine());
            } while (position < 0 || position > cars.Length-1);


            Console.WriteLine("Введите строку для замены");
            string buff = Console.ReadLine();
            
            cars[position] = buff;

            for (int k = 0; k < cars.Length; k++)
                Console.Write($"{cars[k]}\t");
            int rows=3;
            Console.WriteLine();
            string[][] arrStep=new string[rows][];
            arrStep[0] = new string[2];
            arrStep[1] = new string[3];
            arrStep[2] = new string[4];
            int size=0;
            for (int k = 0; k < arrStep.Rank; k++)
                size += arrStep[k].Length;

            for (int k = 0; k < arrStep.Length; k++)
                for (int j = 0; j < arrStep[k].Length; j++)
                    arrStep[k][j] = Console.ReadLine();


            for (int k = 0; k < arrStep.Length; k++)
            {
                for (int j = 0; j < arrStep[k].Length; j++)
                {
                    Console.Write($"{ arrStep[k][j],-4}");
                }
                Console.WriteLine();
            }

            var strNotType = "Ha-ha,classik";
            var arrNotArr = new int[,] { { 12, 13, 2 }, { 3, 2, 1 }, { 34, 2, 1 } };
            var arrTwoNotArr = new int[] { 214, 42, 532 };

            //кортежи   
             (int,string,char,string,ulong) tuple = (124,"prikol",'a',"eshe prikol",523523523);

          
                Console.WriteLine($"{tuple.Item1} {tuple.Item2}  {tuple.Item3} {tuple.Item4} {tuple.Item5}");
            int iTuple = tuple.Item1;
            int _;
            ( int, string, char,string,ulong) tuple2 = (5555555,"str1" ,'a', "str2",788554);
            Console.WriteLine(tuple==tuple2);

            (int,int,int,char) localFunction(int[] localArr,string localStr )
            {
                int max = localArr.Max();
                int min = localArr.Min();
                int sum = 0;
                char firstSymbol = 'a';
                for (int k = 0; k < localArr.Length; k++)
                    sum += localArr[k];
                

                return (max, min, sum, firstSymbol);
            }
            Console.WriteLine(localFunction(arrTwoNotArr, strNotType) ); 
        }
    }
}
