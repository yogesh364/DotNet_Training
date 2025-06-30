using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding
{
    class employee
    {
        public int id { get; set; }
        public string name { get; set; }
        public string dept { get; set; }
        public double salary { get; set; }

        List<employee> emp = new List<employee>();


        //adding employee
        internal void addEmployee(employee e)
        {
            emp.Add(e);
        }

        //displaying Employee Details
        internal void displayEmployee()
        {
            if (emp.Count == 0)
            {
                Console.WriteLine();
                Console.WriteLine("No Employees Found, Add the Employee before Displaying !!");
                Console.WriteLine();
            }
            foreach (var item in emp)
            {
                Console.WriteLine($"Id : {item.id}, Name : {item.name}, Dept : {item.dept}, Salary : {item.salary}");
            }
        }

        //search Employe by Id
        internal void searchById(int ID)
        {
            if (emp.Count == 0)
            {
                Console.WriteLine();
                Console.WriteLine("Enter the Employee ID Correctly !!");
                Console.WriteLine();
            }
            foreach (var item in emp)
            {
                if (item.id == ID)
                {
                    Console.WriteLine("The Details with respect to Employee Id :");
                    Console.WriteLine($"Name : {item.name}, Department : {item.dept}, Salary : {item.salary}");

                }
            }
        }

        internal void updateEmployee(int ID)
        {
            if (emp.Count == 0)
            {
                Console.WriteLine();
                Console.WriteLine("No Employees Found, Add the Employee before Updating !!");
                Console.WriteLine();
            }
            foreach (var item in emp)
            {
                if (item.id == ID)
                {
                    Console.Write("Enter the Name to be Updated :");
                    String Name = Console.ReadLine();
                    item.name = Name;
                    Console.Write("Enter the Department to be Updated :");
                    String Dept = Console.ReadLine();
                    item.dept = Dept;
                    Console.Write("Enter the Salary to be Updated :");
                    double sal = Convert.ToDouble(Console.ReadLine());
                    item.salary = sal;

                }
            }
        }
        //delete Employee
        internal void deleteEmployee(int ID)
        {
            if (emp.Count == 0)
            {
                Console.WriteLine();
                Console.WriteLine("No Employees Found, Add the Employee before Deleting !!");
                Console.WriteLine();
            }
            for (int i = 0; i < emp.Count; i++)
            {
                if (emp[i].id == ID)
                {
                    emp.RemoveAt(i);
                }
            }

        }


    }

    class main
    {
        static void Main()
        {
            employee Emp = new employee();
            int n;
            try
            {
                do
                {
                    Console.WriteLine("===== Employee Management Menu =====");
                    Console.WriteLine("1. Add New Employee");
                    Console.WriteLine("2. View All Employees");
                    Console.WriteLine("3. Search Employee by ID");
                    Console.WriteLine("4. Update Employee Details");
                    Console.WriteLine("5. Delete Employee");
                    Console.WriteLine("6. Exit");
                    Console.WriteLine("====================================");

                    Console.Write("Enter Your Choice : ");
                    n = Convert.ToInt32(Console.ReadLine());


                    switch (n)
                    {
                        case 1:

                            Console.Write("Enter the Employee ID : ");
                            int ID = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Enter the Employee Name :");
                            string Name = Console.ReadLine();
                            Console.Write("Enter the Employee Department :");
                             string Dept= Console.ReadLine();
                            Console.Write("Enter the Employee Salary :");
                            double Salary = Convert.ToDouble(Console.ReadLine());
                            Emp.addEmployee(new employee { id = ID, name = Name, dept = Dept, salary = Salary });
                            Console.WriteLine();
                            Console.WriteLine("Employee Details added succesfully !!!");
                            Console.WriteLine();
                            break;

                        case 2:
                            Emp.displayEmployee();
                            Console.WriteLine();
                            break;

                        case 3:
                            Console.Write("Enter the Id : ");
                            int num = Convert.ToInt32(Console.ReadLine());
                            Emp.searchById(num);
                            Console.WriteLine();
                            break;

                        case 4:
                            Console.Write("Enter the Id : ");
                            int o = Convert.ToInt32(Console.ReadLine());
                            Emp.updateEmployee(o);
                            Console.WriteLine();
                            break;

                        case 5:
                            Console.Write("Enter the Id : ");
                            int m = Convert.ToInt32(Console.ReadLine());
                            Emp.deleteEmployee(m);
                            Console.WriteLine();
                            break;

                        default:
                            Console.WriteLine("Good Bye");
                            break;


                    }
                } while (n < 6);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Employee details program executed Successflly!!!");
            }
            Console.ReadLine();

        }
    }

}

