using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Railway_Project
{

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
            catch (SqlException es)
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
            Console.WriteLine("{0,-10} | {1,-20} | {2,-15} | {3,-15} | {4,-10} | {5,-10} | {6,-15} | {7,-10}", "Train ID", "Train Name", "Source", "Destination", "Time", "Class", "Available Seats", "Price");
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------");
            while (dr.Read())
            {
                Console.WriteLine("{0,-10} | {1,-20} | {2,-15} | {3,-15} | {4,-10} | {5,-10} | {6,-15} | {7,-10}",
                    dr["TrainId"], dr["TrainName"], dr["Source"], dr["Destination"],
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

        public static SqlDataReader getTrainDetails(string source, string destination)
        {
            try
            {
                con = getConnection();

                cmd = new SqlCommand("sp_get_train_details", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@tsource", source);
                cmd.Parameters.AddWithValue("@tdestination", destination);

                dr = cmd.ExecuteReader();

                return dr;

            }
            catch (SqlException es)
            {
                Console.WriteLine(es.Message);
                return null;
            }
        }

        public static (int availableSeats, double price) getAvailability(int trainID, String Class)
        {
            try
            {
                con = getConnection();

                cmd = new SqlCommand("select AvailableSeats, Price from seats where (TrainID = @id and Class = @class)", con);
                cmd.Parameters.AddWithValue("@id", trainID);
                cmd.Parameters.AddWithValue("@class", Class);

                dr = cmd.ExecuteReader();

                if (dr.HasRows && dr.Read())
                {
                    return (Convert.ToInt32(dr["AvailableSeats"]), Convert.ToDouble(dr["Price"]));
                }
            }
            catch (SqlException es)
            {
                Console.WriteLine(es.Message);
            }
            return (-1, -1);
        }

        public static int createReservation(int userID, int trainID, DateTime date, string Class, int seatCount)
        {
            try
            {
                var (availableSeats, price) = getAvailability(trainID, Class);

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

                    if (reservationID > 0)
                    {
                        con.Open();
                        SqlCommand cmd1 = new SqlCommand("update seats set AvailableSeats = AvailableSeats - @seats" +
                                                        " where (TrainID = @tid and Class = @cls)", con);
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
            catch (SqlException es)
            {
                Console.WriteLine("An Error Occured While Creating the Reservation : " + es.Message);
                return -1;
            }
        }

        public static int insertPassenger(int? reservationID, int? waitingID, string name, int age, string gender, string phone)
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
            catch (SqlException es)
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

            if (dr.NextResult() && dr.HasRows)
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
                Console.WriteLine("No Confirmed or Waiting Reservations found !");
                Console.WriteLine();
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

            if (daysDiff.TotalDays < 7)
            {
                percent = 0.25;
            }
            else if (daysDiff.TotalDays < 14)
            {
                percent = 0.50;
            }
            else if (daysDiff.TotalDays < 21)
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
            catch (SqlException es)
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
            catch (SqlException es)
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
            catch (SqlException es)
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
            catch (SqlException es)
            {
                Console.WriteLine(es.Message);
            }
        }

    }
}
