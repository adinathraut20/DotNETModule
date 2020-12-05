using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    class Class2
    {
        static void Main()
        {

            Derived d1 = new Derived(4);

            Base b1 = new Base();
            //Console.WriteLine(b1.X);
            Derived d2 = new Derived();

           // GC.Collect();
        }
    }

    public class Base
    {
        private int x;  //access with in class
        protected int y; // access with in derived class
        internal int z;  // access within assembly
        internal protected int a; // both child class or within assembly
        public int b; // everywhere

        
        public Base()
        {
            Console.WriteLine("Base const call");
        }
        public Base(int x) 
        {
            Console.WriteLine("Base para const call");
            this.x = x;
        }
        ~Base()
        {
            Console.WriteLine("Base Destructor call");
        }
    }

    public class Derived :  Base {
        
        public Derived()
        {
            Console.WriteLine("Dervied construct call");
        }

        public Derived(int x) : base(x)
        {
            Console.WriteLine("para derived constructor");
        }

        ~Derived()
        {
            Console.WriteLine("Derived Destructor call");
        }
    } 
}
