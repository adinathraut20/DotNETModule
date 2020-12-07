/*2.Create an array of Employee objects. Convert it to a List<Employee>.  Display all the Employees in the list.*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Assignment5
{
    class Question2
    {

        static void Main3(string[] args)
        {
            int n = 3;
            Employee[] arr4 = new Employee[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Enter Name : ");
                string Name = Console.ReadLine();
                Console.WriteLine("Enter Basic : ");
                decimal Basic = Convert.ToDecimal(Console.ReadLine());
                Console.WriteLine("Enter DeptNo : ");
                short DeptNo = (short)Convert.ToInt32(Console.ReadLine());
                arr4[i] = new Employee(Name, Basic, DeptNo);
            }
            List<Employee> li1 = new List<Employee>();
            li1.AddRange(arr4);
			//li.ToList(arr4);
            foreach(Employee i in li1)
            {
                Console.WriteLine("Employee Details : \nName : {0}\nBasic : {1}\nDept NO : {2} ", i.NAME, i.BASIC, i.DEPTNO);
            }


        }
    }


}
