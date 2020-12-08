using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STLstackImple
{
    class Program
    {
        static void Main(string[] args)
        {
          //  Stack<int> s1 = new Stack<int>();
            Stack<string> s1 = new Stack<string>();
            s1.pop();
           /* s1.push(10);
            s1.push(20);
            s1.push(30);*/

            s1.push("10");
            s1.push("20");
            s1.push("30");

            Console.WriteLine(s1.size());
            Console.WriteLine(s1.peek());
            Console.WriteLine(s1.pop());
            Console.WriteLine(s1.pop());
            Console.WriteLine(s1.pop());
            Console.WriteLine(s1.pop());
            Console.WriteLine(s1.pop());
            Console.WriteLine(s1.size());


        }
    }

    class Node<T>
    {
        public T data { get; set; }
        public Node<T> nextNode { get; set; }

        
        public Node(T data)
        {
            this.data = data;
            this.nextNode = null;

        }
        public Node(T data,Node<T> nextNode)
        {
            this.data = data;
            this.nextNode = nextNode;
        }
        
    }
    class Stack<T>
    {
        public Node<T> head { get; set; }
        public Node<T> tail { get; set; }
        public int count { get; set; }
        public Stack()
        {
            head = tail = null;
            count = 0;
        }

        public bool isEmpty()
        {
            return head == null && tail == null ;

        }
        public bool push(T data)
        {
            Node<T> nd = new Node<T>(data);
            if(nd == null)
            {
                Console.WriteLine("Memory Full ");
                return false;
            }
            count++;
            if(head == null)
            {
                head = nd;
                tail = nd;
                return true;
            }
            else
            {
                nd.nextNode = head;
                head = nd;
                return true;
            }
        }

        public string pop()
        {
            if (isEmpty())
            {
              //  Console.WriteLine("Stack is Empty");

                return "Stack is Empty";
            }
            else
            {
                count--;
                if(tail == head)
                {
                    T data1 = head.data;
                    tail = head = null;
                    return data1.ToString();

                }
               
                T data = head.data;
                head = head.nextNode;
                return data.ToString();

            }
        }
        public string peek()
        {
            if (isEmpty())
            {
          
                    return "Stack is Empty"; 
            }
            else
            {
                return head.data.ToString();
            }

        }
        public int size()
        {
            if(head == null)
            {
                return 0;
            }
            else
            {
            
                return count;       
            }
        }

    }
}
