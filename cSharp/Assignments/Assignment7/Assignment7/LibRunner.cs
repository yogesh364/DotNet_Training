extern alias l1;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment7
{
    class LibRunner
    {
        static void Main()
        {
            l1.Lib1.Class1 obj = new l1.Lib1.Class1();

            Console.Write("Enter the Name : ");
            String name = Console.ReadLine();
            Console.Write("Enter Your Age : ");
            int age = Convert.ToInt32(Console.ReadLine());


            obj.calculateConcession(age);

            Console.Read();
        }
    }
}
