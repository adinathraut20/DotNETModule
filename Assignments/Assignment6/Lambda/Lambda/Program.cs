/* 1. decimal SimpleInterest(decimal P, decimal N, decimal R) -> returns calculated SimpleInterest */
/* 2. bool IsGreater(int a, int b) -> returns true if a is > b*/
/* 3. decimal GetBasic(Employee e) -> returns the Basic salary of the employee */
/* 4. bool IsEven(int num) -> returns true if the number is an even number */
/*5. bool IsGreaterThan10000(Employee e) -> returns true if the Basic Salary is > 10000 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lambda
{
    
    class Program
    {
        static void Main(string[] args)
        {
            Func<decimal,decimal,decimal,decimal> f1 = (P, N, R) => (P * N * R) / 100;
            Console.WriteLine("S.I : "+f1(2000,4,5));
            
            Func<int, int, bool> p1 = (a,b) => a > b;
            Console.WriteLine(p1(20, 30));


            Func<Employee, double> f2 = (e1) => e1.getSal();
            Employee e2 = new Employee("Adin", 3, 30000);
            Console.WriteLine(f2(e2));

            Predicate<int> p2 = (c) => c % 2 == 0;
            Console.WriteLine("Even : "+ p2(33));

            Predicate<Employee> p3 = (c) => c.getSal() > 1000;
            Console.WriteLine("Salary Greater than 1000 : " + p3(e2));

        }
    }
    class Employee
    {
        public string name { get; set; }
        public int empid { get; set; }
        public decimal basic { get; set; }

        public Employee(string name,int empid,decimal basic)
        {
            this.name = name;
            this.empid = empid;
            this.basic = basic;
        }
        public double getSal()
        {
            return (double)basic * 0.9;
        }
    }
}
