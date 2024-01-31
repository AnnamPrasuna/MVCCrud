using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace AspMvcRegistration.DAL
{
    public class Emp
    {
        
        public int AddEmp(Models.Emp emp)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["p1"].ToString());
            conn.Open();
            SqlCommand comm = new SqlCommand("proc_AddEmp", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@eno", emp.Eno);
            comm.Parameters.AddWithValue("@ename", emp.Ename);
            comm.Parameters.AddWithValue("@dept", emp.Dept);
            comm.Parameters.AddWithValue("@hobby", emp.Hobby);
            comm.Parameters.AddWithValue("@gender", emp.Gender);
            comm.Parameters.AddWithValue("@salary", emp.Salary);
            int i1=comm.ExecuteNonQuery();
            conn.Close();
            return i1;
        }

    }
}