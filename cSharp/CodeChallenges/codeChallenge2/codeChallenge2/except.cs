using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace codeChallenge2
{
    class except
    {
        public static void check(int number)
        {
            if (number < 0)
            {
                throw new ArgumentException("Number cannot be negative.");
            }
            else
            {
                Console.WriteLine("The Number is Valid Integer : " + number);
            }
        }
    }
    class runner
    {
        static void Main()
        {
            except e = new except();
            Console.Write("Enter an integer: ");
            try
            {
                int num = Convert.ToInt32(Console.ReadLine());
                except.check(num);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ext)
            {
                Console.WriteLine(ext.Message);
            }

            Console.ReadLine();
        }
    }
}
