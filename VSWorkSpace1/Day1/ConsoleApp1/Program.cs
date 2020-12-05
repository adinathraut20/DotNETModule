using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void oldMain(string[] args)
        {
            System.Console.WriteLine("Hello World");
            System.Console.ReadLine();
        }
        static void Main()
        {
            Class1 o;
            o = new Class1();
            o.Display();
           // o.Add(10);
            o.Add(20);
            o.Add(30, 3);
            o.Add(70, 1, 2);
            o.Add(80, 6, 8, 5);
            o.Add(10, d: 90);
            int e = Convert.ToInt32(Console.ReadLine());
            int f = Convert.ToInt32(Console.ReadLine());
            o.ReadAdd(e, f);
            o.printto(e);
            o.Add2(w : 10, q: 10);

        }
    }

    public class Class1
    {
        public void Display()
        {
            Console.WriteLine("hi there...");
        }
        public void Add(int a, int b=1, int c=2, int d =0)
        {
            System.Console.WriteLine("a = {0} , b =  {1} ,  c = {2} ,  d = {3}",a,b,c,d);
        }
        
        public void Add2(int q , int w)
        {
            System.Console.WriteLine("q = " + q + " w = " + w);
        }

        public void ReadAdd(int a,int b)
        {
            System.Console.WriteLine("sum = " + (a + b));

        }

        public void printto(int n)
        {
            for(int i = 0; i <= n; i++)
            {
                Console.WriteLine(i);
            }
        }
    }
}
