using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day6
{
    public delegate void del1(string str);
    class Program
    {
        static void Main(string[] args)
        {
            del1 fun1 = new del1(display);
            fun1("From Mars");
            
        }
        static void display(string str)
        {
            Console.WriteLine(str);
        }

    }
}
