using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Railway_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                BusinessLogic bl = new BusinessLogic();

                while (true)
                {
                    Console.WriteLine("==========================================================");
                    Console.WriteLine("                TRAIN RESERVATION SYSTEM                  ");
                    Console.WriteLine("==========================================================");
                    Console.WriteLine();

                    Console.WriteLine("1. Register (user)");
                    Console.WriteLine("2. Login");
                    Console.WriteLine("3. Exit");
                    Console.WriteLine();

                    Console.Write("Enter your choice : ");
                    int ans = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();

                    if(ans == 1)
                    {
                        bl.InsertToUser();
                        Console.WriteLine();
                    }
                    else if(ans == 2) 
                    {
                        while (true)
                        {
                            Console.WriteLine("===========================================");
                            Console.WriteLine("               Login Portal                ");
                            Console.WriteLine("===========================================");
                            Console.WriteLine();
                            Console.WriteLine("Enter Your Way of Login : ");
                            Console.WriteLine("1. User Login ");
                            Console.WriteLine("2. Admin Login ");
                            Console.WriteLine("3. Main Menu ");
                            Console.WriteLine();

                            Console.Write("Enter Your Choice : ");
                            int choice = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine();

                            if (choice == 1)
                            {
                                bl.userLogin();
                            }
                            else if(choice == 2)
                            {
                                bl.adminLogin();
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    else 
                    { 
                        return;
                    }
                }
            }
            catch(SqlException es)
            {
                Console.WriteLine(es.Message);
            }

            Console.Read();
        }
    }
}
