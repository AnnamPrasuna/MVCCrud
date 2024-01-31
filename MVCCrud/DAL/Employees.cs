using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace MVCCrud.DAL
{
    public class Employees
    {
        public int AddEmployee(Models.Employees employee)
        {
            SqlConnection conn=new SqlConnection(ConfigurationManager.ConnectionStrings["p1"].ToString());
            conn.Open();
            string q1 = "insert into Employees values('"+employee.Id+"','" + employee.Name + "','" + employee.Salary + "')";
            SqlCommand command = new SqlCommand(q1, conn);
            int i = command.ExecuteNonQuery();
            conn.Close(); 
            return i;
        }
        public int DeleteEmployee(Models.Employees employee)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["p1"].ToString());
            conn.Open();
            string q1 = "delete from Employees where Id='" + employee.Id+ "'";
            SqlCommand command = new SqlCommand(q1, conn);
            int i = command.ExecuteNonQuery();
            conn.Close();
            return i;
        }
        public int UpdateEmployee(Models.Employees employee)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["p1"].ToString());
            conn.Open();
            string q1 = "update Employees set Name='" + employee.Name + "',Salary='" + employee.Salary + "' where Id='" + employee.Id + "'";
            SqlCommand command = new SqlCommand(q1, conn);
            int i = command.ExecuteNonQuery();
            conn.Close();
            return i;
        }
    }
}