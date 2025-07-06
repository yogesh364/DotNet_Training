using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment7
{
    class firstAndLast
    {
        static void Main()
        {
            Console.Write("Enter the length of the array : ");
            int n = Convert.ToInt32(Console.ReadLine());

            string[] array = new string[n];

            for (int i = 0; i < n; i++)
            {
                Console.Write($"Enter the element in index {i} : ");
                array[i] = Console.ReadLine();
            }

            var getElements = from v in array
                              where v.StartsWith("a") && v.EndsWith("m")
                              select v;

            Console.WriteLine("The words that starts with 'a' and ends with 'm' are : ");

            foreach(var i in getElements)
            {
                Console.WriteLine(i);
            }

            Console.ReadLine();
        }
    }
}
