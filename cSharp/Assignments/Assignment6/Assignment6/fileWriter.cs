using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Assignment6
{
    //program to write array of string in a file
    class fileWrite
    {
        static void Main()
        {
            try
            {
                Console.Write("Enter the Number of Lines to be Entererd in the string : ");
                int n = Convert.ToInt32(Console.ReadLine());
                string[] arr = new string[n];

                for (int i = 0; i < n; i++)
                {
                    Console.Write("Enter the string in Line {0} : ", i);
                    arr[i] = Console.ReadLine();
                }

                string filePath = @"C:\YOGESH_V\DotNetTraining\cSharp\Assignments\Assignment6\Assignment6\ArrayofString";

                Stream use = new FileStream(filePath, FileMode.Create, FileAccess.Write);
                using (StreamWriter sw = new StreamWriter(use))
                {
                    foreach (string s in arr)
                    {
                        sw.WriteLine(s);
                    }
                }

                Console.WriteLine("String uploaded to file successfully");
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.Read();
        }
    }
}
