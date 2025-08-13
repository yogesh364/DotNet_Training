using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Railway_Project
{
    public class DataAccessAdmin
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
            catch (SqlException es)
            {
                Console.WriteLine(es.Message);

            }
            return result;
        }

        public static SqlDataReader trainDetails()
        {
            try
            {
                con = getConnection();

                cmd = new SqlCommand("sp_train_detail_admin", con);
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

        public static bool addTrain(int trainID, string trainName, string source, string destination, string time)
        {
            bool result = false;
            try
            {
                con = getConnection();

                SqlCommand cmd1 = new SqlCommand("SELECT COUNT(*) FROM Trains WHERE trainID = @trainID", con);
                cmd1.Parameters.AddWithValue("@trainID", trainID);

                int count = (int)cmd1.ExecuteScalar();
                if (count > 0)
                {
                    Console.WriteLine("Train ID already exists.");
                    Console.WriteLine();
                    return false;
                }

                con.Close();

                con.Open();
                cmd = new SqlCommand("sp_insert_train", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@trainID", trainID);
                cmd.Parameters.AddWithValue("@trainName", trainName);
                cmd.Parameters.AddWithValue("@source", source);
                cmd.Parameters.AddWithValue("@destination", destination);
                cmd.Parameters.AddWithValue("@dep_time", time);


                int ans = cmd.ExecuteNonQuery();

                result = ans > 0;
            }
            catch (SqlException es)
            {
                Console.WriteLine(es.Message);
            }
            return result;
        }

        public static SqlDataReader get_reservation(DateTime d1, DateTime d2)
        {
            try
            {
                con = getConnection();

                cmd = new SqlCommand("sp_get_reservation_details", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@start", d1);
                cmd.Parameters.AddWithValue("@end", d2);

                dr = cmd.ExecuteReader();

                return dr;
            }
            catch (SqlException es)
            {
                Console.WriteLine(es.Message);
                return null;
            }
        }

        public static SqlDataReader get_waiting(DateTime d1, DateTime d2)
        {
            try
            {
                con = getConnection();

                cmd = new SqlCommand("sp_get_waiting_details", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@start", d1);
                cmd.Parameters.AddWithValue("@end", d2);

                dr = cmd.ExecuteReader();

                return dr;
            }
            catch (SqlException es)
            {
                Console.WriteLine(es.Message);
                return null;
            }
        }

        public static SqlDataReader get_cancellation(DateTime d1, DateTime d2)
        {
            try
            {
                con = getConnection();

                cmd = new SqlCommand("sp_get_cancel_details", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@start", d1);
                cmd.Parameters.AddWithValue("@end", d2);

                dr = cmd.ExecuteReader();

                return dr;
            }
            catch (SqlException es)
            {
                Console.WriteLine(es.Message);
                return null;
            }
        }

        public static void printCancel(SqlDataReader dr)
        {
            Console.WriteLine("{0,-15} | {1,-15} | {2,-15} | {3,-20} | {4,-15} | {5,-15} | {6,-12} | {7,-15} | {8,-10} | {9,-20} | {10, -10} | {11,-10} | {12,-15} | {13, -20}",
                                "CancellationID", "ReservationID", "WaitingID", "Train Name", "Source", "Destination", "TravelDate", "Class", "Passenger ID", "Passenger Name", "Age", "Gender", "Phone No", "Passenger Status");
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            while (dr.Read())
            {
                Console.WriteLine(
            "{0,-15} | {1,-15} | {2,-15} | {3,-20} | {4,-15} | {5,-15} | {6,-12:yyyy-mm-dd} | {7,-15} | {8,-10} | {9,-20} | {10,-10} | {11,-10} | {12,-15} | {13, -20}",
            dr["CancellationID"], dr["ReservationID"], dr["WaitingID"], dr["TrainName"],
            dr["Source"], dr["Destination"], dr["TravelDate"], dr["Class"], dr["PassengerID"], dr["Name"], dr["Age"], dr["Gender"], dr["Mobile"], dr["Passenger Status"]);
            }

        }

        public static void printDetails(string str)
        {
            Console.WriteLine("{0,-13} | {1,-14} | {2,-8} | {3,-12} | {4,-10} | {5,-8} | {6,-10} | {7,-20} | {8,-20} | {9,-12} | {10,-8} | {11,-8} | {12,-8} | {13,-12} | {14,-20}",
                            dr[str], dr["TrainName"], dr["Source"], dr["Destination"], Convert.ToDateTime(dr["TravelDate"]).ToShortDateString(), dr["Class"], dr["SeatNo"], dr["status"], dr["BookingTime"], dr["PassengerID"], dr["Name"], dr["Age"], dr["Gender"], dr["mobile"], dr["Passenger Status"]);
            Console.WriteLine();
        }
    }
}
