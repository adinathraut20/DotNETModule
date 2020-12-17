using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqExample
{


    class Class1
    {
        static List<Employee> lstEmp = new List<Employee>();
        static List<Department> lstDept = new List<Department>();
        static void Main1()
        {
            AddRecs();
            //from SINGLE_OBJECT in COLLECTION select SOMETHING
            //var emps = from emp in lstEmp select emp;
            //  IEnumerable<Employee> emps = from emp in lstEmp select emp;
            List<Employee> emps = (List<Employee>)from emp in lstEmp select emp;

            foreach (Employee emp in emps)
            {
                Console.WriteLine(emp.Name);
            }

            // Console.ReadLine();

        }
        static void Main2()
        {
            AddRecs();
            //from SINGLE_OBJECT in COLLECTION select SOMETHING
            //var emps = from emp in lstEmp select emp.Name;
            var emps = from emp in lstEmp select emp.Basic;
            // IEnumerable<Employee> emps = from emp in lstEmp select emp;
            // List<Employee> emps =(List<Employee>) from emp in lstEmp select emp;

            foreach (var emp in emps)
            {
                Console.WriteLine(emp);
            }

            // Console.ReadLine();

        }
        static void Main3()
        {
            AddRecs();
            //from SINGLE_OBJECT in COLLECTION select SOMETHING

            //var emps = from emp in lstEmp select new { emp.Name, emp.Basic };

            //var emps = from emp in lstEmp select emp.Basic;
            // IEnumerable<Employee> emps = from emp in lstEmp select emp;
            List<Employee> emps = (List<Employee>)from emp in lstEmp select emp;

            foreach (var emp in emps)
            {
                Console.WriteLine(emp);
            }

            // Console.ReadLine();

        }

        static void Main4()
        {
            AddRecs();


            // var emps = from emp in lstEmp
            //           where emp.Basic > 10000
            //         select emp;
            //var emps = from emp in lstEmp
            //           where emp.Basic > 10000 && emp.Basic < 12000
            //           select emp;
            var emps = from emp in lstEmp
                       where emp.Name.StartsWith("V")
                       select emp;

            foreach (var emp in emps)
            {
                Console.WriteLine(emp.Name);
            }

            //  Console.ReadLine();

        }
        static void Main5()
        {
            AddRecs();


            //var emps = from emp in lstEmp
            //           orderby emp.Name ascending
            //           select emp;

            var emps = from emp in lstEmp
                       orderby emp.DeptNo, emp.Name descending
                       select emp;


            foreach (var emp in emps)
            {
                Console.WriteLine(emp.DeptNo + " " + emp.Name + " " + emp);
            }

            //Console.ReadLine();

        }

        static void Main6()
        {
            AddRecs();

            var emps = from emp in lstEmp
                       join dept in lstDept
                             on emp.DeptNo equals dept.DeptNo
                       orderby emp.Name descending
                       select new { dept.DeptName, emp.Name };

            foreach (var emp in emps)
            {
                Console.WriteLine(emp.Name + " " + emp.DeptName);
            }

            // Console.ReadLine();

        }

        static Employee GetEmployees(Employee obj)
        {
            return obj;
        }

        static void Main7()
        {
            AddRecs();

            // var emps = from emp in lstEmp select emp;

            //passing function as a parameter to Select
            // var emps = lstEmp.Select(GetEmployees);

            //passing anon method as a parameter to Select
            //var emps = lstEmp.Select(delegate(Employee obj)
            //{
            //    return obj;
            //});

            //using a lambda instead of anon method
            // var emps = lstEmp.Select(emp => emp);

            //longer way
            Func<Employee, Employee> o = e => e;
            var emps = lstEmp.Select(o);

            foreach (var emp in emps)
            {
                Console.WriteLine(emp.Name);
            }

            // Console.ReadLine();
        }
        static void Mai8n()
        {
            AddRecs();


            //using a lambda instead of anon method
            //  var emps = lstEmp.Select(emp => emp);
            var emps1 = lstEmp.Where(emp => emp.Basic > 11000);
            var emps2 = lstEmp.Where(emp => emp.Basic > 11000 && emp.Name == "Abhijit").Select(emp => emp);
            var emps3 = lstEmp.Where(emp => emp.Basic > 11000).Select(emp => emp.Name);
            var emps = lstEmp.Where(emp => emp.Basic > 11000).Select(emp => new { emp.Name, emp.Basic });


            var emps4a = lstEmp.Select(emp => new { emp.Name, emp.Basic }).Where(emp => emp.Basic > 11000);
            var emps4b = lstEmp.Where(emp => emp.Basic > 11000).Select(emp => emp);

            var emps5a = lstEmp.Where(emp => emp.Basic > 11000).Select(emp => emp.Name);
            //var emps5b = lstEmp.Select(emp => emp.Name).Where(emp => emp.Basic > 11000);

            foreach (var emp in emps)
            {
                Console.WriteLine(emp.Name + "," + emp.Basic);
            }

            //Console.ReadLine();
        }

        static void Main9()
        {
            AddRecs();


            //using a lambda instead of anon method
            var emps = lstEmp.OrderBy(emp => emp.Name);
            var emps2 = lstEmp.OrderByDescending(emp => emp.Name);


            foreach (var emp in emps)
            {
                Console.WriteLine(emp.Name + "," + emp.Basic);
            }

            Console.ReadLine();
        }
        static void Main10()
        {
            AddRecs();

            //var emps = from emp in lstEmp
            //           join dept in lstDept
            //                 on emp.DeptNo equals dept.DeptNo
            //           select new { dept.DeptName, emp.Name };    

            var emps2a = lstEmp.Join(lstDept, emp => emp.DeptNo, dept => dept.DeptNo, (emp, dept) => emp);
            var emps2b = lstEmp.Join(lstDept, emp => emp.DeptNo, dept => dept.DeptNo, (emp, dept) => dept);
            var emps2c = lstEmp.Join(lstDept, emp => emp.DeptNo, dept => dept.DeptNo, (emp, dept) => emp.Basic);
            var emps2d = lstEmp.Join(lstDept, emp => emp.DeptNo, dept => dept.DeptNo, (emp, dept) => dept.DeptName);
            var emps = lstEmp.Join(lstDept, emp => emp.DeptNo, dept => dept.DeptNo, (emp, dept) => new { dept.DeptName, emp.Name });


            foreach (var emp in emps)
            {
                Console.WriteLine(emp.Name + "," + emp.DeptName);
            }

            Console.ReadLine();
        }
        static void Main11()
        {
            AddRecs();
            //deferred execution
            var emps = from emp in lstEmp select emp;
            Console.WriteLine();
            lstEmp.RemoveAt(0);
            foreach (var emp in emps)
            {
                Console.WriteLine(emp.Name + "," + emp.EmpNo);
            }
            Console.WriteLine();
            lstEmp.RemoveAt(0);

            lstEmp.Add(new Employee { EmpNo = 9, Name = "New", Basic = 11000, DeptNo = 40, Gender = "F" });
            foreach (var emp in emps)
            {
                Console.WriteLine(emp.Name + "," + emp.EmpNo);
            }
            //Console.ReadLine();
        }
        static void Main17()
        {
            AddRecs();
            var emps = from emp in lstEmp select emp;
            //immediate execution
            emps = emps.ToList();
            List<Employee> emps1 = (List<Employee>)emps;


            Console.WriteLine();
            lstEmp.RemoveAt(0);
            // emps1.RemoveAt(0);
            foreach (var emp in emps1)
            {
                Console.WriteLine(emp.Name + "," + emp.EmpNo);
            }
            Console.WriteLine();
            lstEmp.Add(new Employee { EmpNo = 9, Name = "New", Basic = 11000, DeptNo = 40, Gender = "F" });
            foreach (var emp in emps)
            {
                Console.WriteLine(emp.Name + "," + emp.EmpNo);
            }
            //Console.ReadLine();
        }
        public static void AddRecs()
        {
            lstDept.Add(new Department { DeptNo = 10, DeptName = "SALES" });
            lstDept.Add(new Department { DeptNo = 20, DeptName = "MKTG" });
            lstDept.Add(new Department { DeptNo = 30, DeptName = "IT" });
            lstDept.Add(new Department { DeptNo = 40, DeptName = "HR" });

            lstEmp.Add(new Employee { EmpNo = 1, Name = "Vikram", Basic = 10000, DeptNo = 10, Gender = "M" });
            lstEmp.Add(new Employee { EmpNo = 2, Name = "Vikas", Basic = 11000, DeptNo = 10, Gender = "M" });
            lstEmp.Add(new Employee { EmpNo = 3, Name = "Abhijit", Basic = 12000, DeptNo = 20, Gender = "M" });
            lstEmp.Add(new Employee { EmpNo = 4, Name = "Mona", Basic = 11000, DeptNo = 20, Gender = "F" });
            lstEmp.Add(new Employee { EmpNo = 5, Name = "Shweta", Basic = 12000, DeptNo = 20, Gender = "F" });
            lstEmp.Add(new Employee { EmpNo = 6, Name = "Sanjay", Basic = 11000, DeptNo = 30, Gender = "M" });
            lstEmp.Add(new Employee { EmpNo = 7, Name = "Arpan", Basic = 10000, DeptNo = 30, Gender = "M" });
            lstEmp.Add(new Employee { EmpNo = 8, Name = "Shraddha", Basic = 11000, DeptNo = 40, Gender = "F" });
        }
    }

    public class Department
    {
        public int DeptNo { get; set; }
        public string DeptName { get; set; }
    }
    public class Employee
    {
        public int EmpNo { get; set; }
        public string Name { get; set; }
        public decimal Basic { get; set; }
        public int DeptNo { get; set; }
        public string Gender { get; set; }
        //public override string ToString()
        //{
        //    string s = Name + "," + EmpNo.ToString() + "," + Basic.ToString() + "," + DeptNo.ToString();
        //    return s;
        //}
    }
}
