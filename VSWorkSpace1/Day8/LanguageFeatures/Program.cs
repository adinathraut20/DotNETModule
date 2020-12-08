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
        }
    }
}
