using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    class Class1
    {

            static void Main2()
            {
            
           // SClass.Func1();
            SClass s1;
            Console.WriteLine("hi");
            s1 = new SClass();


            }
     }

        class SClass
        {
            static int i = 0;
            private int no;

            static SClass()
            {
                Console.WriteLine("Static Constructor");
            }
            public SClass()
            {

                Console.WriteLine("Normal Constructor");
            }

            public int fun2()
            {
                return no * i;
            }
            public  static int Func1()
            {
                
                Console.WriteLine("Static func call");
                return i * 20;
            }
        
    

        }

   
}
