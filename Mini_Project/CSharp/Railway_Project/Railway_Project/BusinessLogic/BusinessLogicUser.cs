using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Railway_Project
{
    class BusinessLogic
    {
        public static int UserID { get; set; }
        public static string UserName { get; set; }
        public static string Password { get; set; }
        public static long phone { get; set; }
        public static string email { get; set; }

        public static string source { get; set; }
        public static string destination { get; set; }
        public static DateTime date { get; set; }
        public static int trainID { get; set; }
        public static string seatClass { get; set; }
        public static int passengerCount { get; set; }
        public static double pricePerSeat { get; set; }



        public void InsertToUser()
        {
            Console.WriteLine("----- User Registration -----");
            Console.WriteLine();

            Console.Write("Enter Your Name : ");
            UserName = Console.ReadLine();

            Console.Write("Create Your Password [Must be of characters and numbers] : ");
            Password = Console.ReadLine();

            Console.Write("Enter Your Mobile Number : ");
            phone = Convert.ToInt64(Console.ReadLine());

            Console.Write("Enter Your Email ID : ");
            email = Console.ReadLine();
            Console.WriteLine();

            int result = DataAccess.insertUserDetails(UserName, Password, phone, email);

            if (result > 0)
            {
                Console.WriteLine("Record Added Successfully !!!");

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Adding Data Failed !!!");
                Console.WriteLine("Please Enter Valid UserInfo");
                Console.WriteLine();
            }

            Console.WriteLine("Press Any Key to Return to Main Menu !!");
            Console.WriteLine();
            Console.ReadKey();
        }

        public void userLogin()
        {
            Console.WriteLine("------------ User Login ------------");
            Console.WriteLine();

            Console.Write("Enter Your UserName : ");
            UserName = Console.ReadLine();

            Console.Write("Enter Your Password : ");
            Password = Console.ReadLine();
            Console.WriteLine();

            if (DataAccess.UserLoginCheck(UserName, Password))
            {
                UserID = DataAccess.login(UserName, Password);

                if (UserID <= 0)
                {
                    Console.WriteLine("Login Failed, Could not fetch UserID !");
                    return;
                }

                Console.WriteLine($"Login Successful ! Welcome {UserName}");
                Console.WriteLine();
                Console.WriteLine("--------------------------------------------------------");
                Console.WriteLine();

                Console.WriteLine("Press Any Button to User DashBoard !!");
                Console.ReadKey();
                Console.Clear();
                UserDashBoard();

            }
            else
            {
                Console.WriteLine("Login Failed ! Please Enter Valid UserName and Password.");
                Console.WriteLine();
                Console.WriteLine("--------------------------------------------------------");
                Console.WriteLine();
                Console.WriteLine("Press any Key ");
                Console.WriteLine();
                Console.ReadKey();
                Console.Clear();
            }

        }

        public void UserDashBoard()
        {
            while (true)
            {
                Console.WriteLine("------------------- User DashBoard -------------------");
                Console.WriteLine("1. Train Details");
                Console.WriteLine("2. Make Reservation");
                Console.WriteLine("3. View My Bookings");
                Console.WriteLine("4. Cancel Booking");
                Console.WriteLine("5. Exit to Main Menu");
                Console.WriteLine();

                Console.Write("Enter Your Choice : ");
                int ans = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                if (ans == 1)
                {

                    Console.Write("Enter Travel Date (yyyy-mm-dd) : ");
                    DateTime Date = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine();

                    if (Date < DateTime.Now.Date)
                    {
                        Console.WriteLine("Details Cannot be fetched for Past Date.");
                        continue;
                    }

                    SqlDataReader sdr = DataAccess.trainDetails(Date);

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
                    Console.WriteLine("Press Any Key to Return to User DashBoard !!");
                    Console.WriteLine();
                    Console.ReadKey();
                }
                else if (ans == 2)
                {
                    Console.WriteLine("----------------- Booking Portal -----------------");
                    Console.WriteLine();

                    Console.Write("Enter Source : ");
                    source = Console.ReadLine();

                    Console.Write("Enter Destination : ");
                    destination = Console.ReadLine();

                    Console.Write("Enter Travel Date (yyyy-mm-dd) : ");
                    DateTime Date1 = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine();

                    if (Date1 < DateTime.Now.Date)
                    {
                        Console.WriteLine("Details Cannot be fetched for Past Date.");
                        continue;
                    }

                    SqlDataReader sdr = DataAccess.getTrainDetails(source, destination);

                    if (sdr.HasRows)
                    {
                        Console.WriteLine("----------------- Available Trains -----------------");
                        Console.WriteLine();
                        DataAccess.Looping(sdr);
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("No Such Trains with the given Route or Date !!!");
                        Console.WriteLine();
                        continue;
                    }

                    Console.WriteLine("----------------- Enter Train Details -----------------");
                    Console.WriteLine();
                    Console.Write("Enter Train ID : ");
                    trainID = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter the class [Sleeper, 3rd-AC, 2nd-AC] : ");
                    seatClass = Console.ReadLine();

                    Console.Write("Enter the Total Number of Passengers (Maximum 6) : ");
                    passengerCount = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();

                    if (passengerCount > 6)
                    {
                        Console.WriteLine("Cannot Book for more than 6 Passengers !!");
                        Console.WriteLine();
                        continue;
                    }
                    else if (passengerCount < 1)
                    {
                        Console.WriteLine("Passenger Count must be atleast 1");
                        Console.WriteLine();
                        continue;
                    }

                    var (availableSeats, Price) = DataAccess.getAvailability(trainID, seatClass);
                    pricePerSeat = Price;

                    if (availableSeats == -1 || Price == -1)
                    {
                        Console.WriteLine("No Seat Data for the Selected Train and CLass");
                        Console.WriteLine();
                        continue;
                    }

                    if (availableSeats >= passengerCount)
                    {
                        Console.WriteLine("The Seats are Available for the given Passenger Count.");
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("The Seat Availability for the given Passenger Count is Not Available, Your Booking will be in waiting list !!!");
                        Console.WriteLine();
                        Console.Write("Confirm to Proceed [y/n] : ");
                        string confirm = Console.ReadLine();
                        Console.WriteLine();

                        if (!(confirm.ToLower() == "y"))
                        {
                            Console.WriteLine("Booking Cancelled by User.");
                            Console.WriteLine();
                            continue;
                        }
                        Console.WriteLine();
                    }

                    double totalAmount = Price * passengerCount;
                    Console.WriteLine($"Total Fare : {totalAmount}");
                    Console.WriteLine();

                    Console.Write("Confirm Booking [y/n] : ");
                    string ConfirmBooking = Console.ReadLine();
                    Console.WriteLine();

                    if (!(ConfirmBooking.ToLower() == "y"))
                    {
                        Console.WriteLine("Booking Cancelled by User.");
                        Console.WriteLine();
                        continue;
                    }

                    int res = DataAccess.createReservation(UserID, trainID, Date1, seatClass, passengerCount);

                    if (res > 8000)
                    {
                        Console.WriteLine("Reservation Confirmed. Enter Passenger Details : ");
                        Console.WriteLine();

                        for (int i = 0; i < passengerCount; i++)
                        {
                            Console.WriteLine($"Enter Details of Passenger {i + 1} : ");
                            Console.WriteLine();

                            Console.Write("Name : ");
                            string name = Console.ReadLine();
                            Console.Write("Age : ");
                            int age = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Gender : ");
                            string gen = Console.ReadLine();
                            Console.Write("Phone : ");
                            string mobile = Console.ReadLine();
                            Console.WriteLine();

                            int passengerID = DataAccess.insertPassenger(res, null, name, age, gen, mobile);

                            Console.WriteLine($"Passenger Added. Passenger ID : {passengerID}");
                            Console.WriteLine();
                        }
                        Console.WriteLine($"Booking Completed Successfully !!!");
                        Console.WriteLine();

                        Console.WriteLine("-----------------------------------------------");
                        Console.WriteLine("                 Booking Details               ");
                        Console.WriteLine("-----------------------------------------------");
                        Console.WriteLine();
                        Console.WriteLine($"Reservation ID   : {res}");
                        Console.WriteLine($"Train ID         : {trainID}");
                        Console.WriteLine($"Source           : {source}");
                        Console.WriteLine($"Destination      : {destination}");
                        Console.WriteLine($"Total Passengers : {passengerCount}");
                        Console.WriteLine($"Amount Paid      : {totalAmount}");
                        Console.WriteLine("Status           : CONFIRMED");
                        Console.WriteLine();
                        Console.WriteLine("-----------------------------------------------");

                    }
                    else
                    {
                        Console.WriteLine($"Booking Added to the Waiting List. Your Booking will be Added to Reservation when the Seats is/are available.");
                        Console.WriteLine();

                        for (int i = 0; i < passengerCount; i++)
                        {
                            Console.WriteLine($"Enter Details of Passenger {i + 1} : ");
                            Console.WriteLine();

                            Console.Write("Name : ");
                            string name = Console.ReadLine();
                            Console.Write("Age : ");
                            int age = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Gender : ");
                            string gen = Console.ReadLine();
                            Console.Write("Phone : ");
                            string mobile = Console.ReadLine();
                            Console.WriteLine();

                            int passengerID = DataAccess.insertPassenger(null, res, name, age, gen, mobile);

                            Console.WriteLine($"Passenger Added. Passenger ID : {passengerID}");
                            Console.WriteLine();
                        }
                        Console.WriteLine($"Booking Added to WaitingList Successfully !!!");
                        Console.WriteLine();

                        Console.WriteLine("-----------------------------------------------");
                        Console.WriteLine("               WaitingList Details             ");
                        Console.WriteLine("-----------------------------------------------");
                        Console.WriteLine();
                        Console.WriteLine($"Waiting ID   : {res}");
                        Console.WriteLine($"Train ID         : {trainID}");
                        Console.WriteLine($"Source           : {source}");
                        Console.WriteLine($"Destination      : {destination}");
                        Console.WriteLine($"Total Passengers : {passengerCount}");
                        Console.WriteLine($"Amount Paid      : {totalAmount}");
                        Console.WriteLine("Status           : WAITING");

                        Console.WriteLine();
                        Console.WriteLine("-----------------------------------------------");
                    }

                    Console.WriteLine("Press Any Key to return to the User DashBoard.");
                    Console.WriteLine();
                    Console.ReadKey();
                    Console.Clear();
                }
                else if (ans == 3)
                {
                    Console.WriteLine("Fetching the Reservation Details ..... ");
                    Console.WriteLine();

                    DataAccess.viewReservation(UserID);

                    Console.WriteLine("Press Any Key to return to the User DashBoard.");
                    Console.WriteLine();
                    Console.ReadKey();
                }
                else if (ans == 4)
                {
                    Console.WriteLine("--------------- Cancellation Portal ---------------");
                    Console.WriteLine();

                    Console.Write("Enter your ReservationID / WaitingID : ");
                    int reservationID = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();

                    if (reservationID > 8000)
                    {
                        var details = DataAccess.Reservation_Details(reservationID);

                        if (details.Class == null || details.travelDate == DateTime.MinValue)
                        {
                            Console.WriteLine("No booking found with the entered ReservationID or WaitingID.");
                            Console.WriteLine();
                            continue;
                        }

                        Console.Write("Enter Cancellation Type [F -> Full / P -> Partial] : ");
                        string cancelType = Console.ReadLine();
                        Console.WriteLine();

                        if (cancelType.ToLower() == "f")
                        {
                            double refund = DataAccess.calculateRefund(details.Price, details.totalSeats, details.travelDate);

                            Console.Write($"Refund Amount : {refund}");
                            Console.WriteLine();

                            Console.Write("Confirm Cancellation [y/n] : ");
                            string choice = Console.ReadLine();
                            Console.WriteLine();

                            if (choice.ToLower() == "y")
                            {
                                DataAccess.cancellation(reservationID, null, refund);
                                Console.WriteLine("Cancellation Successful !!!");
                                DataAccess.tranferWaiting(details.trainID, details.travelDate, details.Class);
                                Console.WriteLine();
                            }
                            else
                            {
                                Console.WriteLine("Cancellation Aborted !!");
                                Console.WriteLine();
                                continue;
                            }
                        }
                        else if (cancelType.ToLower() == "p")
                        {
                            Console.Write("Enter the Number of Passengers to Cancel : ");
                            int num = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine();

                            for (int i = 0; i < num; i++)
                            {
                                Console.Write("Enter The Passenger ID : ");
                                int passengerID = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();

                                double refund = DataAccess.calculateRefund(details.Price, 1, details.travelDate);

                                Console.WriteLine($"Refund Amount for the Passenger is : {refund}");
                                Console.WriteLine();

                                Console.Write("Confirm Cancellation [y/n] : ");
                                string res = Console.ReadLine();
                                Console.WriteLine();
                                if (res.ToLower() == "y")
                                {
                                    DataAccess.cancellation(reservationID, passengerID, refund);
                                    Console.WriteLine();
                                }
                                else
                                {
                                    Console.WriteLine("Cancellation Aborted !!");
                                    Console.WriteLine();
                                    continue;
                                }
                            }

                            Console.WriteLine("Partial Cancellation Completed !!!");
                            Console.WriteLine();
                            DataAccess.tranferWaiting(details.trainID, details.travelDate, details.Class);
                        }
                    }
                    else if (reservationID < 8000)
                    {
                        var details = DataAccess.Reservation_Details(reservationID);

                        if (details.Class == null || details.travelDate == DateTime.MinValue)
                        {
                            Console.WriteLine("No booking found with the entered ReservationID or WaitingID.");
                            Console.WriteLine();
                            continue;
                        }

                        Console.WriteLine("This is Waiting List Booking. Only Full Cancellation Allowed.");

                        double refund = DataAccess.calculateRefund(details.Price, details.totalSeats, details.travelDate);

                        Console.Write($"Refund Amount : {refund}");
                        Console.WriteLine();

                        Console.Write("Confirm Cancellation [y/n] : ");
                        string choice = Console.ReadLine();

                        if (choice.ToLower() == "y")
                        {
                            DataAccess.WaitingCancellation(reservationID, refund);
                            Console.WriteLine("Cancellation Successful !!!");
                            Console.WriteLine();
                            DataAccess.tranferWaiting(details.trainID, details.travelDate, details.Class);
                        }
                        else
                        {
                            Console.WriteLine("Cancellation Aborted !!");
                            continue;
                        }
                    }
                    else
                    {
                        Console.WriteLine("The Reservation or CancellationID is Invalid !!");
                    }

                    Console.WriteLine("Press Any Key to return to the User DashBoard.");
                    Console.ReadKey();
                    Console.Clear();
                }
                else if (ans == 5)
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
