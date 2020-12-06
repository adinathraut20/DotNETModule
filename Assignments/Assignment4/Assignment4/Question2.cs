/*2.CDAC has certain number of batches. each batch has certain number of students
         accept number of batches from the user. for each batch accept number of students.
         create an array to store mark for each student. 
         accept the marks.
         display the marks.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    class Question2
    {
        static void Main2(string[] args)
        {
            Console.WriteLine("Enter no. of Batches :");
            int batchNo = Convert.ToInt32(Console.ReadLine());
            int[][][] arr2 = new int[batchNo][][];
            
            for (int i = 0; i < batchNo; i++)
            {
                Console.WriteLine("Enter no. of Student in batch :" + (i + 1));
                int stuNo = Convert.ToInt32(Console.ReadLine());
                arr2[i] = new int[stuNo][];
                for(int j = 0; j < stuNo; j++)
                {
                    Console.WriteLine("Enter no. Marks for Student :" + (j + 1));
                    arr2[i][j] = new int[3];
                    for(int k = 0; k < 3; k++)
                    {
                        Console.WriteLine("Enter Mark for Subject :"+(k+1));
                        arr2[i][j][k] = Convert.ToInt32(Console.ReadLine());
                    }
                }
            }

            for (int i = 0; i < batchNo; i++)
            {
                Console.WriteLine("Student in batch :" + (i + 1));
   
            
                for (int j = 0; j < arr2[i].Length; j++)
                {
                    Console.WriteLine($"Student No. {(j+1)} Marks : ");
                    for (int k = 0; k < 3; k++)
                    {

                        Console.Write(arr2[i][j][k]+" ");
                    }
                    Console.WriteLine("");
                }
            }

        }
    }
}
