using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment7
{
    class employee
    {
        public int empId { get; set; }
        public string empName { get; set; }
        public string empCity { get; set; }
        public int empSalary { get; set; }



        public static List<employee> getData()
        {

            List<employee> emp = new List<employee>();

            Console.Write("Enter the Number of Employee Details to be added : ");
            int n = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                Console.Write("Enter the Employee ID : ");
                int ID = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter the Employee Name : ");
                string Name = Console.ReadLine();
                Console.Write("Enter the Employee City : ");
                string city = Console.ReadLine();
                Console.Write("Enter the Employee Salary : ");
                int Salary = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                emp.Add(new employee
                {
                    empId = ID,
                    empName = Name,
                    empCity = city,
                    empSalary = Salary
                });
            }

            return emp;
        }

        public static void display(List<employee> empList)
        {
            foreach (var emp in empList)
            {
                Console.WriteLine($"Emp ID : {emp.empId}, Emp Name : {emp.empName}, Emp City : {emp.empCity}, Emp Salary : {emp.empSalary}");
            }
        }

        
    }
    class data
    {
        static void Main()
        {
            List<employee> empList = employee.getData();

            Console.WriteLine("The Employee Details are :");
            employee.display(empList);
            Console.WriteLine();

            Console.WriteLine("The employee Data whose salary is greater than 45000 are :");
            var sal = from v in empList
                      where v.empSalary >= 45000
                      select v;

            foreach(var v in sal)
            {
                Console.WriteLine($"Emp ID : {v.empId}, Emp Name : {v.empName}, Emp City : {v.empCity}, Emp Salary : {v.empSalary}");
            }
            Console.WriteLine();

            Console.WriteLine("The employee Data who belongs to Bangalore are :");
            var city = from v in empList
                      where v.empCity.ToLower() == "bangalore"
                      select v;

            foreach (var v in city)
            {
                Console.WriteLine($"Emp ID : {v.empId}, Emp Name : {v.empName}, Emp City : {v.empCity}, Emp Salary : {v.empSalary}");
            }
            Console.WriteLine();
            Console.WriteLine("Sorted Employee Details by their Name are :");
            empList.Sort((a, b) => a.empName.CompareTo(b.empName));

            foreach(var v in empList)
            {
                Console.WriteLine($"Emp ID : {v.empId}, Emp Name : {v.empName}, Emp City : {v.empCity}, Emp Salary : {v.empSalary}");
            }

            Console.ReadLine();
        }
    }

}
