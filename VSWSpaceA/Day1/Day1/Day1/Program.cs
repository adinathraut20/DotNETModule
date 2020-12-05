using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Animal.omnivour.Man;
using Organization.Company;

using Device;

namespace Day1
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Console.WriteLine("hiiiiiii");
            string str = Console.ReadLine();
            Console.WriteLine(str);
            Console.Write("hii \n ");
            Console.WriteLine("Bye");*/

            Student s1 = new Student();
            Console.WriteLine(s1.Add(1, 2, 3));
            Console.WriteLine(s1.Add(1, 2));
            Console.WriteLine(s1.Add());

            Console.WriteLine("  ");
            s1.Add2(1, 2, 3);
            Console.WriteLine(s1.Add2( a : 10, b : 20));
            s1.fun(2, 3, 1);
            s1.fun(divisor: 2, mul1: 2, mul2: 4);

            Organization.Company.Emp e1 = new Organization.Company.Emp();
            Console.WriteLine(e1.name);

            Emp e2 = new Emp();
            Console.WriteLine(e2.name);

            Bird q1 = new Bird();
            Console.WriteLine(q1.name);

            Male m1 = new Male();
            Console.WriteLine(m1.getName());

            Animal.A A1 = new Animal.A();
            Console.WriteLine(A1);
            Console.WriteLine(A1.name);

           
            C1.C11 y2 = new C1.C11();
            Console.WriteLine(y2.name);
        }    
    }

    class Student
    {
        public int Add(int a=1, int b=2, int c=10)
        {
            return a + b + c;
        }

        public int Add2(int a,int b, int c=0)
        {
            Console.WriteLine("a = "+a+" b = "+b+" c = "+c);
            return a + b + c;
        }

        public int fun(int mul1=1, int mul2=1 ,int divisor=1)
        {
            return mul1 * mul2 / divisor;
        }

    }
}

namespace Organization{

    class Emp
    {
        
    }

    namespace Company
    {
        class Emp
        {
            public string name = "aish";

        }

        
        class Manager
        {

        }
    }

}

class Bird
{
    public string name = "home";
}

namespace Animal
{
    namespace omnivour
    {
        namespace Man
        {
            class Male
            {
                private string  name = "Adam";
                public string getName()
                {
                    return name;
                }
            }
        }
    }
}

namespace Animal
{
    class A
    {
        public string name = "A";
    }
}

namespace Device
{
    class C1
    {
        public string name = "c1";
        public class C11
        {
            public string name = "c11";
        }
    }
}
