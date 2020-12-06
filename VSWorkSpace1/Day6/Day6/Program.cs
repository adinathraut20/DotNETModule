using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day6
{
    class Program
    {
        static void Main1(string[] args)
        {
            ArrayList ar1 = new ArrayList();
            ar1.Add(10);
            ar1.Add("string");
            ar1.Add(1.2);

            foreach(object ob in ar1){
                Console.WriteLine(ob);
            }

            Hashtable dict = new Hashtable();
            dict.Add(1, "abc");
            dict.Add(2, "pqr");
            dict.Add(3, "xyz");

            dict[3] = "value changed";
            dict[4] = "4th value";
            
            dict.Remove(2);
            Console.WriteLine(dict.ContainsKey(5));

            foreach(DictionaryEntry de in dict)
            {
                Console.WriteLine(de.Key+" "+de.Value);
            }

            SortedList Sdict = new SortedList();
            Sdict.Add(1, "abc");
            Sdict.Add(2, "pqr");
            Sdict.Add(3, "xyz");

            Stack st = new Stack();
            st.Push(10);
            st.Push(20);
            Console.WriteLine(st.Pop());
            Console.WriteLine(st.Peek());

            Queue q = new Queue();
            q.Enqueue(50);
            q.Enqueue(60);
            q.Enqueue(70);
            Console.WriteLine(q.Dequeue());
            Console.WriteLine(q.Peek());
        }
        static void Main2()
        {
            List<int> li = new List<int>();
            li.Add(3);
            li.Add(4);
            li.Add(5);
            foreach(int i in li)
            {
                Console.WriteLine(i);
            }

            SortedList<int, string> sl = new SortedList<int, string>();
            sl.Add(3, "abc");
            sl.Add(4, "qwe");
            sl[5] = "hiii";

            foreach(KeyValuePair<int,string> i in sl)
            {
                Console.WriteLine(i.Key+" "+ i.Value);
            }

            Stack<int> s1 = new Stack<int>();
            s1.Push(10);
            s1.Push(20);
            s1.Push(30);
            Console.WriteLine(s1.Pop());
            Console.WriteLine(s1.Peek());

            Queue<int> q1 = new Queue<int>();
            q1.Enqueue(50);
            q1.Enqueue(60);
            q1.Enqueue(70);
            Console.WriteLine(q1.Dequeue());
            Console.WriteLine(q1.Peek());
        }

        static void Main3()
        {
            //object initalizer
            Employee e1 = (new Employee { EmpNo = 1, Name = "Adi", Basic = 1200 });
            Employee e2 = new Employee(2,"adiii",3000);

        }
    }

    public class Employee
    {
        public int EmpNo { get; set; }
        public string Name { get; set; }
        public decimal Basic { get; set; }

        public Employee() { }
        public Employee(int empNo,string name,decimal basic)
        {
            EmpNo = empNo;
            Name = name;
            Basic = basic;
        }
    }
        
}
