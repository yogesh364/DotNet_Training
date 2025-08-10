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

        public static int adminID { get; set; }
        public static string adminName { get; set; }

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

                if(UserID <= 0)
                {
                    Console.WriteLine("Login Failed, Could not fetch UserID !");
                    return;
                }

                Console.WriteLine($"Login Successful ! Welcome {UserName}");
                Console.WriteLine();
                Console.WriteLine("--------------------------------------------------------");
                Console.WriteLine();
                UserDashBoard();

            }
            else
            {
                Console.WriteLine("Login Failed ! Please Enter Valid UserName and Password.");
                Console.WriteLine();
                Console.WriteLine("--------------------------------------------------------");
                Console.WriteLine();
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
                    SqlDataReader sdr = DataAccess.trainDetails();
                    
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
                    date = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine();

                    SqlDataReader sdr = DataAccess.getTrainDetails(source, destination, date);

                    if (sdr.HasRows)
                    {
                        Console.WriteLine("----------------- Available Trains -----------------");
                        Console.WriteLine();
                        DataAccess.Looping(sdr);
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("No Such Trains with the given Route !!!");
                        Console.WriteLine();
                        return;
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

                    if(passengerCount > 6)
                    {
                        Console.WriteLine("Cannot Book for more than 6 Passengers !!");
                        Console.WriteLine();
                        return;
                    }else if(passengerCount < 1)
                    {
                        Console.WriteLine("Passenger Count must be atleast 1");
                        Console.WriteLine();
                        return;
                    }

                    var (availableSeats, Price) = DataAccess.getAvailability(trainID, date, seatClass);
                    pricePerSeat = Price;

                    if(availableSeats == -1 || Price == -1)
                    {
                        Console.WriteLine("No Seat Data for the Selected Train and CLass");
                        Console.WriteLine();
                        return;
                    }

                    if (availableSeats >= passengerCount)
                    {
                        Console.WriteLine("The Seats are Available for the given Passenger Count.");
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("The Seat Availability for the given Passenger Count is Not Available, Your Booking will be in waiting list !!!");
                        Console.Write("Confirm to Proceed [y/n] : ");
                        string confirm = Console.ReadLine();
                        Console.WriteLine();

                        if (!(confirm.ToLower() == "y"))
                        {
                            Console.WriteLine("Booking Cancelled by User.");
                            Console.WriteLine();
                            return;
                        }
                        Console.WriteLine();
                    }

                    double totalAmount = Price * passengerCount;
                    Console.WriteLine($"Total Fare : {totalAmount}");
                    Console.WriteLine();

                    Console.Write("Confirm Booking [y/n] : ");
                    string ConfirmBooking = Console.ReadLine();
                    Console.WriteLine();

                    if(!(ConfirmBooking.ToLower()== "y"))
                    {
                        Console.WriteLine("Booking Cancelled by User.");
                        Console.WriteLine();
                        return;
                    }

                    int res = DataAccess.createReservation(UserID, trainID, date, seatClass, passengerCount);

                    if (res > 8000)
                    {
                        Console.WriteLine("Reservation Confirmed. Enter Passenger Details : ");
                        Console.WriteLine();

                        for(int i = 0; i < passengerCount; i++)
                        {
                            Console.WriteLine($"Enter Details of Passenger {i+1} : ");
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
                        Console.WriteLine($"Booking Completed Successfully !!! \n Your Reservation Id : {res}");
                        Console.WriteLine();
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
                        Console.WriteLine($"Booking Added to WaitingList Successfully !!! \n Your WaitingId : {res}");
                        Console.WriteLine();
                    }

                    Console.WriteLine("Press Any Key to return to the User DashBoard.");
                    Console.WriteLine();
                    Console.ReadKey();
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

                    if(reservationID > 8000)
                    {
                        Console.Write("Enter Cancellation Type [F -> Full / P -> Partial] : ");
                        string cancelType = Console.ReadLine();
                        Console.WriteLine();

                        var details = DataAccess.Reservation_Details(reservationID);
                        
                        if (cancelType.ToLower() == "f")
                        {
                            double refund = DataAccess.calculateRefund(details.Price, details.totalSeats, details.travelDate);

                            Console.Write($"Refund Amount : {refund}");
                            Console.WriteLine();

                            Console.Write("Confirm Cancellation [y/n] : ");
                            string choice = Console.ReadLine();
                            Console.WriteLine();

                            if(choice.ToLower() == "y")
                            {
                                DataAccess.cancellation(reservationID,null, refund);
                                Console.WriteLine("Cancellation Successful !!!");
                                DataAccess.tranferWaiting(details.trainID, details.travelDate, details.Class);
                                Console.WriteLine();
                            }
                            else
                            {
                                Console.WriteLine("Cancellation Aborted !!");
                                Console.WriteLine();
                                return;
                            }
                        }
                        else if(cancelType.ToLower() == "p")
                        {
                            Console.Write("Enter the Number of Passengers to Cancel : ");
                            int num = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine();

                            for(int i = 0; i < num; i++)
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
                                if(res.ToLower() == "y")
                                {
                                    DataAccess.cancellation(reservationID, passengerID, refund);
                                    Console.WriteLine();
                                }
                                else
                                {
                                    Console.WriteLine("Cancellation Aborted !!");
                                    Console.WriteLine();
                                    return;
                                }
                            }

                            Console.WriteLine("Partial Cancellation Completed !!!");
                            Console.WriteLine();
                            DataAccess.tranferWaiting(details.trainID, details.travelDate, details.Class);
                        }
                    }
                    else if(reservationID < 8000)
                    {
                        Console.WriteLine("This is Waiting List Booking. Only Full Cancellation Allowed.");

                        var details = DataAccess.Reservation_Details(reservationID);

                        double refund = DataAccess.calculateRefund(details.Price, details.totalSeats, details.travelDate);

                        Console.Write($"Refund Amount : {refund}");
                        Console.WriteLine();

                        Console.Write("Confirm Cancellation [y/n] : ");
                        string choice = Console.ReadLine();

                        if (choice.ToLower() == "y")
                        {
                            DataAccess.WaitingCancellation(reservationID, refund);
                            Console.WriteLine("Cancellation Successful !!!");
                            DataAccess.tranferWaiting(details.trainID, details.travelDate, details.Class);
                        }
                        else
                        {
                            Console.WriteLine("Cancellation Aborted !!");
                            return;
                        }
                    }
                }
                else if (ans == 5)
                {
                    return;
                }
            }
        }

        public void adminLogin()
        {
            Console.WriteLine("------------ Admin Login ------------");
            Console.WriteLine();

            Console.Write("Enter Your AdminName : ");
            adminName = Console.ReadLine();

            Console.Write("Enter Your Password : ");
            Password = Console.ReadLine();
            Console.WriteLine();

            if (DataAccess.adminLoginCheck(adminName, Password))
            {
                adminID= DataAccess.adminLogin(adminName, Password);

                if (adminID <= 0)
                {
                    Console.WriteLine("Login Failed, Could not fetch UserID !");
                    return;
                }

                Console.WriteLine($"Login Successful ! Welcome {adminName}");
                Console.WriteLine();
                Console.WriteLine("--------------------------------------------------------");
                Console.WriteLine();
                AdminDashBoard();

            }
            else
            {
                Console.WriteLine("Login Failed ! Please Enter Valid UserName and Password.");
                Console.WriteLine();
                Console.WriteLine("--------------------------------------------------------");
                Console.WriteLine();
            }
        }

        public void AdminDashBoard()
        {
            while (true)
            {
                Console.WriteLine("------------------- Admin DashBoard -------------------");
                Console.WriteLine("1. Train Details");
                Console.WriteLine("2. Add a train");
                Console.WriteLine("3. View Reservation Details ");
                Console.WriteLine("4. View WaitingList Details ");
                Console.WriteLine("5. View Cancellation Details ");
                Console.WriteLine("6. Exit to Main Menu");
                Console.WriteLine();

                Console.Write("Enter Your Choice : ");
                int ans = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                if(ans ==1)
                {
                    SqlDataReader sdr = DataAccess.trainDetails();

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
                    Console.WriteLine("-------------- Enter Train Details --------------");

                    Console.Write("Enter the Train ID : ");
                    int trainID = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter the Train Name : ");
                    string trainName = Console.ReadLine();

                    Console.Write("Enter the Source : ");
                    string source = Console.ReadLine();

                    Console.Write("Enter the Destination : ");
                    string destination = Console.ReadLine();

                    Console.Write("Enter the Departure Date [yyyy-mm-dd] : ");
                    DateTime date = DateTime.Parse(Console.ReadLine());

                    Console.Write("Enter the Departure Time (hh:mm): ");
                    string Time = Console.ReadLine();

                    bool success = DataAccess.addTrain(trainID, trainName, source, destination, date, Time);

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

                    Console.WriteLine("Press Any Key to Return to User DashBoard !!");
                    Console.WriteLine();
                    Console.ReadKey();
                }
                else if (ans == 3)
                {
                    SqlDataReader sdr = DataAccess.get_reservation();

                    if (sdr.HasRows)
                    {
                        Console.WriteLine("-------------- Reservation Details --------------");
                        Console.WriteLine();

                        DataAccess.heading("Reservation ID");

                        while (sdr.Read())
                        {
                            DataAccess.printDetails("Reservation ID");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Reservation Details Available at the moment !!!");
                    }
                    Console.WriteLine("Press Any Key to Return to User DashBoard !!");
                    Console.WriteLine();
                    Console.ReadKey();
                }
                else if (ans == 4)
                {
                    SqlDataReader sdr = DataAccess.get_waiting();

                    if (sdr.HasRows)
                    {
                        Console.WriteLine("-------------- WaitingList Details --------------");
                        Console.WriteLine();

                        DataAccess.heading("Waiting ID");

                        while (sdr.Read())
                        {
                            DataAccess.printDetails("Waiting ID");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Waiting List Details  Available at the moment !!!");
                    }
                    Console.WriteLine("Press Any Key to Return to User DashBoard !!");
                    Console.WriteLine();
                    Console.ReadKey();
                }
                else if (ans == 5)
                {
                    SqlDataReader sdr = DataAccess.get_cancellation();

                    if (sdr.HasRows)
                    {
                        Console.WriteLine("-------------- WaitingList Details --------------");
                        Console.WriteLine();

                        DataAccess.printCancel(sdr);
                    }
                    else
                    {
                        Console.WriteLine("No Waiting List Details  Available at the moment !!!");
                    }
                    Console.WriteLine("Press Any Key to Return to User DashBoard !!");
                    Console.WriteLine();
                    Console.ReadKey();
                }
                else
                {
                    return;
                }
            }
        }

    }
    class DataAccess
    {
        private static SqlConnection con;
        private static SqlDataReader dr;
        private static SqlCommand cmd;

        private static SqlConnection getConnection()
        {
            con = new SqlConnection(@"Data Source = ICS-LT-6ZWKQ73\SQLEXPRESS; Initial Catalog = RailwayDB;
            user id = sa; password = Developer@123");
            con.Open();

            return con;
        }

        public static int insertUserDetails(string name, string pass, long phone, string mail)
        {
            try
            {
                con = getConnection();

                cmd = new SqlCommand("insert into users(UserName, Password, Phone, Email)" +
                                     " values(@uname, @upass, @uphone, @umail)", con);
                cmd.Parameters.AddWithValue("@uname", name);
                cmd.Parameters.AddWithValue("@upass", pass);
                cmd.Parameters.AddWithValue("@uphone", phone);
                cmd.Parameters.AddWithValue("@umail", mail);

                return cmd.ExecuteNonQuery();
            }
            catch (SqlException es)
            {
                Console.WriteLine(es.Message);
                return -1;
            }
           
        }

        public static bool UserLoginCheck(string name, string password)
        {
            bool result = false;

            try
            {
                con = getConnection();

                cmd = new SqlCommand("select count(*) from users where UserName = @uname and Password = @pass", con);
                cmd.Parameters.AddWithValue("@uname", name);
                cmd.Parameters.AddWithValue("@pass", password);
                int count = (int)cmd.ExecuteScalar();
                result = (count > 0);
            }
            catch (SqlException es)
            {
                Console.WriteLine(es.Message);
            }
            return result;
        }

        public static bool adminLoginCheck(string name, string password)
        {
            bool result = false;

            try
            {
                con = getConnection();

                cmd = new SqlCommand("select count(*) from admin where AdminName = @aname and Password = @pass", con);
                cmd.Parameters.AddWithValue("@aname", name);
                cmd.Parameters.AddWithValue("@pass", password);

                int count = (int)cmd.ExecuteScalar();

                result = count > 0;
            }
            catch(SqlException es)
            {
                Console.WriteLine(es.Message);
               
            }
            return result;
        }

        public static int login(string name, string password)
        {
            int uid = 0;
            try
            {
                con = getConnection();

                cmd = new SqlCommand("select UserID from users where UserName = @name and Password = @pass", con);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@pass", password);

                dr = cmd.ExecuteReader();

                if (dr.HasRows && dr.Read())
                {
                    uid = Convert.ToInt32(dr["UserID"]);
                }
            }
            catch(SqlException es)
            {
                Console.WriteLine(es.Message);
            }
            return uid;
        }

        public static int adminLogin(string name, string password)
        {
            int uid = 0;
            try
            {
                con = getConnection();

                cmd = new SqlCommand("select adminID from admin where AdminName = @name and Password = @pass", con);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@pass", password);

                dr = cmd.ExecuteReader();

                if (dr.HasRows && dr.Read())
                {
                    uid = Convert.ToInt32(dr["AdminID"]);
                }
            }
            catch (SqlException es)
            {
                Console.WriteLine(es.Message);
            }
            return uid;
        }

        public static void Looping(SqlDataReader dr)
        {
            Console.WriteLine("{0,-10} | {1,-20} | {2,-15} | {3,-15} | {4,-10} | {5,-10} | {6,-10} | {7,-15} | {8,-10}", "Train ID", "Train Name", "Source", "Destination", "Date", "Time", "Class", "Available Seats", "Price");
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------");
            while (dr.Read())
            {
                Console.WriteLine("{0,-10} | {1,-20} | {2,-15} | {3,-15} | {4,-10} | {5,-10} | {6,-10} | {7,-15} | {8,-10}",
                    dr["TrainId"], dr["TrainName"], dr["Source"], dr["Destination"], Convert.ToDateTime(dr["Departure_Date"]).ToShortDateString(),
                    dr["Departure_Time"], dr["Class"], dr["AvailableSeats"], dr["Price"]);
            }
            Console.WriteLine();
        }

        public static SqlDataReader trainDetails()
        {
            try
            {
                con = getConnection();

                cmd = new SqlCommand("sp_train_detail", con);
                cmd.CommandType = CommandType.StoredProcedure;

                dr = cmd.ExecuteReader();

                return dr;

            }
            catch (SqlException es)
            {
                Console.WriteLine(es.Message);
                return null;
            }
        }

        public static SqlDataReader getTrainDetails(string source, string destination, DateTime date)
        {
            try
            {
                con = getConnection();

                cmd = new SqlCommand("sp_get_train_details", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@tsource", source);
                cmd.Parameters.AddWithValue("@tdestination", destination);
                cmd.Parameters.AddWithValue("@tdate", date);

                dr = cmd.ExecuteReader();

                return dr;

            }
            catch(SqlException es)
            {
                Console.WriteLine(es.Message);
                return null;
            }
        }

        public static (int availableSeats, double price) getAvailability(int trainID, DateTime date, String Class)
        {
            try
            {
                con = getConnection();

                cmd = new SqlCommand("select AvailableSeats, Price from seats where (TrainID = @id and TravelDate = @dt and Class = @class)", con);
                cmd.Parameters.AddWithValue("@id", trainID);
                cmd.Parameters.AddWithValue("@dt", date);
                cmd.Parameters.AddWithValue("@class", Class);

                dr = cmd.ExecuteReader();

                if (dr.HasRows && dr.Read())
                {
                    return (Convert.ToInt32(dr["AvailableSeats"]), Convert.ToDouble(dr["Price"]));
                }
            }
            catch(SqlException es)
            {
                Console.WriteLine(es.Message);
            }
            return (-1, -1);
        }

        public static int createReservation(int userID, int trainID, DateTime date, string Class, int seatCount)
        {
            try
            {
                var (availableSeats, price) = getAvailability(trainID, date, Class);

                double tot = price * seatCount;

                if (availableSeats >= seatCount)
                {
                    con = getConnection();

                    cmd = new SqlCommand("insert into Reservation(UserID, TrainID, TravelDate, Class, SeatNo, Status, TotalPrice)" +
                                            "values(@uid, @tid, @date, @class, @seat, 'CONFIRMED', @price);" +
                                            "select SCOPE_IDENTITY()", con);
                    cmd.Parameters.AddWithValue("@uid", userID);
                    cmd.Parameters.AddWithValue("@tid", trainID);
                    cmd.Parameters.AddWithValue("@date", date);
                    cmd.Parameters.AddWithValue("@class", Class);
                    cmd.Parameters.AddWithValue("@seat", seatCount);
                    cmd.Parameters.AddWithValue("@price", price);

                    object identity = cmd.ExecuteScalar();
                    int reservationID = (identity != null && identity != DBNull.Value) ? Convert.ToInt32(identity) : -1;
                    con.Close();

                   if(reservationID > 0)
                    {
                        con.Open();
                        SqlCommand cmd1 = new SqlCommand("update seats set AvailableSeats = AvailableSeats - @seats" +
                                                        " where (TrainID = @tid and TravelDate = @date and Class = @cls)", con);
                        cmd1.Parameters.AddWithValue("@tid", trainID);
                        cmd1.Parameters.AddWithValue("@date", date);
                        cmd1.Parameters.AddWithValue("@cls", Class);
                        cmd1.Parameters.AddWithValue("@seats", seatCount);


                        cmd1.ExecuteNonQuery();
                    }

                    return reservationID;
                }
                else
                {
                    con = getConnection();

                    cmd = new SqlCommand("insert into WaitingList(UserID, TrainID, TravelDate, Class, SeatNo, TotalPrice)" +
                                           "values(@uid, @tid, @date, @class, @seat, @price);" +
                                           "select SCOPE_IDENTITY()", con);
                    cmd.Parameters.AddWithValue("@uid", userID);
                    cmd.Parameters.AddWithValue("@tid", trainID);
                    cmd.Parameters.AddWithValue("@date", date);
                    cmd.Parameters.AddWithValue("@class", Class);
                    cmd.Parameters.AddWithValue("@seat", seatCount);
                    cmd.Parameters.AddWithValue("@price", price);

                    object identity = cmd.ExecuteScalar();
                    int waitingID = (identity != null && identity != DBNull.Value) ? Convert.ToInt32(identity) : -1;

                    return waitingID;
                }
            }
            catch(SqlException es)
            {
                Console.WriteLine("An Error Occured While Creating the Reservation : "+es.Message);
                return -1;
            }
        }

        public static int insertPassenger(int? reservationID,int? waitingID, string name, int age, string gender, string phone)
        {
            try
            {
                con = getConnection();

                cmd = new SqlCommand("insert into Passengers (ReservationID, waitingID, Name, Age, Gender, Mobile,status)" +
                                        " values (@rid, @wid, @name, @age, @gender, @phone, @status);" +
                                        "select SCOPE_IDENTITY()", con);

                string passengerStatus = "UNKNOWN";

                if (reservationID.HasValue)
                {
                    cmd.Parameters.AddWithValue("@rid", reservationID);
                    passengerStatus = "CONFIRMED";
                }
                else
                {
                    cmd.Parameters.AddWithValue("@rid", DBNull.Value);
                }

                if (waitingID.HasValue)
                {
                    cmd.Parameters.AddWithValue("@wid", waitingID);
                    passengerStatus = "WAITING";
                }
                else
                {
                    cmd.Parameters.AddWithValue("@wid", DBNull.Value);
                }

                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@age", age);
                cmd.Parameters.AddWithValue("@gender", gender);
                cmd.Parameters.AddWithValue("@phone", phone);
                cmd.Parameters.AddWithValue("@status", passengerStatus);

                object identity = cmd.ExecuteScalar();

                int passengerID = (identity != null && DBNull.Value != null) ? Convert.ToInt32(identity) : -1;

                return passengerID;

            }
            catch(SqlException es)
            {
                Console.WriteLine(es.Message);
                return -1;
            }
        }

        public static void viewReservation(int userID)
        {
            con = getConnection();

            cmd = new SqlCommand("sp_view_reseration", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@uid", userID);

            dr = cmd.ExecuteReader();

            bool confirmed = false;

            if (dr.HasRows)
            {
                Console.WriteLine("------------- Confirmed Reservations -------------");
                Console.WriteLine();
                heading("ReservationID");

                while (dr.Read())
                {
                    confirmed = true;
                    printDetails("ReservationID");
                }
            }

            if(dr.NextResult() && dr.HasRows)
            {
                Console.WriteLine("------------- Waiting List -------------");
                Console.WriteLine();
                heading("WaitingID");

                while (dr.Read())
                {
                    printDetails("WaitingID");
                }
            }
            else if (!confirmed)
            {
                Console.WriteLine("No Confirmed or Waiting Reservations found");
            }
            
        }

        public static void heading(string str)
        {
            Console.WriteLine("{0,-12} | {1,-14} | {2,-8} | {3,-10} | {4,-10} | {5,-8} | {6,-8} | {7,-20} | {8,-20} | {9,-12} | {10,-8} | {11,-8} | {12,-8} | {13,-12} | {14,-20}",
                    str, "Train Name", "Source", "Destination", "Travel Date", "Class", "Seat Count", "Status", "Booking Date", "PassengerID", "Name", "Age", "Gender", "Mobile", "Passenger Status");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
        }

        public static void printDetails(string str)
        {
            Console.WriteLine("{0,-13} | {1,-14} | {2,-8} | {3,-12} | {4,-10} | {5,-8} | {6,-10} | {7,-20} | {8,-20} | {9,-12} | {10,-8} | {11,-8} | {12,-8} | {13,-12} | {14,-20}",
                            dr[str], dr["TrainName"], dr["Source"], dr["Destination"], Convert.ToDateTime(dr["TravelDate"]).ToShortDateString(), dr["Class"], dr["SeatNo"], dr["status"], dr["BookingTime"], dr["PassengerID"], dr["Name"], dr["Age"], dr["Gender"], dr["mobile"], dr["Passenger Status"]);
            Console.WriteLine();
        }

        public static double calculateRefund(double price, int totSeats, DateTime travelDate)
        {
            double percent = 0;

            DateTime today = DateTime.Now;

            TimeSpan daysDiff = travelDate - today;

            if(daysDiff.TotalDays < 7)
            {
                percent = 0.25;
            }
            else if(daysDiff.TotalDays < 14)
            {
                percent = 0.50;
            }
            else if(daysDiff.TotalDays < 21)
            {
                percent = 0.75;
            }
            else
            {
                percent = 1;
            }

            return price * totSeats * percent;
        }

        public static (DateTime travelDate, string Class, double Price, int totalSeats, int trainID) Reservation_Details(int reservationID)
        {
            try
            {
                con = getConnection();

                cmd = new SqlCommand("sp_Reservation_Details", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@rid", reservationID);

                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    DateTime travelDate = dr.GetDateTime(0);
                    string Class = dr.GetString(1);
                    int totalSeats = Convert.ToInt32(dr[2]);
                    double price = dr.GetDouble(3);
                    int trainID = dr.GetInt32(4);

                    return (travelDate, Class, price, totalSeats, trainID);
                }
               
            }
            catch(SqlException es)
            {
                Console.WriteLine(es.Message);
                
            }
            return (DateTime.MinValue, null, 0, 0, 0);
        }

        public static void cancellation(int reservationID, int? passengerID, double refund)
        {
            try
            {
                con = getConnection();

                cmd = new SqlCommand("sp_cancel_reservation", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@rid", reservationID);
                cmd.Parameters.AddWithValue("@refund", refund);

                if (passengerID.HasValue)
                {
                    cmd.Parameters.AddWithValue("@pid", passengerID);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@pid", DBNull.Value);
                }

                cmd.ExecuteNonQuery();
            }
            catch(SqlException es)
            {
                Console.WriteLine(es.Message);
            }
        }

        public static void WaitingCancellation(int waitingId, double refund)
        {
            try
            {
                con = getConnection();

                cmd = new SqlCommand("sp_cancel_waiting", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@wid", waitingId);
                cmd.Parameters.AddWithValue("@refund", refund);

                cmd.ExecuteNonQuery();
            }
            catch(SqlException es)
            {
                Console.WriteLine(es.Message);
            }
        }

        public static void tranferWaiting(int trainID, DateTime travelDate, string Class)
        {
            try
            {
                con = getConnection();

                cmd = new SqlCommand("sp_tranfer_to_reservation", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@trainID", trainID);
                cmd.Parameters.AddWithValue("@travelDate", travelDate);
                cmd.Parameters.AddWithValue("@class", Class);

                cmd.ExecuteNonQuery();

            }
            catch(SqlException es)
            {
                Console.WriteLine(es.Message);
            }
        }

        public static bool addTrain(int trainID, string trainName, string source, string destination, DateTime date, string time)
        {
            bool result = false;
            try
            {
                con = getConnection();

                cmd = new SqlCommand("sp_insert_train", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@trainID", trainID);
                cmd.Parameters.AddWithValue("@trainName", trainName);
                cmd.Parameters.AddWithValue("@source", source);
                cmd.Parameters.AddWithValue("@destination", destination);
                cmd.Parameters.AddWithValue("@dep_date", date);
                cmd.Parameters.AddWithValue("@dep_time", time);

                int ans = cmd.ExecuteNonQuery();

                result = ans > 0;
            }
            catch(SqlException es)
            {
                Console.WriteLine(es.Message);
            }
            return result;
        }

        public static SqlDataReader get_reservation()
        {
            try
            {
                con = getConnection();

                cmd = new SqlCommand("sp_get_reservation_details", con);
                cmd.CommandType = CommandType.StoredProcedure;

                dr = cmd.ExecuteReader();

                return dr;
            }
            catch(SqlException es)
            {
                Console.WriteLine(es.Message);
                return null;
            }
        }

        public static SqlDataReader get_waiting()
        {
            try
            {
                con = getConnection();

                cmd = new SqlCommand("sp_get_waiting_details", con);
                cmd.CommandType = CommandType.StoredProcedure;

                dr = cmd.ExecuteReader();

                return dr;
            }
            catch (SqlException es)
            {
                Console.WriteLine(es.Message);
                return null;
            }
        }

        public static SqlDataReader get_cancellation()
        {
            try
            {
                con = getConnection();

                cmd = new SqlCommand("Select * from cancellation", con);

                dr = cmd.ExecuteReader();

                return dr;
            }
            catch(SqlException es)
            {
                Console.WriteLine(es.Message);
                return null;
            }
        }

        public static void printCancel(SqlDataReader dr)
        {
            Console.WriteLine("{0,-15} | {1,-15} | {2,-15} | {3,-15} | {4,-20} | {5,-10} | {6,-12} | {7,-15} | {8,-10}",
                                "CancellationID", "ReservationID", "WaitingID", "PassengerID","Name", "TrainID", "TravelDate", "Class", "Refund");
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------------------------------------");
            while (dr.Read())
            {
                Console.WriteLine(
            "{0,-15} | {1,-15} | {2,-15} | {3,-15} | {4,-20} | {5,-10} | {6,-12:yyyy-mm-dd} | {7,-15} | {8,-10}",
            dr["CancellationID"], dr["ReservationID"], dr["WaitingID"], dr["PassengerID"],
            dr["Name"], dr["TrainID"], dr["TravelDate"], dr["Class"], dr["Refund"]);
            }

        }
    }
}
