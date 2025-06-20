using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    class stringAssignment
    {

        public static void Main()
        {
            Console.WriteLine("-----------Length of String--------------");
            lengthOfString();
            Console.WriteLine("-------------------------");
            Console.WriteLine("-----------Reverse of String--------------");
            reverseString();
            Console.WriteLine("-------------------------");
            Console.WriteLine("-----------check two strings are equal or not--------------");
            equalString();
            Console.WriteLine("-------------------------");
           
            
            
            Console.Read();
        }


        //Write a program in C# to accept a word from the user and display the length of it.

        public static void lengthOfString()
        {
            Console.Write("Enter a String :");
            String str = Console.ReadLine();

            //char[] c = str.ToCharArray();
            //int n = c.Length;
            //Console.WriteLine("The length of the string is : "+n);

            //Either of the methods can be used to get the length of the string

          int len = str.Length;
            Console.WriteLine("The length of the string is : " + len);

            /* Output:
             *  Enter a String :Yogesh
                The length of the string is : 6 */
        }

        //Write a program in C# to accept a word from the user and display the reverse of it. 

        public static void reverseString()
        {
            Console.Write("Enter a String :");
            String str = Console.ReadLine();
            String reverse = "";
            int len = str.Length - 1;
            while (len >= 0)
            {
                reverse += str[len--];
            }
            Console.WriteLine("The reverse of the String is : "+reverse);

            /*Output:
             *   Enter a String :Yogesh
                The reverse of the String is : hsegoY */
        }

        //Write a program in C# to accept two words from user and find out if they are same. 
        public static void equalString()
        {
            Console.Write("Enter The First String :");
            String str = Console.ReadLine();
            Console.Write("Enter The Second String :");
            String str1 = Console.ReadLine();

            string s = (str == str1) ? "The strings are equal " : "The strings are not equal";
            Console.WriteLine(s);

            //if (str.Equals(str1))
            //    Console.WriteLine("The strings are equal");
            //else
            //    Console.WriteLine("The strings are not equal");

            /* Output
             *  Enter The First String :Yogesh
                Enter The Second String :Yogesh
                The strings are equal
             */
        }
    }
}
