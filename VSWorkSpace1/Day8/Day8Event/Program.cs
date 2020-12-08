using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day8Event
{
    class Program
    {
        static void Main(string[] args)
        {
            Action o1 = Display;
            o1();
            Action<string> o2 = Display;
            o2("AAA");
            Action<string, int> o3 = Display;
            o3("bbb", 3);

            Console.WriteLine("----------Func<>--------------");

            Func<int, int,int> f1 = Add;
            Console.WriteLine(f1(10,20));

            Func<string, short, int> f2 = Add;
            Console.WriteLine(f2("adi",3));

            Func<int, bool> f3 = IsEven;
            Console.WriteLine(f3(10));

            Console.WriteLine("-----------Predicate<>-------------");
            Predicate<int> p1 = IsEven;
            Console.WriteLine(p1(21));

            Action a1 = delegate { Console.WriteLine("Anonymous method called"); };
            Action a2 = delegate () { 
                Console.WriteLine("Anonymous call");
            };
            a1();
            a2();

            Func<int, int, int> f5 = delegate (int a, int b) { return a + b; };
            Console.WriteLine(f5(10, 20));

            Func<int, int> f6 = x => x * 2;
            Console.WriteLine(f6(2));

            Func<int, int, int> f8 = (a, b) => a - b;
            Console.WriteLine(f8(40,50));


        }
        static bool IsEven(int a)
        {
            return a % 2 == 0;
        }
        static int Add(int a,int b)
        {
            return a + b;
        }
        static int Add(string a, short b)
        {
            return 1;
        }
        static void Display()
        {
            Console.WriteLine("Display");
        }
        static void Display(string s)
        {
            Console.WriteLine("Display "+s);
        }
        static void Display(string s, int i)
        {
            Console.WriteLine("Display " + s + i);
        }
    }
}
