using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    class Emp
    {
        static void Main3()
        {
            Class2 c1 = new Class2();
            
        }
    }

    class Class2
    {
        private int p1;
        private static int s1;

        static Class2()
        {
            s1 = 100;
        }
        public Class2() => p1 = 0;

       /* public Class2()
        {
            p1 = 0;
        }
       */

        public static void display()
        {
            Console.WriteLine("Static Mehtod Call");
        }
        public int P1
        {
            get
            {
                return p1;
            }
            set
            {
                if (value < 100)
                {
                    p1 = value;
                }
                else
                {
                    Console.WriteLine("Invalid value") ;
                }
            }
        }
        public static int S1
        {
            get
            {
                return s1;
            }
            set
            {
                s1 = value;
            }
        }

        public static class s_Class3
        {
            //can only have static members
            //cannot be instantiated
            //cannot be used as a base class
        }
    }
}
