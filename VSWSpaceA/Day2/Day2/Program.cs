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
            Student s1 = new Student();

            string str = Console.ReadLine();
            int a = Convert.ToInt32(str);
            s1.setNo(a);

           // s1.setNo(Convert.ToInt32(Console.ReadLine()));

            Console.WriteLine(s1.getNo());

            s1.NO = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(s1.NO);

            s1.ID1 = 100;

            s1.NO = s1.NO++ + s1.NO--;

            Console.WriteLine(s1.NO);

            Console.WriteLine(s1.ID);

            s1.ROLLNO = 50;
            Console.WriteLine(s1.ROLLNO);

        }
    }

    class Student
    {
        private int no ;
        private int id = 1;

        public int getNo()
        {
            return no;
        }
        public void setNo(int no)
        {
            if (no < 100)
            {
                this.no = no;
            }
            else
            {
                Console.WriteLine("Invalid no");
            }
        }

        public int NO
        {
            set
            {
                if (value < 100)
                {
                    this.no = value;
                }
                else
                {
                    Console.WriteLine("Invalid no");
                }
            }
            get
            {
                return no;
            }

        }

        //read only propperty
        public int ID
        {
            get
            {
                return id;
            }
        }

        //write only property
        public int ID1
        {
            set
            {
                id = value;
            }
        }

        //read and write
        public int ID3
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

        public int ROLLNO { get; set; }  //auto property

    }
}
