using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4
{
    public interface IDbFunctions
    {
        void Insert();
        void Update();
        void Delete();
    }
    public class Class11 : IDbFunctions
    {
        public void Delete()
        {
            Console.WriteLine("Class11 - IDb.Delete");
        }

        public void Display()
        {
            Console.WriteLine("Display");
        }

        public void Insert()
        {
            Console.WriteLine("Class1 - IDb.Insert");
        }

        public void Update()
        {
            Console.WriteLine("Class1 - IDb.Update");
        }
    }
}


namespace Interfaces2
{
    public interface IDbFunctions
    {
        void Insert();
        void Update();
        void Delete();
    }

    public class Class1 : IDbFunctions
    {
        public void Delete()
        {
            Console.WriteLine("Class1 - IDb.Delete");
        }

        public void Display()
        {
            Console.WriteLine("Display");
        }

        public void Insert()
        {
            Console.WriteLine("Class1 - IDb.Insert");
        }

        public void Update()
        {
            Console.WriteLine("Class1 - IDb.Update");
        }
    }
    public class Class2 : IDbFunctions
    {
        public void Delete()
        {
            Console.WriteLine("Class2 - IDb.Delete");
        }

        public void Show()
        {
            Console.WriteLine("Display");
        }

        public void Insert()
        {
            Console.WriteLine("Class2 - IDb.Insert");
        }

        public void Update()
        {
            Console.WriteLine("Class2 - IDb.Update");
        }
    }
    class Program
    {
        static void Main1()
        {
            Class1 o1 = new Class1();
            o1.Insert();
            Class2 o2 = new Class2();
            o2.Insert();

            //method 2
            IDbFunctions oIDb;
            oIDb = o1;
            oIDb.Insert();


            oIDb = o2;
            oIDb.Insert();
            Console.ReadLine();
        }
        static void Main2()
        {
            Class1 o1 = new Class1();
            Class2 o2 = new Class2();
            InsertMethod(o1);
            InsertMethod(o2);
            Console.ReadLine();
        }
        static void InsertMethod(IDbFunctions oIDb)
        {
            oIDb.Insert();
        }

    }

}

namespace Interfaces3
{
    public interface IDbFunctions
    {
        void Insert();
        void Update();
        void Delete();
    }
    public interface IFileFunctions
    {
        void Open();
        void Close();
        void Delete();

    }
    public class Class1 : IDbFunctions, IFileFunctions
    {
        void IDbFunctions.Delete()
        {
            Console.WriteLine("Class1 - IDb.Delete");
        }

        public void Display()
        {
            Console.WriteLine("Display");
        }

        public void Insert()
        {
            Console.WriteLine("Class1 - IDb.Insert");
        }

        public void Update()
        {
            Console.WriteLine("Class1 - IDb.Update");
        }

        public void Close()
        {
            Console.WriteLine("Class1 - IFile.Close");
        }

        void IFileFunctions.Delete()
        {
            Console.WriteLine("Class1 - IFile.Delete");
        }

        public void Open()
        {
            Console.WriteLine("Class1 - IFile.Open");
        }
    }
    public class MainClass
    {
        static void Main()
        {
            Class1 o = new Class1();

            o.Open();



            IFileFunctions oIFile;
            oIFile = o;
            oIFile.Delete();

            //IDbFunctions....

            Console.ReadLine();
        }
    }
}

