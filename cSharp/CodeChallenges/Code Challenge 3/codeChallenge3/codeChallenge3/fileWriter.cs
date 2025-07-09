using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace codeChallenge3
{
    class fileWriter
    {
        static void Main()
        {
            try
            {
                string filePath =
                    @"C:\YOGESH_V\DotNetTraining\cSharp\CodeChallenges\Code Challenge 3\codeChallenge3\StringText";

                using (StreamWriter sw = File.AppendText(filePath))
                {
                    sw.WriteLine("This is First Line");
                    sw.WriteLine("This is Second Line");
                    sw.WriteLine("This is Third Line");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Executed Successfully !!!");
            }
            Console.Read();
        }
    }
}
