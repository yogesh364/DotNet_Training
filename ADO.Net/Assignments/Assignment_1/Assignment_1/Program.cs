using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Access ac = new Access();

            // 1. Display a list of all the employee who have joined before 1/1/2015
            Console.WriteLine("List of all the employee who have joined before 1/1/2015 : ");
            ac.joinedBefore(new DateTime(2015, 01, 01));
            Console.WriteLine();

            //2. Display a list of all the employee whose date of birth is after 1/1/1990
            Console.WriteLine("List of all the employee whose date of birth is after 1/1/1990 : ");
            ac.joinedAfter(new DateTime(1990, 01, 01));
            Console.WriteLine();

            //3. Display a list of all the employee whose designation is Consultant and Associate
            Console.WriteLine("List of all the employee whose designation is Consultant and Associate : ");
            ac.desig();
            Console.WriteLine();

            //4. Display total number of employees
            ac.totalCount();
            Console.WriteLine();

            //5. Display total number of employees belonging to “Chennai”
            ac.chennaiCount();
            Console.WriteLine();

            //6. Display highest employee id from the list
            ac.highestID();
            Console.WriteLine();

            //7. Display total number of employee who have joined after 1/1/2015
            ac.afterJoinedCount(new DateTime(2015, 01, 10));
            Console.WriteLine();

            //8. Display total number of employee whose designation is not “Associate"
            ac.notDesig();
            Console.WriteLine();

            //9. Display total number of employee based on City
            Console.WriteLine("Total number of employee based on City : ");
            ac.cityBased();
            Console.WriteLine();

            //10. Display total number of employee based on city and title
            Console.WriteLine("Total number of employee based on city and title : ");
            ac.empCount();
            Console.WriteLine();

            //11.Display total number of employee who is youngest in the list
            ac.youngCount();

            Console.Read();
        }
    }
}
