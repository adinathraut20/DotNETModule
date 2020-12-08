using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageFeatures
{
    class Program
    {
        static void Main(string[] args)
        {
            //int i;
            var i2 = 100;  //implicit variable
            i2 = 200;
            Console.WriteLine(i2.GetType().ToString());
            Class1 c1 = new Class1 { i = 3 };
            c1.display();

            //Anonymous type
            var myCar = new { color = "Red1", Model = "ferrari", speed = 75 };
            var myCar2 = new { color = "Red", Model = "ferrari" };
            Console.WriteLine(myCar.color+" "+myCar2.Model);
            Console.WriteLine(myCar.GetType());
            Console.WriteLine(myCar2.GetType());
        }

    }
    class Class1
    {
        public int i { get; set; }
        public void display()
        {
            Console.WriteLine("display "+i);
        }
    }

}
