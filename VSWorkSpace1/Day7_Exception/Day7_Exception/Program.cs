using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day7_Exception
{
    class Program
    {
        static void Main1(string[] args)
        {
            Func1();
        }
        static void Func1()
        {
            int i = 0;
            i = 1 / i;
        }
        static void Main3(string[] args)
        {
            Class1 obj = new Class1();
            try
            {
                obj = null;
                int x = Convert.ToInt32(Console.ReadLine());

            }
            catch
            {
                Console.WriteLine("Exception occured");
            }
            //Console.ReadLine();

        }
        static void Main(string[] args)
        {
            Class1 obj = new Class1();
            try
            {
                obj = null;
                int x = Convert.ToInt32(Console.ReadLine());
                obj.P = 100 / x;

            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("DBExpt occured");
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("NR EXCpt");
            }
            catch (Exception ex)
            {
                Console.WriteLine("other exception");
            }
            finally
            {
                Console.WriteLine("finally");
            }
        }
    }
        class Class1
        {
            private int p;
            public int P {
                get
                {
                    return p;
                }
                set
                {
                    if (value < 100)
                    {
                        p = value;
                    }
                    else
                    {
                        Exception ex;
                        ex = new Exception();
                        throw ex;

                    }
                }

        }
    }
}
