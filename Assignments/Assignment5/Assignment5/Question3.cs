/*3. Create a List<Employee>. Convert it to an array. Display all the array elements.*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    class Question3
    {
        static void Main(string[] args)
        {
            int n = 3;
            
            List<Employee> li1 = new List<Employee>();
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Enter Name : ");
                string Name = Console.ReadLine();
                Console.WriteLine("Enter Basic : ");
                decimal Basic = Convert.ToDecimal(Console.ReadLine());
                Console.WriteLine("Enter DeptNo : ");
                short DeptNo = (short)Convert.ToInt32(Console.ReadLine());
                li1.Add(new Employee(Name, Basic, DeptNo));
            }
            Employee[] arr1 = li1.ToArray();

            foreach(Employee i in arr1)
            {
                Console.WriteLine("Employee Details : \nName : {0}\nBasic : {1}\nDept NO : {2} ", i.NAME, i.BASIC, i.DEPTNO);
            }
            
        }
    }
}
