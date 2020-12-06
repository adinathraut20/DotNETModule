using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day6
{
    //step 1: create a delegate class having same signature as function to call
    public delegate void Del1();
    public delegate void Del2(int x);
    class Program1
    {
        static void Main1()
        {
            //step 2 : create a delegate object the function name as a parameter
            Del1 objDel = new Del1(display);
            Del2 objDel2 = new Del2(display1);

            //step 3 : call the func via delegate obj
            objDel();
            objDel2(1);
        }
        static void Main2()
        {
            //step 2 : create a delegate object the function name as a parameter
            Del1 objDel = new Del1(display);
            objDel += new Del1(show);

            //step 3 : call the func via delegate obj
            objDel();
            Console.WriteLine("-----------------");
            // objDel();
            objDel += new Del1(show);
            objDel();

            Console.WriteLine("-----------------");
            objDel += new Del1(display);
            objDel();

            Console.WriteLine("-----------------");
            objDel -= new Del1(show);
            objDel();

        }
        static void Main()
        {
            Del1 objDel1 = (Del1)Delegate.Combine(new Del1(display), new Del1(show), new Del1(display));
            objDel1();
            Console.WriteLine("-------------");
            objDel1 = (Del1)Delegate.Remove(objDel1, new Del1(display));
            objDel1();

            Stack<int> s1 = new Stack<int>();
            s1.Push(1);
            s1.Push(2);
            s1.Push(4);
            s1.Push(5);
            s1.Push(6);
            s1.Push(7);

            foreach(int i in s1)
            {
                Console.WriteLine(i);
            }
        }
        static void display()
        {
            Console.WriteLine("Display function call");
        }
        static void show()
        {
            Console.WriteLine("show function call");
        }
        static void display1(int x)
        {
            Console.WriteLine("display 1 para: "+x);
        }
    }
}
