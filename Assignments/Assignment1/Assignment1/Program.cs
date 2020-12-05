using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee o1 = new Employee("Amol", 123465, 10);
            Employee o2 = new Employee("Amol", 123465);
            Employee o3 = new Employee("Amol");
            Employee o4 = new Employee();

            Console.WriteLine(o1.EMPNO);
            Console.WriteLine(o2.EMPNO);
            Console.WriteLine(o3.EMPNO);

            Console.WriteLine(o3.EMPNO);
            Console.WriteLine(o2.EMPNO);
            Console.WriteLine(o1.EMPNO);
        }
    }

    class Employee
    {
        private string Name;
        private int EmpNo;
        private decimal Basic;
        private short DeptNo;
        private static int EmpCount;

        
        public Employee(string Name = "noname", decimal Basic = 10000, short DeptNo = 10)
        {
            EmpNo = ++EmpCount;
            NAME = Name;
            BASIC = Basic;
            DEPTNO = DeptNo;
        }
       
        public string NAME
        {
            set
            {
                if (value != "")
                {
                    Name = value;
                }
                else
                {
                    Console.WriteLine("Invalid Name");
                }
            }
            get
            {
                return Name;
            }
        }

        public int EMPNO
        {
            get
            {
                return EmpNo;
            }
        }

        public decimal BASIC
        {
            set
            {
                if (value < 1500000 && value > 1000)
                {
                    Basic = value;
                }
                else
                {
                    Console.WriteLine("Salary should be in range of 1000 - 1500000");
                }
            }
            get
            {
                return Basic;
            }
        }

        public short DEPTNO{
            set{
                if (value > 0)
                {
                    DeptNo = value;
                }
                else
                {
                    Console.WriteLine("Dept no must be greater than 0");
                }
            }
            get
            {
                return DeptNo;
            }
        }
        public decimal GetNetSalary()
        {
            return Basic - (Convert.ToDecimal(0.10)*Basic);
        }
    }
}
