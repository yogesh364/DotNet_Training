using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("-------------Swap Two Numbers-----------------");
            swap();
            Console.WriteLine("------------------------------");
            Console.WriteLine("-------------Display Rows-----------------");
            Seperate();
            Console.WriteLine("------------------------------");
            Console.WriteLine("-------------Display day-----------------");
            days();
            Console.WriteLine("------------------------------");
            
            Console.Read();
        }

        //Write a C# Sharp program to swap two numbers.
        public static void swap()
        {
            Console.Write("Enter the first Number : ");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the second Number : ");
            int b = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Values before swapping: a = {a} , b = {b}");
            a = a + b;
            b = a - b;
            a = a - b;
            Console.WriteLine($"Values after swapping: a = {a} , b = {b}");

            /* Output :
             *  Enter the first Number : 10
                Enter the second Number : 20
                Values before swapping: a = 10 , b = 20
                Values after swapping: a = 20 , b = 10
             */
        }
        //Write a C# program that takes a number as input and displays it four times in a row (separated by blank spaces), and then four times in the next row, with no separation. 
        
        public static void Seperate()
        {
            Console.Write("Enter a Number : ");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the repetition Count :");
            int n = Convert.ToInt32(Console.ReadLine());
            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    if (i % 2 == 0)
                    {
                        Console.Write("{0} ", a);
                    }
                    else
                    {
                        Console.Write("{0}", a);
                    }
                }
                Console.WriteLine();
            }

            /* Output:
             *  Enter a Number : 25
                Enter the repetition Count :4
                25 25 25 25
                25252525
                25 25 25 25
                25252525  */
        }

        //Write a C# Sharp program to read any day number as an integer and display the name of the day as a word.

        public static void days()
        {
            Console.Write("Enter a Number : ");
            int a = Convert.ToInt32(Console.ReadLine());

            String res = (a == 1) ? "Monday" :
                (a == 2) ? "Tuesday" :
                (a == 3) ? "Wednesday" :
                (a == 4) ? "Thursday" :
                (a == 5) ? "Friday" :
                (a == 6) ? "Saturday" :
                (a == 7) ? "Sunday" : "Invalid Input";
            Console.WriteLine(res);

            /* Output :
             *  Enter a Number : 2
                Tuesday */
        }
    }
}
