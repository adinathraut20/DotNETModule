using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;


//calling a method asynchronously using delObj.BeginInvoke(....
namespace AsyncCodeWithDelegates1
{
    class Program
    {
        static void Main21()
        {
            Console.WriteLine("Before");
            Action o = Display;
            o.BeginInvoke(null, null);
            Console.WriteLine("After");
            Console.ReadLine();
        }
        static void Display()
        {
            System.Threading.Thread.Sleep(5000);
            Console.WriteLine("Display");
        }
    }
}

//calling a method with parameters asynchronously using delObj.BeginInvoke(....
namespace AsyncCodeWithDelegates2
{
    class Program
    {
        static void Main2()
        {
            Console.WriteLine("Before");
            Action<string> o = Display;
            o.BeginInvoke("aaa", null, null);
            Console.WriteLine("After");
            Console.ReadLine();
        }
        static void Display(string s)
        {
            System.Threading.Thread.Sleep(5000);
            Console.WriteLine("Display" + s);
        }
    }
}

//calling a method with parameters asynchronously using delObj.BeginInvoke(....
//also using a callback func
namespace AsyncCodeWithDelegates3
{
    class Program
    {
        static void Main22()
        {
            Console.WriteLine("Before");
            Func<string, string> o = Display;
            IAsyncResult ar = o.BeginInvoke("aaa", CallBackFunc, null);
            ar.AsyncWaitHandle.WaitOne();

            Console.WriteLine("After");
          //  Console.ReadLine();
        }
        static string Display(string s)
        {
            System.Threading.Thread.Sleep(5000);
            Console.WriteLine("Display" + s);
            return s.ToUpper();
        }

        static void CallBackFunc(IAsyncResult ar)
        {
            Console.WriteLine("callback func called");
        }
    }
}

//calling a method with parameters asynchronously using delObj.BeginInvoke(....
//also using a callback func ( as an anon method - to enable us to access objDel in the callback func) 
//get the return value with objDel.EndInvoke
namespace AsyncCodeWithDelegates4
{
    class Program
    {
        static void Main23()
        {
            Console.WriteLine("Before");
            Func<string, string> o = Display;
            IAsyncResult ar1 =  o.BeginInvoke("aaa", delegate (IAsyncResult ar)
            {
                Console.WriteLine("callback func called");
                string retval = o.EndInvoke(ar);
                Console.WriteLine("retval = " + retval);
            }, null);

           
            Console.WriteLine("After");

            ar1.AsyncWaitHandle.WaitOne();
           // Console.ReadLine();
        }
        static string Display(string s)
        {
            System.Threading.Thread.Sleep(5000);
            Console.WriteLine("Display" + s);
            return s.ToUpper();
        }


    }
}

//calling a method with parameters asynchronously using delObj.BeginInvoke(....
//using a callback func
//pass the delegate object as ar.AsyncState. This allows us to call delObj.EndInvoke to get the return value
namespace AsyncCodeWithDelegates5
{
    class Program
    {
        static void Main11()
        {
            Console.WriteLine("Before");
            Func<string, string> o = Display;
            //IAsyncResult ar = o.BeginInvoke("aaa", CallBackFunc, "extra data passed to callback func");
            IAsyncResult ar = o.BeginInvoke("aaa", CallBackFunc, o);
            Console.WriteLine("After");
            Console.ReadLine();
        }
        static string Display(string s)
        {
            System.Threading.Thread.Sleep(5000);
            Console.WriteLine("Display" + s);
            return s.ToUpper();
        }

        static void CallBackFunc(IAsyncResult ar)
        {
            Console.WriteLine("callback func called");
            //string extraData = ar.AsyncState.ToString();
            //Console.WriteLine(extraData);
            Func<string, string> o = (Func<string, string>)ar.AsyncState;
            string retval = o.EndInvoke(ar);
            Console.WriteLine(retval);
        }
    }
}

//calling a method with parameters asynchronously using delObj.BeginInvoke(....
//also using a callback func  
//in the callback func get the delegate object as AsyncResult.AsyncDelegate. This allows us to call delObj.EndInvoke to get the return value
namespace AsyncCodeWithDelegates6
{
    class Program
    {
        static void Main1()
        {
            Console.WriteLine("Before");
            Func<string, string> o = Display;
            IAsyncResult ar = o.BeginInvoke("aaa", CallBackFunc, null);
            Console.WriteLine("After");
            Console.ReadLine();
        }
        static string Display(string s)
        {
            System.Threading.Thread.Sleep(5000);
            Console.WriteLine("Display" + s);
            return s.ToUpper();
        }

        static void CallBackFunc(IAsyncResult ar)
        {
            AsyncResult result = (AsyncResult)ar;


            Console.WriteLine("callback func called");
            //Func<string, string> o = (Func<string, string>)ar.AsyncState;
            //string retval = o.EndInvoke(ar);
            //Console.WriteLine(retval);

            Func<string, string> o = (Func<string, string>)result.AsyncDelegate;
            string retval = o.EndInvoke(ar);
            Console.WriteLine(retval);


        }
    }
}



//calling a method asynchronously using delObj.BeginInvoke(....
namespace AsyncCodeWithDelegates
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Before");
            Action o = Display;
            IAsyncResult ar = o.BeginInvoke(null, null);
            Console.WriteLine("After");

            //while (!ar.IsCompleted) ;
            ar.AsyncWaitHandle.WaitOne();  //waits for the thread to finish execution. Like Thread.Join
            //Console.ReadLine();
        }
        static void Display()
        {
            System.Threading.Thread.Sleep(5000);
            Console.WriteLine("Display");
        }
    }
}
