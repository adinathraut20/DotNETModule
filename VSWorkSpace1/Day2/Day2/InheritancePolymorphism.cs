using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    class InheritancePolymorphism
    {
        static void Main()
        {
            Console.WriteLine("A ref and A object display call");
            A a1 = new A();
            a1.display(); // A display
            a1.display1(); // A display1
            a1.display2(); // A display2
            a1.display3(); // A display3

            Console.WriteLine("B ref and B object display call");
            B b1 = new B();
            b1.display(); // A display
            b1.display1(); // B display1
            b1.display2(); // B display2
            b1.display3(); // B display3

            Console.WriteLine("A ref and B object call");
            A ab1 = new B();
            ab1.display(); // A display
            ab1.display1(); // A display1
            ab1.display2(); // A display2
            ab1.display3(); // B display3

            Console.WriteLine("C ref and C object display call");
            C c1 = new C();
            c1.display(); // A display
            c1.display1(); // C display1
            c1.display2(); // C display2
            c1.display3(); // C display3

            Console.WriteLine("B ref and C object display call");
            B bc1 = new C();
            bc1.display(); // A display
            bc1.display1(); // B display1
            bc1.display2(); // B display2
            bc1.display3(); // C display3

            Console.WriteLine("A ref and C object display call");
            A ac1 = new C();
            ac1.display(); // A display
            ac1.display1(); // A display1
            ac1.display2(); // A display2
            ac1.display3(); // C display3


        }
    }
    class A {
        public void display()
        {
            Console.WriteLine("A display");
        }
        public void display1()
        {
            Console.WriteLine("A display1");
        }
        public void display2()
        {
            Console.WriteLine("A display2");
        }
        public virtual void display3()
        {
            Console.WriteLine("A display3");
        }
        
    }
    class B : A
    {
        public void display1() //display1 method hides its parent class display1 method
        {
            Console.WriteLine("B display1");
        }
        public new void display2() 
        {
            Console.WriteLine("B display2");
        }

        public override void display3()
        {
            Console.WriteLine("B display3");
        }
    }
    class C : B
    {
        public void display1()  //display1 method hides its parent class display1 method
        {
            Console.WriteLine("C display1");
        }
        public new void display2() //this display2 cannot be sealed beacause it is not overrided
        {
            Console.WriteLine("C display2");
        }

        public sealed override void display3()  //sealed means function cannot be further overrided
        {
            Console.WriteLine("C display3");
        }
    }

}
