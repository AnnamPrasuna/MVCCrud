using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MvcCrudUsingStoredProcedures.DAL
{
    
    public class Employees
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["p1"].ToString());
        public int AddEmployee(Models.Employees e1)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("proc_AddEmp", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id", e1.Id);
            command.Parameters.AddWithValue("@name", e1.Name);
            command.Parameters.AddWithValue("@salary", e1.Salary);
            int i1=command.ExecuteNonQuery();
            connection.Close();
            return i1;
        }
        public int DeleteEmployee(Models.Employees e1)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("proc_DeleteEmp", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id", e1.Id);
            int i1 = command.ExecuteNonQuery();
            connection.Close();
            return i1;
        }
        public int UpdateEmployee(Models.Employees e1)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("proc_UpdateEmp", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id", e1.Id);
            command.Parameters.AddWithValue("@name", e1.Name);
            command.Parameters.AddWithValue("@salary", e1.Salary);
            int i1 = command.ExecuteNonQuery();
            connection.Close();
            return i1;
        }
        public List<Models.Employees> GetEmployee()
        {
            List<Models.Employees> list = new List<Models.Employees>();
            connection.Open();
            SqlCommand command = new SqlCommand("proc_GetEmp", connection);
            SqlDataReader sqlDataReader = command.ExecuteReader();
            if(sqlDataReader.HasRows)
            {
                while(sqlDataReader.Read())
                {
                    Models.Employees emp=new Models.Employees();
                    /*emp.Id=int.Parse(sqlDataReader.GetString(0));*/
                    emp.Id = sqlDataReader.GetInt32(0);

                    emp.Name= sqlDataReader.GetString(1);
                    emp.Salary = sqlDataReader.GetInt32(2);

                    list.Add(emp);
                }
            }
            connection.Close();
            return list;
        }
        public Models.Employees SearchEmployees(Models.Employees e1)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("proc_SearchEmp", connection);
            command.CommandType= CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id", e1.Id);
            SqlDataReader reader= command.ExecuteReader();
            if(reader.HasRows)
            {
                if(reader.Read())
                {
                    e1.Name = reader[0].ToString();
                    e1.Salary= int.Parse(reader[1].ToString());
                }
            }
            connection.Close();
            return e1;

        }
    }
}