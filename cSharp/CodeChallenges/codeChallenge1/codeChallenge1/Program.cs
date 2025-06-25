using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace codeChallenge1
{
    class Program
    {
        //Write a C# Sharp program to remove the character at a given position in the string.
        //The given position will be in the range 0..(string length -1) inclusive.

        public static void removeString(string name, int number)
        {
            string ans= " ";
            char[] ch = name.ToCharArray();
            for (int i = 0; i < ch.Length; i++)
            {
                if(i == number)
                {
                    continue;
                }
                ans += ch[i];
            }
            Console.WriteLine(ans);
        }

        public static void remove()
        {
            Console.Write("Enter the Word : ");
            string s = Console.ReadLine();
            Console.Write("Enter the index of letter to be removed : ");
            int n = Convert.ToInt32(Console.ReadLine());
            removeString(s, n);
        }

        /* Output :
         *   Enter the Word : Yogesh
             Enter the index of letter to be removed : 2
             Yoesh */
    }

    class swapChararcters
    {

        //Write a C# Sharp program to exchange the first and last characters in a given string and return the new string.
        public static string swap(string s)
        {
            if (s.Length < 2) return s;

            char first = s[0];
            char last = s[s.Length - 1];

            String middle = s.Substring(1, s.Length - 2);

            return last + middle + first;

        }
        public static void getInput()
        {
            Console.Write("Enter the String : ");
            string str = Console.ReadLine();
            Console.WriteLine("The values after exchangin first and letter in ths string is : " + swap(str));
        }

        /* Output :
         *  Enter the String : abcd
            The values after exchangin first and letter in ths string is : dbca */
    }

    class largestInteger
    {
        //Write a C# Sharp program to check the largest number among three given integers.
        public static void largestNo(int a, int b, int c)
        {
            if(a>b && a > c)
            {
                Console.WriteLine("The largest Number is : " +a);
            }else if(b>a && b > c)
            {
                Console.WriteLine("The largest Number is : " + b);
            }
            else
            {
                Console.WriteLine("The largest Number is : " + c);
            }
        }
        public static void getData()
        {
            Console.Write("Enter the First Number : ");
            int a = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter the First Number : ");
            int b = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter the First Number : ");
            int c = Convert.ToInt32(Console.ReadLine());

            largestNo(a, b, c);
        }
        /*Output:
         *  Enter the First Number : 10
            Enter the First Number : 20
            Enter the First Number : 30
            The largest Number is : 30 */
    }
    class main
    {
        static void Main(string[] args)
        {
            Program.remove();  // 1
            swapChararcters.getInput(); // 2
            largestInteger.getData(); // 3
            Console.ReadLine();

        }
    }
}
