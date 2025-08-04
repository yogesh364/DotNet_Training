using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    class Access
    {

        List<Employee> emp = Employee.getEmployee();


       
        public void joinedBefore(DateTime date)
        {
            var join = from v in emp
                       where v.DOJ < date
                       orderby v.EmployeeID
                       select v;
            Looping(join);   
        }

       
        public void joinedAfter(DateTime date)
        {
            var join = from v in emp
                       where v.DOB > date
                       orderby v.EmployeeID
                       select v;
            Looping(join);
        }

       
        public void desig()
        {
            var desi = from v in emp
                       where v.Title == "Consultant" || v.Title == "Associate"
                       orderby v.EmployeeID
                       select v;
            Looping(desi);
        }

        
        public void totalCount()
        {
            var count = (from v in emp
                         select v).Count();
            Console.WriteLine("Total Count : "+ count);
                        
        }

        
        public void chennaiCount()
        {
            var count = (from v in emp
                         where v.City == "Chennai"
                         select v).Count();
            Console.WriteLine("Employee Count in Chennai : "+count);
        }

        
        public void highestID()
        {
            var high = (from v in emp
                        orderby v.EmployeeID ascending
                        select v).LastOrDefault();
            Console.WriteLine("Highest Employee ID from the List : " + high.EmployeeID);
        }
        
        public void afterJoinedCount(DateTime date)
        {
            var afterCount = (from v in emp
                              where v.DOJ > date
                              select v).Count();
            Console.WriteLine("Total number of employee who have joined after 1/1/2015 : " + afterCount);
        }

        public void notDesig()
        {
            var not = from v in emp
                      where v.Title != "Associate"
                      select v;
            Console.WriteLine("Total employees whose designation is NOT Associate: " + not);
        }

        public void cityBased()
        {
            var city = emp.GroupBy(e => e.City);

            foreach(var v in city)
            {
                Console.WriteLine($"City : {v.Key}, Count : {v.Count()}");
            }
        }

        public void empCount()
        {
            var empcount = emp.GroupBy(e => new { e.City, e.Title }).OrderBy(ef => ef.Key.City);
            foreach(var v in empcount)
            {
                Console.WriteLine($"City : {v.Key.City}, Title : {v.Key.Title}, Count : {v.Count()}");
            }
        }

        public void youngCount()
        {
            var young = emp.Max(e => e.DOB);
            var youngemp = (from v in emp
                            where v.DOB == young
                            select v).Count();
            Console.WriteLine("Total number of youngest employee: " + youngemp);
        }
        public void Looping(IEnumerable<Employee> e)
        {
            foreach (var v in e)
            {
                Console.WriteLine($"Employee Id : {v.EmployeeID}, FirstName : {v.FirstName}, LastName : {v.LastName}, Title : {v.Title}, DOB : {v.DOB}, DOJ : {v.DOJ}, City : {v.City}");
            }
        }
    }
    class Employee
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public DateTime DOB { get; set; }
        public DateTime DOJ { get; set; }
        public string City { get; set; }

        public static List<Employee> getEmployee()
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

            return empList;
        }

       
    }
}
