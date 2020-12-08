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
            Console.WriteLine();



            Emp e3 = new Emp(3, 3, "adi", 27000);
            Console.WriteLine(e3.name+" "+e3.count1());


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

    partial class Emp
    {
        private int count;
        public int empId { get; set; }
        public Emp(int count,int empId,string name,int basic)
        {
            this.count = count;
            this.empId = empId;
            this.name = name;
        }
    }
    partial class Emp
    {
        public string name { get; set; }

        public string getName()
        {
            return name;
        }
       
    }

}

namespace LanguageFeatures
{

    partial class Emp
    {
        public int basic { get; set; }

        public int count1()
        {
            return count;
        }
    }

}
