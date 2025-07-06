using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the length of the array : ");
            int n = Convert.ToInt32(Console.ReadLine());

            int[] array = new int[n];

            for (int i = 0; i < n; i++)
            {
                Console.Write($"Enter the element in index {i} : ");
                 array[i] = Convert.ToInt32(Console.ReadLine());
                
            }

            var squareArray = from v in array
                              where v * v >= 20
                              select v;

            Console.WriteLine("The number whose square is greater than 20 is...");
            foreach(var i in squareArray)
            {
                Console.WriteLine(" Number {0} and their square is {1}",i,i*i);
            }

            Console.Read();
        }
    }
}
