using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    class Program
    {
        static void Main(string[] args)
        {
            Manager m1 = new Manager();
            Console.WriteLine(m1.EMPNO);

            GeneralManager gm1 = new GeneralManager();
            Console.WriteLine(gm1.EMPNO);

            Employee e1 = new Manager();
            Console.WriteLine(e1.EMPNO);

            Employee e2 = new GeneralManager();
            Console.WriteLine(e2.EMPNO);
            e2.insert();
            e2.Display();

            Manager m2 = new GeneralManager();
            m2.insert();
            m2.Display();
            

        }
    }
    public interface IDB
    {
        void insert();
        void Display();
    }
    public abstract class Employee : IDB
    {
        private string Name;
        private int EmpNo;
        private short DeptNo;
        private static int EmpCount = 0;
        protected decimal basic;

        public int EMPNO
        {
            get
            {
                return this.EmpNo;
            }
        }
        public abstract decimal Basic
        {
            get;
            set;
        }
        public Employee(string Name = "noname", short DeptNo = 10, decimal Basic = 3000)
        {
            EmpNo = ++EmpCount;
            this.Name = Name;
            this.DeptNo = DeptNo;
            this.Basic = Basic;
        }
        public string NAME
        {
            set
            {
                if(Equals("",value))
                {
                    Console.WriteLine("Null String");
                }
                else
                {
                    this.Name = value;
                }
            }
            get
            {
                return Name;
            }
        }
        public short DEPTNO
        {
            get
            {
                return DeptNo;
            }
            set
            {
                if (value > 0)
                {
                    DeptNo = value;
                }
                else
                {
                    Console.WriteLine("Invalid DeptNo");
                }
            }
        }
        public abstract decimal CalcNetSalary();

        public void insert()
        {
            Console.WriteLine("Insert Employee Implemented");
        }
        public void Display()
        {
            Console.WriteLine("Display in Employee fuction");
        }

    }

    public class Manager : Employee, IDB
    {
        public string Designation { get; set; }
        public override decimal Basic
        {
            get
            {
                return this.basic;
            }
            set
            {
                if (value > 1000 && value < 10000)
                {
                    this.basic = value;
                }
                else
                {
                    Console.WriteLine("Invalid Basic Value");
                }
            }
        }
        public Manager(string Name = "noname", short DeptNo = 10, decimal Basic = 8000, string Designation = "GM") : base(Name, DeptNo, Basic)
        {
            this.Designation = Designation;

        }

        public override decimal CalcNetSalary()
        {
            return basic + (basic * Convert.ToDecimal(0.1));
        }

        public new virtual void insert()
        {
            Console.WriteLine("Insert Manager Function Implemented");
        }
        public new virtual void Display()
        {
            Console.WriteLine("Display Manager Function in fuction");
        }
    }

    public class GeneralManager : Manager, IDB
    {
        public string Perks { get; set; }
        public override decimal Basic
        {
            get
            {
                return this.basic;
            }
            set
            {
                if (value > 1000 && value < 10001)
                {
                    this.basic = value;
                }
                else
                {
                    Console.WriteLine("Invalid Basic Value");
                }
            }
        }
        public GeneralManager(string Name = "noname", short DeptNo = 10, decimal Basic = 5000, string Designation = "GM", string Perks = "none")
    : base(Name, DeptNo, Basic, Designation)
        {
            this.Perks = Perks;

        }

        public override decimal CalcNetSalary()
        {
            return Basic + (Basic * Convert.ToDecimal(0.5));
        }

    
    }
}
