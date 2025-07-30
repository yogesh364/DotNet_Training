using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ADO_CC1
{
    class businesslogic
    {
        public int id { get; set; }
        public string name { get; set; }
        public string gender { get; set; }
        public float salary { get; set; }

        DataAccess da = new DataAccess();

        public void insertEmp()
        {
            Console.Write("Enter the Employee Name : ");
            name = Console.ReadLine();

            Console.Write("Enter the Employee Gender : ");
            gender = Console.ReadLine();

            Console.Write("Enter the Employee Salary : ");
            salary = Convert.ToSingle(Console.ReadLine());

            da.stored_procedure(name, gender, salary);
        }

        public void update_salary()
        {
            Console.Write("Enter the Employee ID to Update Salary : ");
            id = Convert.ToInt32(Console.ReadLine());

            da.update_salary(id);
        }
    }

    class DataAccess
    {
        static SqlConnection con = null;
        static SqlCommand cmd = null;
        static SqlDataReader dr;

        public static SqlConnection GetConnection()
        {
            string connect = @"Data Source = ICS-LT-6ZWKQ73\SQLEXPRESS; initial catalog = ADO_CC_DB;
                                user id = sa; password = Developer@123";
            con = new SqlConnection(connect);
            con.Open();
            return con;
        }

        public void stored_procedure(string name, string gender, float salary)
        {
            con = GetConnection();
            cmd = new SqlCommand("sp_insert_employee", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param1 = new SqlParameter();
            param1.ParameterName = "@name";
            param1.Value = name;
            param1.DbType = DbType.String;
            param1.Direction = ParameterDirection.Input;

            SqlParameter param2 = new SqlParameter();
            param2.ParameterName = "@gender";
            param2.Value = gender;
            param2.DbType = DbType.String;
            param2.Direction = ParameterDirection.Input;

            SqlParameter param3 = new SqlParameter();
            param3.ParameterName = "@salary";
            param3.Value = salary;
            param3.DbType = DbType.Single;
            param3.Direction = ParameterDirection.Input;

            SqlParameter param4 = new SqlParameter();
            param4.ParameterName = "@netsalary";
            param4.DbType = DbType.Single;
            param4.Direction = ParameterDirection.Output;

            SqlParameter param5 = new SqlParameter();
            param5.ParameterName = "@empid";
            param5.DbType = DbType.Int32;
            param5.Direction = ParameterDirection.Output;

            cmd.Parameters.Add(param1);
            cmd.Parameters.Add(param2);
            cmd.Parameters.Add(param3);
            cmd.Parameters.Add(param4);
            cmd.Parameters.Add(param5);

            dr = cmd.ExecuteReader();

            Console.WriteLine("Last Inserted Employee Details:");
            while (dr.Read())
            {
                Console.WriteLine($"EmpID : {dr["EmpID"]}");
                Console.WriteLine($"Name : {dr["EmpName"]}");
                Console.WriteLine($"Gender : {dr["Gender"]}");
                Console.WriteLine($"Salary : {dr["Salary"]}");
                Console.WriteLine($"Net Salary : {dr["NetSalary"]}");
            }
            dr.Close();

            int eid = (int)cmd.Parameters["@empid"].Value;
            float enetsalary = (float)cmd.Parameters["@netsalary"].Value;

            Console.WriteLine();
            Console.WriteLine("Ouput Values: ");
            Console.WriteLine("Employee Id : "+ eid);
            Console.WriteLine("Employee Net Salary : "+enetsalary);

            con.Close();
        } 

        public void update_salary(int eid)
        {
            con = GetConnection();
            cmd = new SqlCommand("sp_update_salary", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param1 = new SqlParameter();
            param1.ParameterName = "@empid";
            param1.Value = eid;
            param1.DbType = DbType.Int32;
            param1.Direction = ParameterDirection.Input;

            SqlParameter param2 = new SqlParameter();
            param2.ParameterName = "@salary";
            param2.DbType = DbType.Single;
            param2.Direction = ParameterDirection.Output;

            SqlParameter param3 = new SqlParameter();
            param3.ParameterName = "@netsalary";
            param3.DbType = DbType.Single;
            param3.Direction = ParameterDirection.Output;

            cmd.Parameters.Add(param1);
            cmd.Parameters.Add(param2);
            cmd.Parameters.Add(param3);

            dr = cmd.ExecuteReader();

            Console.WriteLine("Last updated Employee Details:");
            while (dr.Read())
            {
                Console.WriteLine($"EmpID : {dr["EmpID"]}");
                Console.WriteLine($"Name : {dr["EmpName"]}");
                Console.WriteLine($"Gender : {dr["Gender"]}");
                Console.WriteLine($"Salary : {dr["Salary"]}");
                Console.WriteLine($"Net Salary : {dr["NetSalary"]}");
            }
            dr.Close();


            float sal = (float)cmd.Parameters["@salary"].Value;
            float netsal = (float)cmd.Parameters["@netsalary"].Value;

            Console.WriteLine();
            Console.WriteLine("Output Values...");
            Console.WriteLine("Updated Salary : " + sal);
            Console.WriteLine("Updated NetSalary : "+netsal);
            con.Close();

        }
    }
}
