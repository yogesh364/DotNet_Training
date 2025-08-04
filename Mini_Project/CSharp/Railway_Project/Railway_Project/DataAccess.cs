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
        public static string UserName { get; set; }
        public static string Password { get; set; }
        public static long phone { get; set; }
        public static string email { get; set; }

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
                Console.WriteLine("3. View Reservation");
                Console.WriteLine("4. View My Bookings");
                Console.WriteLine("5. Cancel a Ticket");
                Console.WriteLine("6. Exit to Main Menu");
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

                }
                else if (ans == 3) { }
                else if (ans == 4) { }
                else if (ans == 5) { }
                else if (ans == 6) { }


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
            }
            return cmd.ExecuteNonQuery();
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

                cmd = new SqlCommand("sp_train_details", con);
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

        
    }
}
