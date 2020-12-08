using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    class Program
    {
        static void Main10(string[] args)
        {
            //create an object of Class1
            Class1 objClass1 = new Class1();

            //make the event (delegate object) point to the event handler function written by us
            objClass1.InvalidP1 += objClass1_InvalidP1;

            //event is fired only if value >99
            objClass1.P1 = 1111;
            Console.ReadLine();
        }

        static void objClass1_InvalidP1()
        {
            Console.WriteLine("invalidP1 event code here");
        }
    }


    //step 1: create a delegate class having th esame signature as the event handler function
    public delegate void InvalidP1EventHandler();


    //programmer writes this class
    public class Class1
    {
        //step 2 : Declare the event of the delegate class type (delegate object)
        public event InvalidP1EventHandler InvalidP1;

        private int p1;
        public int P1
        {
            get
            {
                return p1;
            }
            set
            {
                if (value < 100)
                    p1 = value;
                else
                {
                    //raise the event here
                    //Step 3 : call the delegate object
                    InvalidP1();
                }
            }
        }

    }

    class EventHand
    {
        public delegate void InvalidHand();
        static void Main(string[] args)
        {
            event1 e1 = new event1();
            e1.ivh += disp;

            e1.N = 1000;
        //    e1.ivh += E1_ivh;
            e1.N = 1000;


        }

        private static void E1_ivh()
        {
            throw new NotImplementedException();
        }

        static void disp()
        {
            Console.WriteLine("display called ");
        }
        class event1
        {
            public event InvalidHand ivh;
            private int n;
            public int N
            {
                set
                {
                    if (value < 100)
                    {
                        n = value;
                    }
                    else
                    {
                        ivh();
                    }
                }
            }
        }
    }
    
}

namespace EventHandling2
{
    class Program
    {
        static void Main2()
        {
            //create an object of Class1
            Class1 objClass1 = new Class1();

            //make the event (delegate object) point to the event handler function written by us
            objClass1.InvalidP1 += objClass1_InvalidP1;
            objClass1.InvalidP1 += Handler2;

            //event is fired only if value >99
            objClass1.P1 = 1111;

            Console.WriteLine();
            objClass1.InvalidP1 -= objClass1_InvalidP1;
            objClass1.InvalidP1 -= Handler2;
            objClass1.P1 = 1111;

            Console.ReadLine();
        }

        static void objClass1_InvalidP1()
        {
            Console.WriteLine("invalidP1 event code here");
        }
        static void Handler2()
        {
            Console.WriteLine("invalidP1 event code here also");
        }
    }


    //step 1: create a delegate class having th esame signature as the event handler function
    public delegate void InvalidP1EventHandler();


    //programmer writes this class
    public class Class1
    {
        //step 2 : Declare the event of the delegate class type (delegate object)
        public event InvalidP1EventHandler InvalidP1;

        private int p1;
        public int P1
        {
            get
            {
                return p1;
            }
            set
            {
                if (value < 100)
                    p1 = value;
                else
                {
                    //raise the event here
                    //Step 3 : call the delegate object
                    if (InvalidP1 != null)  //if no event handler funcs are assigned to the delegate object
                        InvalidP1();
                }
            }
        }
    }
}

namespace EventHandling3
{
    class Program
    {
        static void Main1()
        {
            ////create an object of Class1
            //Class1 objClass1 = new Class1();

            ////make the event (delegate object) point to the event handler function written by us
            //objClass1.InvalidP1 += objClass1_InvalidP1;

            ////event is fired only if value >99
            //objClass1.P1 = 1111;
            Console.ReadLine();
        }
        //static void objClass1_InvalidP1(int Value)
        //{
        //    Console.WriteLine("invalidP1 event code here");
        //    Console.WriteLine("value passed was : " + Value);

        //}

        static void Main7()
        {
            Class1 obj = new Class1();
            obj.InvalidP1 += Obj_InvalidP1;

        }

        private static void Obj_InvalidP1(int Value)
        {
            throw new NotImplementedException();
        }
    }


    //step 1: create a delegate class having the same signature as the event handler function
    public delegate void InvalidP1EventHandler(int Value);


    //programmer writes this class
    public class Class1
    {
        //step 2 : Declare the event of the delegate class type (delegate object)
        public event InvalidP1EventHandler InvalidP1;

        private int p1;
        public int P1
        {
            get
            {
                return p1;
            }
            set
            {
                if (value < 100)
                    p1 = value;
                else
                {
                    //raise the event here
                    //Step 3 : call the delegate object
                    if (InvalidP1 != null)
                        InvalidP1(value);
                }
            }
        }
    }
}