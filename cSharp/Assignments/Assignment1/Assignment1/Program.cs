using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("------Checking integers are equal or not------");
            Program.equalOrNot();
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine();

            Console.WriteLine("------Checking Number is positive or not------");
            Program.posOrNeg();
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine();

            Console.WriteLine("------Opearators------");
            Program.Operation();
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine();
            
            Console.WriteLine("------Multiplication Table------");
            Program.multiTable();
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine();
            
            Console.WriteLine("------Sum of Integers------");
            Program.SumIntegers();
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine();

            Console.ReadLine();
        }

        public static void equalOrNot()
        {
            Console.Write("Enter the 1st Number : ");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the 2nd Number : ");
            int b = Convert.ToInt32(Console.ReadLine());

            //string ans = (a == b) ? "The integers are Equal" : "The integers are No Equal";
            //Console.WriteLine(ans);

            if (a == b)
                Console.WriteLine("{0} and {1} are Equal", a, b);
            else
                Console.WriteLine("{0} and {1} are Not Equal", a, b);

            /* Output:
             * Enter the 1st Number : 5
               Enter the 2nd Number : 5
               5 and 5 are Equal
             */
        }

        public static void posOrNeg()
        {
            Console.Write("Enter a Number : ");
            int a = Convert.ToInt32(Console.ReadLine());

            //String ans = (a >= 0) ? "The Number is positive" : "The Number is Negative";
            //Console.WriteLine(ans);

            if(a>=0)
                Console.WriteLine("{0} is a Positive Number",a);
            else
                Console.WriteLine("{0} is a Negative Number",a);

            /* Ouput:
             * Enter a Number : 14
               14 is a Positive Number */
        }

        public static void Operation()
        {
            Console.Write("Enter the 1st Number : ");
            double a = double.Parse(Console.ReadLine());

            Console.Write("Enter the Operator [+,-,*,/] : ");
            char c = Console.ReadLine()[0];

            Console.Write("Enter the 2nd Number : ");
            double b = double.Parse(Console.ReadLine());

            
            double ans;
            switch (c) {
                case '+':
                    ans = a + b;
                    Console.WriteLine("{0} {1} {2} is : {3}", a, c, b, ans);
                    break;
                case '-':
                    ans = a - b;
                    Console.WriteLine("{0} {1} {2} is : {3}", a, c, b, ans);
                    break;
                case '*':
                    ans = a * b;
                    Console.WriteLine("{0} {1} {2} is : {3}", a, c, b, ans);
                    break;
                case '/':
                    if (b == 0)
                    {
                        Console.WriteLine("Undefined");
                    }
                    else
                    {
                        ans = a / b;
                        Console.WriteLine("{0} {1} {2} is : {3}", a, c, b, ans);
                    }
                    break;
                default:
                    Console.WriteLine("Invalid Operation");
                    break;

                    /* Output:
                     * Enter the 1st Number : 22
                       Enter the 2nd Number : 14
                       Enter the Operator [+,-,*,/] : -
                       22 14 - is : 8 */

            }

        }

        public static void multiTable()
        {
            Console.Write("Enter the 1st Number : ");
            int a = Convert.ToInt32(Console.ReadLine());

            for(int i = 1; i <= 10; i++)
            {
                Console.Write("{0} * {1} = {2}",a,i,a*i);
                Console.WriteLine();
            }

            /* Output
             * Enter the 1st Number : 5
                5 * 1 = 5
                5 * 2 = 10
                5 * 3 = 15
                5 * 4 = 20
                5 * 5 = 25
                5 * 6 = 30
                5 * 7 = 35
                5 * 8 = 40
                5 * 9 = 45
                5 * 10 = 50 */
        }

        public static void SumIntegers()
        {
            Console.Write("Enter the 1st Number : ");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the 2nd Number : ");
            int b = Convert.ToInt32(Console.ReadLine());


            if (a == b)
            {
                Console.WriteLine("The sum is Equal");
                Console.WriteLine("Triple the sum is " + (3 * (a + b)));
            }
            else
            {
                Console.WriteLine("The sum is Not Equal");
                Console.WriteLine("The sum is : " + (a + b));
            }


            /* Output:
             *  Enter the 1st Number : 5
                Enter the 2nd Number : 5
                The sum is Equal
                Triple the sum is 30  */
        }
    }
}
