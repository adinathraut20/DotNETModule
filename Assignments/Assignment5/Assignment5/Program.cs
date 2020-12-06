/*1.Declare a dictionary based collection of Employee class objects


Accept details for Employees  in a loop. Stop accepting based on user input (yes/no)'
Display the Employee with highest Salary
Accept EmpNo to be searched. Display all details for that employee.
Display details for the Nth Employee where N is a number accepted from the user.*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    class Program
    {
        static void Main1(string[] args)
        {
                SortedList<int,Employee> d1 = new SortedList<int,Employee>();
            while (true)
            {
                Console.WriteLine("Enter y/n for enter details : ");
                string ip = Console.ReadLine();
                if (Equals("y", ip))
                {
                    Console.WriteLine("Enter Employee Name : ");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter Employee Basic : ");
                    decimal basic = Convert.ToDecimal(Console.ReadLine());
                    Console.WriteLine("Enter Employee Dept No : ");
                    short dep = (short)Convert.ToInt32(Console.ReadLine());
                    Employee e1 = new Employee(name, basic, dep);

                    d1.Add(e1.EMPNO, e1);
                }
                else if (Equals("n", ip))
                {
                    break;
                }

            }
            Console.WriteLine("Enter Emp no to search : ");
            int empNo = Convert.ToInt32(Console.ReadLine());
            if (d1.ContainsKey(empNo))
            {
                Employee e2 = d1[empNo];
                Console.WriteLine("Employee Details : \nName : {0}\nBasic : {1}\nDept NO : {2} ", e2.NAME, e2.BASIC, e2.DEPTNO);
            }
            else
            {
                Console.WriteLine("Employee NO not found!!!");
            }
            if (d1.Count > 1)
            {
                int e = Employee.EmpCount;
                Console.WriteLine("Last Employee Details : " + e);
                Employee e3 = d1[e];
                Console.WriteLine("Employee Details : \nName : {0}\nBasic : {1}\nDept NO : {2} ", e3.NAME, e3.BASIC, e3.DEPTNO);
            }
            else
            {
                Console.WriteLine("No Employee Present");
            }

        }
    }

    class Employee
    {
        private string Name;
        private int EmpNo;
        private decimal Basic;
        private short DeptNo;
        public static int EmpCount;


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
                if (!Equals(value.Trim(), ""))
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

        public short DEPTNO
        {
            set
            {
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
            return Basic - (Convert.ToDecimal(0.10) * Basic);
        }
    }
}
