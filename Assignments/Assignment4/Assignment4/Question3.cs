/*3.Create a struct Student with the following properties. Put in appropriate validations.
string Name
int RollNo
decimal Marks

Create a parameterized constructor.

Create an array to accept details for 5 students
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    class Question3
    {
        static void Main(string[] args)
        {
            Student []arr = new Student[5];
            for(int i = 0; i < 5; i++)
            {
                Console.WriteLine("Enter Student Name :");
                string Name1 = Console.ReadLine();
                Console.WriteLine("Enter Student Roll No :");
                int rno = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Mark for Subject :");
                Decimal mark = Convert.ToDecimal(Console.ReadLine());
                
                arr[i].Name = Name1;
                arr[i].RollNo = rno;
                arr[i].Marks = mark;
            
            }

        }
    }

     struct Student
    {

       public string Name;
       public int RollNo;
       public decimal Marks;

        Student(string name, int Rno, decimal mark)
        {

            this.RollNo = 0;
            this.Name = "aa";
            this.Marks = 0;
        }

    }

}
