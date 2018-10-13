using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace javacode2
{
    /** Singly linked node class. */
    public class Node<T>
    {
        public T data;
        public Node<T> next;

        public Node(T data, Node<T> next)
        {
            this.data = data;
            this.next = next;
        }
    }


    /**
 * A FIFO queue interface.  This ADT is suitable for a singly
 * linked queue.
 */
    public interface IQueueInterface<T>
    {/**
     * Add an element to the rear of the queue
     * 
     * @return the element that was enqueued
     */
        T Push(T element);

        /**
    * Remove and return the front element.
    * 
    * @throws Thrown if the queue is empty
    */
        T Pop();
        
    /**
     * Test if the queue is empty
     * 
     * @return true if the queue is empty; otherwise false
     */
      Boolean IsEmpty();
    }


  /**
 * A custom unchecked exception to represent situations where 
 * an illegal operation was performed on an empty queue.
 */
    public class QueueUnderflowException : SystemException
    {
        public QueueUnderflowException() : base()
        {
          

        }

        public QueueUnderflowException(string message) : base(message)
        {
            
        }
    }



    /**
 * A Singly Linked FIFO Queue.  
 * From Dale, Joyce and Weems "Object-Oriented Data Structures Using Java"
 * Modified for CS 460 HW3
 * 
 * See QueueInterface.java for documentation
 */
    public class LinkedQueue<T> : IQueueInterface<T>
    {
        private Node<T> front;
        private Node<T> rear;


        public T Push(T element)
        {
            if(element == null)
            {
                throw new NullReferenceException();
            }

            if(IsEmpty())
            {
                Node<T> temp = new Node<T>(element, null);
                rear = front = temp;
            }
            else
            {
                //general case
                Node<T> tmp = new Node<T>(element, null);
                rear.next = tmp;
                rear = tmp;
            }
            return element;
        }

        public T Pop()
        {
            T tmp = default(T);
            if( IsEmpty() )
            {
                throw new QueueUnderflowException("The queue was empty when pop was invoked.");
            }

            else if(front == rear )
            {
                //one item in queue
                tmp = front.data;
                front = null;
                rear = null;
            }
            else
            {
                //general case
                tmp = front.data;
                front = front.next;
            }
            return tmp;
        }

        public Boolean IsEmpty()
        {
            if(front == null  && rear == null )
            {
                return true;
            }
            else
            {
                return false;
            }
        }



    }

    /**
 * Original by Sumit Ghosh "An Interesting Method to Generate Binary Numbers from 1 to n"
 * at https://www.geeksforgeeks.org/interesting-method-generate-binary-numbers-1-n/
 * 
 * Adapted for CS 460 HW3.  This simple example demonstrates the rather powerful
 * application of Breadth-First Search to enumeration of states problems.
 * 
 * There are easier ways to generate a list of binary values, but this technique
 * is very general and a good one to remember for other uses.
 */
    class Main1  {
        /**
       * Print the binary representation of all numbers from 1 up to n.
       * This is accomplished by using a FIFO queue to perform a level 
       * order (i.e. BFS) traversal of a virtual binary tree that 
       * looks like this:
       *                 1
       *             /       \
       *            10       11
       *           /  \     /  \
       *         100  101  110  111
       *          etc.
       * and then storing each "value" in a list as it is "visited".
       */

        static LinkedList<string> GenerateBinaryRepersentaionList(int n)
        {
            // Create an empty queue of strings with which to perform the traversal
            LinkedQueue<StringBuilder> q = new LinkedQueue<StringBuilder>();

            // A list for returning the binary values
            LinkedList<string> output = new LinkedList<string>();

            if (n < 1)
            {
                // binary representation of negative values is not supported
                // return an empty list
                return output;
            }
            // Enqueue the first binary number.  Use a dynamic string to avoid string concat
            q.Push(new StringBuilder("1"));

            //BFS
            while (n-- > 0)
            {
                //print the front of the queue
                StringBuilder sb = q.Pop();
                output.AddFirst(sb.ToString());

                //make a copy
                StringBuilder sbc = new StringBuilder(sb.ToString());

                //Left Child
                sb.Append('0');
                q.Push(sb);
                //Right Child
                sbc.Append('1');
                q.Push(sbc);
            }
            return output;


        }


        static void Main(string[] args)
        {
            int n = 10;
            if (args.Length < 1)
            {
                Console.WriteLine("Please invoke with the max value to print binary up to, like this:");
                Console.WriteLine("\tjava main 12");
            }
            try
            {
                n = int.Parse(args[0]);
            }
            catch (FormatException)
            {
                Console.WriteLine("I'm sorry, I can't understand the number", args[0]);
                return;
            }
            LinkedList<String> output = GenerateBinaryRepersentaionList(n);
            // Print it right justified.  Longest string is the last one.
            // Print enough spaces to move it over the correct distance
            int maxLength = output.Count();
            foreach (String s in output)
            {
                for (int i = 0; i < maxLength - s.Length; ++i)
                {
                    Console.Write(" ");
                }
                Console.WriteLine(s);
            }
        }
    }
}