using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using context = System.Web.HttpContext;


namespace EB_Prj
{
    public static class DBHandler
    {
        private static SqlConnection con;
        private static SqlDataReader dr;
        private static SqlCommand cmd;
        private static string exurl;

        private static SqlConnection getConnection()
        {
            con = new SqlConnection(@"Data Source = ICS-LT-6ZWKQ73\SQLEXPRESS; Initial Catalog = ElectricityBillDB; user id = sa; password = Developer@123");
            con.Open();

            return con;
        }

        public static string validateUser(string mail, string pass)
        {
            string ans = null;
            try
            {
                getConnection();

                cmd = new SqlCommand("select AdminName from admin where Email = @mail and Password = @pass", con);
                cmd.Parameters.AddWithValue("@mail", mail);
                cmd.Parameters.AddWithValue("@pass", pass);

                dr = cmd.ExecuteReader();

                if(dr.HasRows && dr.Read())
                {
                    ans = dr["AdminName"].ToString();
                }

                return ans;

            }
            catch(SqlException es)
            {
                LogExceptiontoDB(es);
                return null;
            }
        }

        public static double calculateBill(int units)
        {
            double bill = 0;

            if (units <= 100)
            {
                bill = 0;
            }
            else if (units <= 300)
            {
                bill = (units - 100) * 1.5;
            }
            else if (units <= 600)
            {
                bill = (200 * 1.5) + (units - 300) * 3.5;
            }
            else if (units <= 1000)
            {
                bill = (200 * 1.5) + (300 * 3.5) + (units - 600) * 5.5;
            }
            else
            {
                bill = (200 * 1.5) + (300 * 3.5) + (400 * 5.5) + (units - 1000) * 7.5;
            }

            return bill;
        }

        public static bool saveBill(string no, string name, int units, double amount)
        {
            bool ans = false;

            try
            {
                con = getConnection();

                cmd = new SqlCommand("insert into customer (Customer_number, Customer_name, Units_consumed, Bill_amount) values(@no, @name, @units, @amount)", con);
                cmd.Parameters.AddWithValue("@no", no);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@units", units);
                cmd.Parameters.AddWithValue("@amount", amount);


                int count = cmd.ExecuteNonQuery();

                ans = count > 0;
            }
            catch(SqlException es)
            {
                LogExceptiontoDB(es);
                ans = false; 
            }

            return ans;
        }

        public static (int bill, int unit, int amt) statistics()
        {
            int bill = 0, unit = 0, amt = 0;
            try
            {
                con = getConnection();

                cmd = new SqlCommand("select count(*), sum(units_consumed), sum(Bill_amount) from customer", con);

                dr = cmd.ExecuteReader();

                if(dr.HasRows && dr.Read())
                {
                    bill = Convert.ToInt32(dr[0]);
                    unit = Convert.ToInt32(dr[1]);
                    amt = Convert.ToInt32(dr[2]);
                }

                return (bill, unit, amt);
            }
            catch (SqlException es)
            {
                LogExceptiontoDB(es);
                return (0, 0, 0);
            }

        }

        public static void LogExceptiontoDB(Exception exdb)
        {
            getConnection();
            exurl = context.Current.Request.Url.ToString();
            SqlCommand cmd = new SqlCommand("sp_ExceptionLogging_DB", con);
            cmd.CommandType = CommandType.StoredProcedure;

            //add parameters 
            cmd.Parameters.AddWithValue("@exceptionmsg", exdb.Message.ToString());
            cmd.Parameters.AddWithValue("@exceptiontype", exdb.GetType().Name.ToString());
            cmd.Parameters.AddWithValue("@exceptionsource", exdb.StackTrace.ToString());
            cmd.Parameters.AddWithValue("@exceptionurl", exurl);

            cmd.ExecuteNonQuery();
        }

    }
}