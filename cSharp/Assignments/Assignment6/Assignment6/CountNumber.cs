using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Assignment6
{
    class CountNumber { 
        static void Main() 
        {
            try
            {
                string filePath = @"C:\YOGESH_V\DotNetTraining\cSharp\Assignments\Assignment6\Assignment6\ArrayofString";

                Stream str = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                int lines = 0;
                using (StreamReader sr = new StreamReader(str))
                {
                    while (sr.ReadLine() != null)
                    {
                        lines++;
                    }
                }

                Console.WriteLine("The Number of Lines in the FIle is : {0}", lines);
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        } 
    }
}
