using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCC1
{
    class Program
    {
        static void display(IEnumerable<Employee> emp)
        {
            foreach(var v in emp)
            {
                Console.WriteLine($"ID : {v.EmployeeID}, First Name : {v.FirstName}, Last Name : {v.LastName}, Title : {v.Title}, " +
                    $"DOB : {v.DOB}, DOJ : {v.DOJ}, City : {v.City}");
            }
        }
        static void Main(string[] args)
        {
            List<Employee> empList = new List<Employee>
            {
                new Employee { EmployeeID = 1001, FirstName = "Malcolm", LastName = "Daruwalla", Title = "Manager", DOB = new DateTime(1984,11,16), DOJ = new DateTime(2011,06,08), City = "Mumbai" },
                new Employee { EmployeeID = 1002, FirstName = "Asdin", LastName = "Dhalla", Title = "AsstManager", DOB = new DateTime(1994,08,20), DOJ = new DateTime(2012,07,07), City = "Mumbai" },
                new Employee { EmployeeID = 1003, FirstName = "Madhavi", LastName = "Oza", Title = "Consultant", DOB = new DateTime(1987,11,14), DOJ = new DateTime(2015,04,12), City = "Pune" },
                new Employee { EmployeeID = 1004, FirstName = "Saba", LastName = "Shaikh", Title = "SE", DOB = new DateTime(1990,06,03), DOJ = new DateTime(2016,02,02), City = "Pune" },
                new Employee { EmployeeID = 1005, FirstName = "Nazia", LastName = "Shaikh", Title = "SE", DOB = new DateTime(1991,03,08), DOJ = new DateTime(2016,02,02), City = "Mumbai" },
                new Employee { EmployeeID = 1006, FirstName = "Amit", LastName = "Pathak", Title = "Consultant", DOB = new DateTime(1989,11,07), DOJ = new DateTime(2014,08,08), City = "Chennai" },
                new Employee { EmployeeID = 1007, FirstName = "Vijay", LastName = "Natrajan", Title = "Consultant", DOB = new DateTime(1989,12,02), DOJ = new DateTime(2015,06,01), City = "Mumbai" },
                new Employee { EmployeeID = 1008, FirstName = "Rahul", LastName = "Dubey", Title = "Associate", DOB = new DateTime(1993,11,11), DOJ = new DateTime(2014,11,06), City = "Chennai" },
                new Employee { EmployeeID = 1009, FirstName = "Suresh", LastName = "Mistry", Title = "Associate", DOB = new DateTime(1992,08,12), DOJ = new DateTime(2014,12,03), City = "Chennai" },
                new Employee { EmployeeID = 1010, FirstName = "Sumit", LastName = "Shah", Title = "Manager", DOB = new DateTime(1991,04,12), DOJ = new DateTime(2016,01,02), City = "Pune" }
            };



            //Displaying all employees
            Console.WriteLine("Displaying all the Employees");
            var TotalEmployee = from v in empList
                                select v;
            display(TotalEmployee);

            Console.WriteLine();

            //Displaying details of all the employee whose location is not Mumbai
            Console.WriteLine("Displaying details of all the employee whose location is not Mumbai");
            var NotMumbai = from v in empList
                            where v.City.ToLower() != "mumbai"
                            select v;
            display(NotMumbai);

            Console.WriteLine();

            //Displaying details of all the employee whose title is AsstManager
            Console.WriteLine("Displaying details of all the employee whose title is AsstManager");
            var asst = from v in empList
                       where v.Title.ToLower() == "asstmanager"
                       select v;
            display(asst);

            Console.WriteLine();
            //Displaying details of all the employee whose Last Name start with S
            Console.WriteLine("Displaying details of all the employee whose Last Name start with S");
            var lastName = from v in empList
                           where v.LastName.StartsWith("S")
                           select v;
            display(lastName);

            Console.Read();
        }
    }
}
