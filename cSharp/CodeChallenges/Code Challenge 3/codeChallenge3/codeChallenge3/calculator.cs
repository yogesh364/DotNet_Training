using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace codeChallenge3
{
    delegate int CalculatorDelegate(int a, int b);
    class Calculator
    {
        public static int Add(int x, int y)
        {
            return x + y;
        }
        public static int Sub(int x, int y)
        {
            return x - y;
        }
        public static int Mul(int x, int y)
        {
            return x * y;
        }
        static void Main()
        {
            Console.WriteLine("Enter the Number 1:");
            int n1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Number 2:");
            int n2 = Convert.ToInt32(Console.ReadLine());

            CalculatorDelegate cd = new CalculatorDelegate(Calculator.Add);
            Console.WriteLine("The sum of the Numbers is : " + cd(n1, n2));

            cd += new CalculatorDelegate(Calculator.Sub);
            Console.WriteLine("The Subtraction of the Numbers is : " + cd(n1, n2));

            cd += new CalculatorDelegate(Calculator.Mul);
            Console.WriteLine("The Multiplication of the Numbers is : " + cd(n1, n2));
            Console.Read();

        }
    }    
}
