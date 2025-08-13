using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Railway_Project
{
    class BusinessLogicAdmin
    {
        public static int adminID { get; set; }
        public static string adminName { get; set; }
        public static string Password { get; set; }

        public void adminLogin()
        {
            Console.WriteLine("------------ Admin Login ------------");
            Console.WriteLine();

            Console.Write("Enter Your AdminName : ");
            adminName = Console.ReadLine();

            Console.Write("Enter Your Password : ");
            Password = Console.ReadLine();
            Console.WriteLine();

            if (DataAccessAdmin.adminLoginCheck(adminName, Password))
            {
                adminID = DataAccess.adminLogin(adminName, Password);

                if (adminID <= 0)
                {
                    Console.WriteLine("Login Failed, Could not fetch UserID !");
                    return;
                }

                Console.WriteLine($"Login Successful ! Welcome {adminName}");
                Console.WriteLine();
                Console.WriteLine("--------------------------------------------------------");
                Console.WriteLine();

                Console.WriteLine("Press Any Button to Admin DashBoard !!");
                Console.ReadKey();
                Console.Clear();
                AdminDashBoard();

            }
            else
            {
                Console.WriteLine("Login Failed ! Please Enter Valid UserName and Password.");
                Console.WriteLine();
                Console.WriteLine("--------------------------------------------------------");
                Console.WriteLine();
                Console.WriteLine("Press any Key ");
                Console.ReadKey();
                Console.WriteLine();
                Console.Clear();
            }
        }

        public void AdminDashBoard()
        {
            while (true)
            {
                Console.WriteLine("------------------- Admin DashBoard -------------------");
                Console.WriteLine("1. Train Details");
                Console.WriteLine("2. Add a train");
                Console.WriteLine("3. View Reservation Report ");
                Console.WriteLine("4. View WaitingList Report");
                Console.WriteLine("5. View Cancellation Report");
                Console.WriteLine("6. Exit to Main Menu");
                Console.WriteLine();

                Console.Write("Enter Your Choice : ");
                int ans = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                if (ans == 1)
                {

                    SqlDataReader sdr = DataAccessAdmin.trainDetails();

                    if (sdr.HasRows)
                    {
                        Console.WriteLine("-------------- Available Trains --------------");
                        Console.WriteLine();
                        DataAccess.Looping(sdr);
                    }
                    else
                    {
                        Console.WriteLine("No Trains Available at the moment !!!");
                    }
                    Console.WriteLine("Press Any Key to Return to Admin DashBoard !!");
                    Console.WriteLine();
                    Console.ReadKey();
                    Console.Clear();
                }
                else if (ans == 2)
                {
                    Console.WriteLine("-------------- Enter Train Details --------------");

                    Console.Write("Enter the Train ID : ");
                    int trainID = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter the Train Name : ");
                    string trainName = Console.ReadLine();

                    Console.Write("Enter the Source : ");
                    string source = Console.ReadLine();

                    Console.Write("Enter the Destination : ");
                    string destination = Console.ReadLine();

                    Console.Write("Enter the Departure Time (hh:mm): ");
                    string Time = Console.ReadLine();

                    bool success = DataAccessAdmin.addTrain(trainID, trainName, source, destination, Time);

                    if (success)
                    {
                        Console.WriteLine("New Train Added Successfully !!");
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("Something Went Wrong Inserting a New Train !");
                        Console.WriteLine();
                    }

                    Console.WriteLine("Press Any Key to Return to Admin DashBoard !!");
                    Console.WriteLine();
                    Console.ReadKey();
                    Console.Clear();
                }
                else if (ans == 3)
                {
                    Console.Write("Enter the Starting Date (yyyy-mm-dd) : ");
                    DateTime d1 = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine();

                    Console.Write("Enter the Ending Date (yyyy-mm-dd) : ");
                    DateTime d2 = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine();

                    if (d1 > d2)
                    {
                        Console.WriteLine("Starting date cannot be after the ending date. Please try again.");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                        continue; 
                    }

                    SqlDataReader sdr = DataAccessAdmin.get_reservation(d1, d2);

                    if (sdr.HasRows)
                    {
                        Console.WriteLine("-------------- Reservation Report --------------");
                        Console.WriteLine();

                        DataAccess.heading("Reservation ID");

                        while (sdr.Read())
                        {
                            DataAccessAdmin.printDetails("ReservationID");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Reservation Details Available at the moment !!!");
                    }
                    Console.WriteLine("Press Any Key to Return to Admin DashBoard !!");
                    Console.WriteLine();
                    Console.ReadKey();
                    Console.Clear();
                }
                else if (ans == 4)
                {

                    Console.Write("Enter the Starting Date (yyyy-mm-dd) : ");
                    DateTime d1 = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine();

                    Console.Write("Enter the Ending Date (yyyy-mm-dd) : ");
                    DateTime d2 = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine();

                    if (d1 > d2)
                    {
                        Console.WriteLine("Starting date cannot be after the ending date. Please try again.");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                        continue;
                    }

                    SqlDataReader sdr = DataAccessAdmin.get_waiting(d1, d2);

                    if (sdr.HasRows)
                    {
                        Console.WriteLine("-------------- WaitingList Report --------------");
                        Console.WriteLine();

                        DataAccess.heading("Waiting ID");

                        while (sdr.Read())
                        {
                            DataAccess.printDetails("WaitingID");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Waiting List Details  Available at the moment !!!");
                    }
                    Console.WriteLine("Press Any Key to Return to Admin DashBoard !!");
                    Console.WriteLine();
                    Console.ReadKey();
                    Console.Clear();
                }
                else if (ans == 5)
                {

                    Console.Write("Enter the Starting Date (yyyy-mm-dd) : ");
                    DateTime d1 = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine();

                    Console.Write("Enter the Ending Date (yyyy-mm-dd) : ");
                    DateTime d2 = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine();

                    if (d1 > d2)
                    {
                        Console.WriteLine("Starting date cannot be after the ending date. Please try again.");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                        continue;
                    }

                    SqlDataReader sdr = DataAccessAdmin.get_cancellation(d1,d2);

                    if (sdr.HasRows)
                    {
                        Console.WriteLine("-------------- Cancellation Report --------------");
                        Console.WriteLine();

                        DataAccessAdmin.printCancel(sdr);
                    }
                    else
                    {
                        Console.WriteLine("No Cancellation Details  Available at the moment !!!");
                    }
                    Console.WriteLine("Press Any Key to Return to Admin DashBoard !!");
                    Console.WriteLine();
                    Console.ReadKey();
                    Console.Clear();
                }
                else if (ans == 6)
                {
                    Console.Clear();
                    return;
                }
                else
                {
                    Console.WriteLine("Enter Proper Input !");
                    Console.WriteLine();
                    Console.Clear();
                }
            }
        }
    }
}
