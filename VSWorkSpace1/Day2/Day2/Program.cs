using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    class Program
    {
        static void Main1(string[] args)
        {
            Stud s1 = new Stud(1);
            Console.WriteLine(s1.ID1);
            s1.setId(5);
            Console.WriteLine(s1.getId());
            s1.ID1 = 1;
            Console.WriteLine(s1.ID1);
            s1.P1 = 3;
            Console.WriteLine(s1.P1);
            GC.Collect();
            Console.ReadLine();
            Console.WriteLine("End of Program");
            Console.WriteLine(Math.Round(11.500));
        }
    }

    class Stud
    {
        private int id;

        public Stud(int id)
        {
            Console.WriteLine("Constructor called");
           // this.id = id;
            ID1 = id;
        }

        public int getId()
        {
            return id;
        }
        public void setId(int id)
        {
            this.id = id;
        }

        public int ID1
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        public int P1 { get; set; }  //auto properties

        ~Stud()
        {
            Console.WriteLine("Destructor called");
        }

    }
}
