using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace codeChallenge3
{
    class Box
    {
        public double length;
        public double breadth;

        public static Box operator +(Box b1, Box b2)
        {
            Box temp = new Box();
            temp.length = b1.length + b2.length;
            temp.breadth = b1.breadth + b2.breadth;
            return temp;
        }

        static void Main()
        {
            Box b1 = new Box();
            Console.Write("Enter the Box 1 length : ");
            b1.length = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the Box 1 Breadth : ");
            b1.breadth = Convert.ToInt32(Console.ReadLine());

            Box b2 = new Box();
            Console.Write("Enter the Box 2 length : ");
            b2.length = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the Box 2 Breadth : ");
            b2.breadth = Convert.ToInt32(Console.ReadLine());

            Box b3 = b1 + b2;
            Console.WriteLine("The length and Breadth of the New Box is : {0} and {1}",b3.length,b3.breadth);
            Console.Read();
        }
    }
}
