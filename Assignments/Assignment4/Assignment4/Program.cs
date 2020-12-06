/*1.Create an array of Employee class objects
        Accept details for all Employees
        Display the Employee with highest Salary
        Accept EmpNo to be searched. Display all details for that employee.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    class Program
    {
        static void Main1(string[] args)
        {
            int n = 3;

            Employee []arr1 = new Employee[3];
            for(int i = 0; i < n; i++)
            {
                Console.WriteLine("Enter Name : ");
                string Name = Console.ReadLine();
                Console.WriteLine("Enter Basic : ");
                decimal Basic = Convert.ToDecimal(Console.ReadLine());
                Console.WriteLine("Enter DeptNo : ");
                short DeptNo =(short) Convert.ToInt32(Console.ReadLine());
                arr1[i] = new Employee(Name,Basic,DeptNo);
            }
            Decimal maxSal = arr1[0].GetNetSalary();
            Employee e1 = null;
            for(int i = 1; i < n; i++)
            {
                if (maxSal < arr1[i].GetNetSalary()){
                    e1 = arr1[i];
                }
            }
            Console.WriteLine("Employee Name with Highest Salary : "+e1.NAME);
            Console.WriteLine("Enter Employee no to search : ");
            int EmpnoS = Convert.ToInt32(Console.ReadLine());
            bool flag = true;
            foreach(Employee i in arr1)
            {
                if(EmpnoS == i.EMPNO)
                {
                    flag = false;
                    Console.WriteLine("\nEmployee Name : "+ i.NAME);
                }
            }
            if (flag)
            {
                Console.WriteLine("Employee No not found!!!");
            }

        }
    }


    class Employee
    {
        private string Name;
        private int EmpNo;
        private decimal Basic;
        private short DeptNo;
        private static int EmpCount;

        public Employee()
        {

        }
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
                if (!Equals(value.Trim(),""))
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
